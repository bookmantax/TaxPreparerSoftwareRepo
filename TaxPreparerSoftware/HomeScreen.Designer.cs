using System.Windows.Forms;

namespace TaxPreparerSoftware
{
    partial class HomeScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.unfinishedList = new System.Windows.Forms.ListView();
            this.issueList = new System.Windows.Forms.ListView();
            this.finishedList = new System.Windows.Forms.ListView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.filesListView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.notesListView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.finishedPicture = new System.Windows.Forms.PictureBox();
            this.issuePicture = new System.Windows.Forms.PictureBox();
            this.unfinishedPicture = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalDeductionTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.addNoteButton = new System.Windows.Forms.Button();
            this.newNoteTextBox = new System.Windows.Forms.TextBox();
            this.saveChangesGroupBox = new System.Windows.Forms.GroupBox();
            this.saveSaveButton = new System.Windows.Forms.Button();
            this.saveCancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.unexpandPictureBox = new System.Windows.Forms.PictureBox();
            this.expandedPictureBox = new System.Windows.Forms.PictureBox();
            this.expandPictureBox = new System.Windows.Forms.PictureBox();
            this.filePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.notesListView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unfinishedPicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.saveChangesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unexpandPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018"});
            this.yearComboBox.Location = new System.Drawing.Point(0, 1);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(153, 21);
            this.yearComboBox.TabIndex = 0;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            // 
            // unfinishedList
            // 
            this.unfinishedList.Location = new System.Drawing.Point(0, 41);
            this.unfinishedList.MultiSelect = false;
            this.unfinishedList.Name = "unfinishedList";
            this.unfinishedList.Size = new System.Drawing.Size(153, 200);
            this.unfinishedList.TabIndex = 1;
            this.unfinishedList.UseCompatibleStateImageBehavior = false;
            this.unfinishedList.SelectedIndexChanged += new System.EventHandler(this.unfinishedList_SelectedIndexChanged);
            // 
            // issueList
            // 
            this.issueList.Location = new System.Drawing.Point(0, 264);
            this.issueList.MultiSelect = false;
            this.issueList.Name = "issueList";
            this.issueList.Size = new System.Drawing.Size(153, 200);
            this.issueList.TabIndex = 2;
            this.issueList.UseCompatibleStateImageBehavior = false;
            this.issueList.SelectedIndexChanged += new System.EventHandler(this.issueList_SelectedIndexChanged);
            // 
            // finishedList
            // 
            this.finishedList.Location = new System.Drawing.Point(0, 487);
            this.finishedList.MultiSelect = false;
            this.finishedList.Name = "finishedList";
            this.finishedList.Size = new System.Drawing.Size(153, 200);
            this.finishedList.TabIndex = 3;
            this.finishedList.UseCompatibleStateImageBehavior = false;
            this.finishedList.SelectedIndexChanged += new System.EventHandler(this.finishedList_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(179, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 13);
            this.nameLabel.TabIndex = 4;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(382, 8);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(0, 13);
            this.emailLabel.TabIndex = 5;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(544, 8);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(0, 13);
            this.phoneLabel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Unfinished";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Issue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Finished";
            // 
            // filesListView
            // 
            this.filesListView.Location = new System.Drawing.Point(182, 41);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(454, 232);
            this.filesListView.TabIndex = 10;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Files";
            // 
            // notesListView
            // 
            this.notesListView.AllowUserToAddRows = false;
            this.notesListView.AllowUserToDeleteRows = false;
            this.notesListView.AllowUserToResizeColumns = false;
            this.notesListView.AllowUserToResizeRows = false;
            this.notesListView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.notesListView.DefaultCellStyle = dataGridViewCellStyle1;
            this.notesListView.Location = new System.Drawing.Point(182, 296);
            this.notesListView.Name = "notesListView";
            this.notesListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.notesListView.Size = new System.Drawing.Size(454, 232);
            this.notesListView.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Notes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.finishedPicture);
            this.groupBox1.Controls.Add(this.issuePicture);
            this.groupBox1.Controls.Add(this.unfinishedPicture);
            this.groupBox1.Location = new System.Drawing.Point(182, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 152);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Progress";
            // 
            // finishedPicture
            // 
            this.finishedPicture.Location = new System.Drawing.Point(282, 19);
            this.finishedPicture.Name = "finishedPicture";
            this.finishedPicture.Size = new System.Drawing.Size(126, 127);
            this.finishedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.finishedPicture.TabIndex = 2;
            this.finishedPicture.TabStop = false;
            this.finishedPicture.Click += new System.EventHandler(this.finishedPicture_Click);
            // 
            // issuePicture
            // 
            this.issuePicture.Location = new System.Drawing.Point(150, 19);
            this.issuePicture.Name = "issuePicture";
            this.issuePicture.Size = new System.Drawing.Size(126, 127);
            this.issuePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.issuePicture.TabIndex = 1;
            this.issuePicture.TabStop = false;
            this.issuePicture.Click += new System.EventHandler(this.issuePicture_Click);
            // 
            // unfinishedPicture
            // 
            this.unfinishedPicture.Location = new System.Drawing.Point(18, 19);
            this.unfinishedPicture.Name = "unfinishedPicture";
            this.unfinishedPicture.Size = new System.Drawing.Size(126, 127);
            this.unfinishedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.unfinishedPicture.TabIndex = 0;
            this.unfinishedPicture.TabStop = false;
            this.unfinishedPicture.Click += new System.EventHandler(this.unfinishedPicture_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(1069, 649);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(103, 38);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalDeductionTextBox);
            this.groupBox2.Location = new System.Drawing.Point(643, 535);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 56);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Deduction";
            // 
            // totalDeductionTextBox
            // 
            this.totalDeductionTextBox.Enabled = false;
            this.totalDeductionTextBox.Location = new System.Drawing.Point(7, 20);
            this.totalDeductionTextBox.Name = "totalDeductionTextBox";
            this.totalDeductionTextBox.Size = new System.Drawing.Size(125, 20);
            this.totalDeductionTextBox.TabIndex = 0;
            this.totalDeductionTextBox.TextChanged += new System.EventHandler(this.totalDeductionTextBox_TextChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.errorLabel.Location = new System.Drawing.Point(643, 623);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(529, 23);
            this.errorLabel.TabIndex = 18;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addNoteButton
            // 
            this.addNoteButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addNoteButton.Location = new System.Drawing.Point(560, 504);
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(75, 23);
            this.addNoteButton.TabIndex = 19;
            this.addNoteButton.Text = "Add Note";
            this.addNoteButton.UseVisualStyleBackColor = true;
            this.addNoteButton.Click += new System.EventHandler(this.addNoteButton_Click);
            // 
            // newNoteTextBox
            // 
            this.newNoteTextBox.Location = new System.Drawing.Point(200, 319);
            this.newNoteTextBox.Multiline = true;
            this.newNoteTextBox.Name = "newNoteTextBox";
            this.newNoteTextBox.Size = new System.Drawing.Size(412, 179);
            this.newNoteTextBox.TabIndex = 20;
            this.newNoteTextBox.Visible = false;
            // 
            // saveChangesGroupBox
            // 
            this.saveChangesGroupBox.Controls.Add(this.saveSaveButton);
            this.saveChangesGroupBox.Controls.Add(this.saveCancelButton);
            this.saveChangesGroupBox.Controls.Add(this.label6);
            this.saveChangesGroupBox.Enabled = false;
            this.saveChangesGroupBox.Location = new System.Drawing.Point(550, 300);
            this.saveChangesGroupBox.Name = "saveChangesGroupBox";
            this.saveChangesGroupBox.Size = new System.Drawing.Size(200, 100);
            this.saveChangesGroupBox.TabIndex = 21;
            this.saveChangesGroupBox.TabStop = false;
            this.saveChangesGroupBox.Visible = false;
            // 
            // saveSaveButton
            // 
            this.saveSaveButton.Location = new System.Drawing.Point(119, 70);
            this.saveSaveButton.Name = "saveSaveButton";
            this.saveSaveButton.Size = new System.Drawing.Size(75, 23);
            this.saveSaveButton.TabIndex = 2;
            this.saveSaveButton.Text = "Save";
            this.saveSaveButton.UseVisualStyleBackColor = true;
            this.saveSaveButton.Click += new System.EventHandler(this.saveSaveButton_Click);
            // 
            // saveCancelButton
            // 
            this.saveCancelButton.Location = new System.Drawing.Point(10, 71);
            this.saveCancelButton.Name = "saveCancelButton";
            this.saveCancelButton.Size = new System.Drawing.Size(75, 23);
            this.saveCancelButton.TabIndex = 1;
            this.saveCancelButton.Text = "Cancel";
            this.saveCancelButton.UseVisualStyleBackColor = true;
            this.saveCancelButton.Click += new System.EventHandler(this.saveCancelButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Save Changes?";
            // 
            // unexpandPictureBox
            // 
            this.unexpandPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unexpandPictureBox.Image = global::TaxPreparerSoftware.Properties.Resources._519978_042_ArrowsTogether_512;
            this.unexpandPictureBox.Location = new System.Drawing.Point(1019, 576);
            this.unexpandPictureBox.Name = "unexpandPictureBox";
            this.unexpandPictureBox.Size = new System.Drawing.Size(85, 70);
            this.unexpandPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.unexpandPictureBox.TabIndex = 24;
            this.unexpandPictureBox.TabStop = false;
            this.unexpandPictureBox.Visible = false;
            this.unexpandPictureBox.Click += new System.EventHandler(this.unexpandPictureBox_Click);
            // 
            // expandedPictureBox
            // 
            this.expandedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandedPictureBox.Enabled = false;
            this.expandedPictureBox.Location = new System.Drawing.Point(114, 62);
            this.expandedPictureBox.Name = "expandedPictureBox";
            this.expandedPictureBox.Size = new System.Drawing.Size(990, 584);
            this.expandedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expandedPictureBox.TabIndex = 23;
            this.expandedPictureBox.TabStop = false;
            this.expandedPictureBox.Visible = false;
            // 
            // expandPictureBox
            // 
            this.expandPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandPictureBox.Image = global::TaxPreparerSoftware.Properties.Resources.diverging_arrow_icon;
            this.expandPictureBox.Location = new System.Drawing.Point(1093, 535);
            this.expandPictureBox.Name = "expandPictureBox";
            this.expandPictureBox.Size = new System.Drawing.Size(79, 50);
            this.expandPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.expandPictureBox.TabIndex = 22;
            this.expandPictureBox.TabStop = false;
            this.expandPictureBox.Click += new System.EventHandler(this.expandPictureBox_Click);
            // 
            // filePictureBox
            // 
            this.filePictureBox.Location = new System.Drawing.Point(643, 41);
            this.filePictureBox.Name = "filePictureBox";
            this.filePictureBox.Size = new System.Drawing.Size(529, 487);
            this.filePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.filePictureBox.TabIndex = 14;
            this.filePictureBox.TabStop = false;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.unexpandPictureBox);
            this.Controls.Add(this.expandedPictureBox);
            this.Controls.Add(this.expandPictureBox);
            this.Controls.Add(this.saveChangesGroupBox);
            this.Controls.Add(this.newNoteTextBox);
            this.Controls.Add(this.addNoteButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filePictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notesListView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.finishedList);
            this.Controls.Add(this.issueList);
            this.Controls.Add(this.unfinishedList);
            this.Controls.Add(this.yearComboBox);
            this.Name = "HomeScreen";
            this.Text = "HomeScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeScreen_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.notesListView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finishedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unfinishedPicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.saveChangesGroupBox.ResumeLayout(false);
            this.saveChangesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unexpandPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ListView unfinishedList;
        private System.Windows.Forms.ListView issueList;
        private System.Windows.Forms.ListView finishedList;
        private Label nameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView filesListView;
        private Label label4;
        private DataGridView notesListView;
        private Label label5;
        private PictureBox filePictureBox;
        private GroupBox groupBox1;
        private PictureBox finishedPicture;
        private PictureBox issuePicture;
        private PictureBox unfinishedPicture;
        private Button saveButton;
        private GroupBox groupBox2;
        private TextBox totalDeductionTextBox;
        private Label errorLabel;
        private Button addNoteButton;
        private TextBox newNoteTextBox;
        private GroupBox saveChangesGroupBox;
        private Button saveSaveButton;
        private Button saveCancelButton;
        private Label label6;
        private PictureBox expandPictureBox;
        private PictureBox expandedPictureBox;
        private PictureBox unexpandPictureBox;
    }
}