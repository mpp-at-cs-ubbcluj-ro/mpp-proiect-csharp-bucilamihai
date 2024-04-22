using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic.FileIO;

using Client.views;
using Client.controller;
using Service;
using Networking;
using Networking.json;

namespace Client
{
    static class Program
    {

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IService server = new ServiceJsonProxy("127.0.0.1", 55556);
            LoginController loginController = new LoginController(server);
            LoginView loginView = new LoginView(loginController);
            Application.Run(loginView);
        }
    }
}
