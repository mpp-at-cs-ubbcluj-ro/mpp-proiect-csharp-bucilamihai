using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Client.controller;
using Model;
using Service;

namespace Client.views
{
    public partial class LoginView : Form
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
            try
            {
                OfficeController officeController = new OfficeController(loginController.GetService());
                officeController.SetLoggedOfficeResponsable(new OfficeResponsable(username, password));
                loginController.Login(username, password, officeController);
                OfficeView officeView = new OfficeView(officeController);
                officeView.Show();
            }
            catch (ServiceException se)
            {
                MessageBox.Show(se.Message);
            }
        }
    }
}
