using ChildrenContest.controller;
using ChildrenContest.repository.database;
using ChildrenContest.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ChildrenContest
{
    internal partial class LoginView : Form
    {
        private LoginController loginController;
        public LoginView(LoginController loginController)
        {
            this.loginController = loginController;
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            String username = username_textBox.Text;
            String password = password_textBox.Text;
            if(loginController.UserExists(username, password))
            {
                OfficeController officeController = new OfficeController(loginController.GetService());
                OfficeView officeView = new OfficeView(officeController);
                officeView.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
