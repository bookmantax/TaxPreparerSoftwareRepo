using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxPreparerSoftware
{
    public partial class Form1 : Form
    {
        TaxEntities db = new TaxEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            TaxPreparer dbUser = (from u in db.TaxPreparers where u.EmailAddress == email && password == u.Password select u).FirstOrDefault();

            if(dbUser == null)
            {
                errorLabel.Text = "Incorrect Email or Password";
            }
            else
            {
                HomeScreen homeForm = new HomeScreen(dbUser.Id, dbUser.RoleId);
                homeForm.Show();
                this.Hide();
            }
        }
    }
}
