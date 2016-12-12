using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace TaxPreparerSoftware
{
    public partial class HomeScreen : Form
    {
        TaxEntities db = new TaxEntities();
        ArrayList unfinishedIdList;
        ArrayList issueIdList;
        ArrayList finishedIdList;
        User dbUser;
        UserPerDiem dbUserPerdiem;
        int taxPreparerId, taxPreparerRoleId;
        int year;
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        Image image = null;
        int statusId;//1 = finished, 2 = unfinished, 3 = issue
        bool itemChanged;
        int unfinishedSelectedIndex, finishedSelectedIndex, issueSelectedIndex;

        public HomeScreen(int taxPreparerId, int taxPreparerRoleId)
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.unfinishedList.View = View.Details;
            this.unfinishedList.HeaderStyle = ColumnHeaderStyle.None;
            this.unfinishedList.Columns.Add(new ColumnHeader { Width = this.unfinishedList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth });
            this.issueList.View = View.Details;
            this.issueList.HeaderStyle = ColumnHeaderStyle.None;
            this.issueList.Columns.Add(new ColumnHeader { Width = this.issueList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth });
            this.finishedList.View = View.Details;
            this.finishedList.HeaderStyle = ColumnHeaderStyle.None;
            this.finishedList.Columns.Add(new ColumnHeader { Width = this.finishedList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth });
            this.filesListView.View = View.Details;
            this.filesListView.HeaderStyle = ColumnHeaderStyle.None;
            this.filesListView.Columns.Add(new ColumnHeader { Width = this.filesListView.ClientSize.Width - SystemInformation.VerticalScrollBarWidth });
            this.taxPreparerId = taxPreparerId;
            this.taxPreparerRoleId = taxPreparerRoleId;
            TaxPreparer taxPreparer = (from tp in db.TaxPreparers where tp.Id == taxPreparerId select tp).FirstOrDefault();
            this.Text = "Welcome " + taxPreparer.FirstName + " " + taxPreparer.LastName;
            notesListView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Notes",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });
            itemChanged = false;
            unexpandPictureBox.BackColor = Color.Transparent;
            yearComboBox.SelectedIndex = 0;
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUsersList();
            ClearPageForNewUsers();
        }

        private void SetUsersList()
        {
            unfinishedIdList = new ArrayList();
            unfinishedList.Items.Clear();
            issueIdList = new ArrayList();
            issueList.Items.Clear();
            finishedIdList = new ArrayList();
            finishedList.Items.Clear();
            year = Int32.Parse((String)yearComboBox.SelectedItem);
            var taxUsers = (from t in db.UserToPreparers where year == t.Year && (taxPreparerRoleId != 1 ? taxPreparerId == t.TaxPreparerId : 1 == 1) select t);//select all for admin
            foreach (UserToPreparer u in taxUsers)
            {
                switch (u.Status.Name)
                {
                    case "Unfinished":
                        unfinishedList.Items.Add(u.User.FirstName + " " + u.User.LastName);
                        unfinishedIdList.Add(u.UserId.ToString());
                        break;
                    case "Finished":
                        finishedList.Items.Add(u.User.FirstName + " " + u.User.LastName);
                        finishedIdList.Add(u.UserId.ToString());
                        break;
                    case "Issue":
                        issueList.Items.Add(u.User.FirstName + " " + u.User.LastName);
                        issueIdList.Add(u.UserId.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearPageForNewUsers()
        {
            filesListView.Items.Clear();
            notesListView.Rows.Clear();
            filePictureBox.Image = null;
            nameLabel.Text = "";
            emailLabel.Text = "";
            phoneLabel.Text = "";
            unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\red.png"));
            issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orange.png"));
            finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\green.png"));
            filePictureBox.Image = null;
            image = null;
            errorLabel.Text = "";
            totalDeductionTextBox.Text = "";
            totalDeductionTextBox.Enabled = false;
            addNoteButton.Enabled = false;
            DisableNewNote();
            itemChanged = false;
            saveButton.Enabled = false;
            unfinishedSelectedIndex = 0;
            finishedSelectedIndex = 0;
            issueSelectedIndex = 0;
        }

        private void unfinishedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unfinishedList.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                for(int i = 0; i < finishedList.SelectedItems.Count; i++)
                {
                    if(finishedList.SelectedItems[i].Selected)
                    {
                        finishedList.SelectedItems[i].Selected = false;
                    }
                }
                for (int i = 0; i < issueList.SelectedItems.Count; i++)
                {
                    if (issueList.SelectedItems[i].Selected)
                    {
                        issueList.SelectedItems[i].Selected = false;
                    }
                }
                if (dbUser != null && itemChanged)
                {
                    SetControlsEnabledWhenSaveDialogPresent(false);
                    saveChangesGroupBox.Enabled = true;
                    saveChangesGroupBox.Visible = true;
                    unfinishedSelectedIndex = unfinishedList.SelectedItems[0].Index + 1;//+1 so it wont be zero and we know which list was selected
                    unfinishedList.SelectedItems[0].Selected = false;
                }
                else
                {
                    int id = Int32.Parse((string)unfinishedIdList[unfinishedList.SelectedItems[0].Index]);
                    GetUser(id);
                    statusId = 2;
                    DisableNewNote();
                    totalDeductionTextBox.Enabled = true;
                    filePictureBox.Image = null;
                    image = null;
                }
            }
        }

        private void issueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (issueList.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < finishedList.SelectedItems.Count; i++)
                {
                    if (finishedList.SelectedItems[i].Selected)
                    {
                        finishedList.SelectedItems[i].Selected = false;
                    }
                }
                for (int i = 0; i < unfinishedList.SelectedItems.Count; i++)
                {
                    if (unfinishedList.SelectedItems[i].Selected)
                    {
                        unfinishedList.SelectedItems[i].Selected = false;
                    }
                }
                if (dbUser != null && itemChanged)
                {
                    SetControlsEnabledWhenSaveDialogPresent(false);
                    saveChangesGroupBox.Enabled = true;
                    saveChangesGroupBox.Visible = true;
                    issueSelectedIndex = issueList.SelectedItems[0].Index + 1;//+1 so it wont be zero and we know which list was selected
                    issueList.SelectedItems[0].Selected = false;
                }
                else
                {
                    int id = Int32.Parse((string)issueIdList[issueList.SelectedItems[0].Index]);
                    GetUser(id);
                    statusId = 3;
                    DisableNewNote();
                    totalDeductionTextBox.Enabled = true;
                    filePictureBox.Image = null;
                    image = null;
                }
            }
        }

        private void finishedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (finishedList.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < unfinishedList.SelectedItems.Count; i++)
                {
                    if (unfinishedList.SelectedItems[i].Selected)
                    {
                        unfinishedList.SelectedItems[i].Selected = false;
                    }
                }
                for (int i = 0; i < issueList.SelectedItems.Count; i++)
                {
                    if (issueList.SelectedItems[i].Selected)
                    {
                        issueList.SelectedItems[i].Selected = false;
                    }
                }
                if (dbUser != null && itemChanged)
                {
                    SetControlsEnabledWhenSaveDialogPresent(false);
                    saveChangesGroupBox.Enabled = true;
                    saveChangesGroupBox.Visible = true;
                    finishedSelectedIndex = finishedList.SelectedItems[0].Index + 1;//+1 so it wont be zero and we know which list was selected
                    finishedList.SelectedItems[0].Selected = false;
                }
                else
                {
                    int id = Int32.Parse((string)finishedIdList[finishedList.SelectedItems[0].Index]);
                    GetUser(id);
                    statusId = 1;
                    DisableNewNote();
                    totalDeductionTextBox.Enabled = true;
                    filePictureBox.Image = null;
                    image = null;
                }
            }
        }

        private void GetUser(int id)
        {
            dbUser = (from u in db.Users where u.Id == id select u).FirstOrDefault();
            if (dbUser == null)
            {
                //something bad happened
            }
            else
            {
                addNoteButton.Enabled = true;
                nameLabel.Text = dbUser.FirstName + " " + dbUser.LastName;
                emailLabel.Text = dbUser.EmailAddress;
                phoneLabel.Text = dbUser.PhoneNumber;
                filesListView.Items.Clear();
                var files = (from f in db.UserMiscDocs where f.UserId == id && f.Year == year select f);
                if(files != null)
                {
                    foreach(UserMiscDoc doc in files)
                    {
                        filesListView.Items.Add(doc.Path + "\t\t\t " + doc.Date);
                    }
                }
                notesListView.Rows.Clear();
                var notes = (from n in db.PreparerNotes where n.UserId == id && n.Year == year select n);
                if(notes != null)
                {
                    foreach (PreparerNote note in notes)
                    {
                        TaxPreparer noteCreator = (from u in db.TaxPreparers where u.Id == note.NoteCreatorId select u).FirstOrDefault();
                        if (noteCreator != null)
                        {
                            notesListView.Rows.Add(noteCreator.FirstName + " " + noteCreator.LastName +
                                ": " + note.Date + " - " + note.Notes);
                        }
                        else
                        {
                            notesListView.Rows.Add("Unknown" +
                                ": " + note.Date + " - " + note.Notes);
                        }
                    }
                }
                UserPerDiem userPerDiem = (from udp in db.UserPerDiems where udp.UserId == dbUser.Id && udp.Year == year select udp).FirstOrDefault();
                if(userPerDiem != null)
                {
                    dbUserPerdiem = userPerDiem;
                    totalDeductionTextBox.Text = userPerDiem.Allowance.ToString();
                }
                else
                {
                    totalDeductionTextBox.Text = "0";
                }
                UserToPreparer userToPreparer = (from utp in db.UserToPreparers where utp.UserId == dbUser.Id && utp.TaxPreparerId == taxPreparerId && utp.Year == year select utp).FirstOrDefault();
                if (userToPreparer != null)
                {
                    switch(userToPreparer.StatusId)
                    {
                        case 1:
                            unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\red.png"));
                            issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orange.png"));
                            finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\greenCheck.png"));
                            break;
                        case 2:
                            unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\redCheck.png"));
                            issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orange.png"));
                            finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\green.png"));
                            break;
                        case 3:
                            unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\red.png"));
                            issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orangeCheck.png"));
                            finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\green.png"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            filePictureBox.Image = Image.FromFile(Path.Combine(path, "TestImages\\hkj.jpg"));
            image = filePictureBox.Image;
        }

        private void notesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(notesListView.SelectedColumns.Count > 0)
            {
                if(notesListView.SelectedColumns[0].Selected)
                {
                    notesListView.SelectedColumns[0].Selected = false;
                }
            }
        }

        private void unfinishedPicture_Click(object sender, EventArgs e)
        {
            if (dbUser != null)
            {
                unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\redCheck.png"));
                issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orange.png"));
                finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\green.png"));
                statusId = 2;
                itemChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void issuePicture_Click(object sender, EventArgs e)
        {
            if (dbUser != null)
            {
                unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\red.png"));
                issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orangeCheck.png"));
                finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\green.png"));
                statusId = 3;
                itemChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void finishedPicture_Click(object sender, EventArgs e)
        {
            if (dbUser != null)
            {
                unfinishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\red.png"));
                issuePicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\orange.png"));
                finishedPicture.Image = Image.FromFile(Path.Combine(path, "ImageResources\\greenCheck.png"));
                statusId = 1;
                itemChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dbUser != null)
            {
                SaveUser();
                itemChanged = false;
                saveButton.Enabled = false;
            }
            else
            {
                errorLabel.Text = "Please select a user";
                DisableNewNote();
            }
        }

        private void SaveUser()
        {
            UserToPreparer userToPreparer = (from utp in db.UserToPreparers where utp.UserId == dbUser.Id && utp.TaxPreparerId == taxPreparerId && utp.Year == year select utp).FirstOrDefault();
            if (userToPreparer != null)
            {
                userToPreparer.StatusId = statusId;
            }
            UserPerDiem userPerDiem = (from upd in db.UserPerDiems where upd.UserId == dbUser.Id && year == upd.Year select upd).FirstOrDefault();
            if (userPerDiem == null)
            {
                userPerDiem = new UserPerDiem();
                userPerDiem.User = dbUser;
                userPerDiem.Year = year;
                if (totalDeductionTextBox.Text == "")
                {
                    userPerDiem.Allowance = 0;
                    db.UserPerDiems.Add(userPerDiem);
                    errorLabel.Text = "Saved Successfully";
                    db.SaveChanges();
                    SetUsersList();
                }
                else
                {
                    try
                    {
                        userPerDiem.Allowance = Int32.Parse(totalDeductionTextBox.Text);
                        db.UserPerDiems.Add(userPerDiem);
                        errorLabel.Text = "Saved Successfully";
                        db.SaveChanges();
                        SetUsersList();
                    }
                    catch (Exception ex) { errorLabel.Text = "Please enter a valid number for Total Deduction"; }
                }
            }
            else
            {
                if (totalDeductionTextBox.Text == "")
                {
                    userPerDiem.Allowance = 0;
                    errorLabel.Text = "Saved Successfully";
                    db.SaveChanges();
                    SetUsersList();
                }
                else
                {
                    try
                    {
                        userPerDiem.Allowance = Int32.Parse(totalDeductionTextBox.Text);
                        errorLabel.Text = "Saved Successfully";
                        db.SaveChanges();
                        SetUsersList();
                    }
                    catch (Exception ex) { errorLabel.Text = "Please enter a valid number for Total Deduction"; }
                }
            }
            DisableNewNote();
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            if (addNoteButton.Text == "Add Note")
            {
                addNoteButton.Text = "Save Note";
                notesListView.BackColor = Color.Gray;
                newNoteTextBox.Visible = true;
            }
            else
            {
                addNoteButton.Text = "Add Note";
                notesListView.BackColor = Color.White;
                newNoteTextBox.Visible = false;
                if (newNoteTextBox.Text != "")
                {
                    PreparerNote note = new PreparerNote();
                    note.UserId = dbUser.Id;
                    note.PreparerId = taxPreparerId;
                    note.NoteCreatorId = taxPreparerId;
                    note.Year = year;
                    note.Date = DateTime.Now.ToShortDateString();
                    note.Notes = newNoteTextBox.Text;
                    db.PreparerNotes.Add(note);
                    db.SaveChanges();
                    notesListView.Rows.Clear();
                    var notes = (from n in db.PreparerNotes where n.UserId == dbUser.Id && n.PreparerId == taxPreparerId && n.Year == year select n);
                    if (notes != null)
                    {
                        foreach (PreparerNote note1 in notes)
                        {
                            User noteCreator = (from u in db.Users where u.Id == note1.NoteCreatorId select u).FirstOrDefault();
                            if (noteCreator != null)
                            {
                                notesListView.Rows.Add(noteCreator.FirstName + " " + noteCreator.LastName +
                                    ": " + note1.Date + " - " + note1.Notes);
                            }
                            else
                            {
                                notesListView.Rows.Add("Unknown" +
                                    ": " + note1.Date + " - " + note1.Notes);
                            }
                        }
                    }
                    newNoteTextBox.Text = "";
                }
            }
        }

        private void DisableNewNote()
        {
            if (newNoteTextBox.Visible)
            {
                addNoteButton.Text = "Add Note";
                newNoteTextBox.Visible = false;
                newNoteTextBox.Text = "";
                notesListView.BackColor = Color.White;
            }
        }

        private void saveSaveButton_Click(object sender, EventArgs e)
        {
            if (dbUser != null)
            {
                SaveUser();
                saveChangesGroupBox.Enabled = false;
                saveChangesGroupBox.Visible = false;
            }
            itemChanged = false;
            saveButton.Enabled = false;
            if (unfinishedSelectedIndex > 0)
            {
                unfinishedList.Items[unfinishedSelectedIndex - 1].Selected = true;
                unfinishedSelectedIndex = 0;
            }
            else if(issueSelectedIndex > 0)
            {
                issueList.Items[issueSelectedIndex - 1].Selected = true;
                issueSelectedIndex = 0;
            }
            else if(finishedSelectedIndex > 0)
            {
                finishedList.Items[finishedSelectedIndex - 1].Selected = true;
                finishedSelectedIndex = 0;
            }
            SetControlsEnabledWhenSaveDialogPresent(true);
        }

        private void saveCancelButton_Click(object sender, EventArgs e)
        {
            saveChangesGroupBox.Enabled = false;
            saveChangesGroupBox.Visible = false;
            itemChanged = false;
            saveButton.Enabled = false;
            if (unfinishedSelectedIndex > 0)
            {
                unfinishedList.Items[unfinishedSelectedIndex - 1].Selected = true;
                unfinishedSelectedIndex = 0;
            }
            else if (issueSelectedIndex > 0)
            {
                issueList.Items[issueSelectedIndex - 1].Selected = true;
                issueSelectedIndex = 0;
            }
            else if (finishedSelectedIndex > 0)
            {
                finishedList.Items[finishedSelectedIndex - 1].Selected = true;
                finishedSelectedIndex = 0;
            }
            SetControlsEnabledWhenSaveDialogPresent(true);
            GetUser(dbUser.Id);
        }

        private void expandPictureBox_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                expandedPictureBox.Visible = true;
                expandedPictureBox.Image = Image.FromFile(Path.Combine(path, "TestImages\\hkj.jpg"));
                unexpandPictureBox.Visible = true;
                SetControlsEnabledWhenSaveDialogPresent(false);
                unexpandPictureBox.BringToFront();
            }
        }

        private void unexpandPictureBox_Click(object sender, EventArgs e)
        {
            expandedPictureBox.Visible = false;
            unexpandPictureBox.Visible = false;
            SetControlsEnabledWhenSaveDialogPresent(true);
        }

        private void SetControlsEnabledWhenSaveDialogPresent(bool enabled)
        {
            unfinishedList.Enabled = enabled;
            issueList.Enabled = enabled;
            finishedList.Enabled = enabled;
            saveButton.Enabled = enabled;
            totalDeductionTextBox.Enabled = enabled;
            unfinishedPicture.Enabled = enabled;
            issuePicture.Enabled = enabled;
            finishedPicture.Enabled = enabled;
            yearComboBox.Enabled = enabled;
            addNoteButton.Enabled = enabled;
            notesListView.Enabled = enabled;
            filesListView.Enabled = enabled;
            expandPictureBox.Enabled = enabled;
        }

        private void totalDeductionTextBox_TextChanged(object sender, EventArgs e)
        {
            if(dbUserPerdiem != null)
            {
                if(dbUserPerdiem.Allowance.ToString() != totalDeductionTextBox.Text)
                {
                    itemChanged = true;
                    saveButton.Enabled = true;
                }
            }
            else
            {
                if(totalDeductionTextBox.Text != "" && totalDeductionTextBox.Text != "0")
                {
                    itemChanged = true;
                    saveButton.Enabled = true;
                }
            }
        }

        private void HomeScreen_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(itemChanged)
            {
                e.Cancel = true;
                SetControlsEnabledWhenSaveDialogPresent(false);
                saveChangesGroupBox.Enabled = true;
                saveChangesGroupBox.Visible = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
