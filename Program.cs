using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data.SQLite;
using ChildrenContest.repository;
using ChildrenContest.repository.database;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Configuration;
using ChildrenContest.controller;

namespace ChildrenContest
{
    internal class Program
    {
        static private OfficeService officeService;
        /*static private OfficeView officeView;*/
        static private LoginView loginView;

        static void Main(string[] args)
        {
            initializeService();
            initializeView();
            Application.Run(loginView);
        }

        private static void initializeView()
        {
            /*OfficeController officeController = new OfficeController(officeService);
            officeView = new OfficeView(officeController);*/
            LoginController loginController = new LoginController(officeService);
            loginView = new LoginView(loginController);
        }

        private static void initializeService()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string url = ConfigurationManager.ConnectionStrings["url"].ConnectionString;
            properties["url"] = url;
            IOfficeResponsableRepository officeResponsableRepository = new OfficeResponsableDBRepository(properties);
            IChallengeRepository challengeRepository = new ChallengeDBRepository(properties);
            IChildRepository childRepository = new ChildDBRepository(properties);
            IEnrollmentRepository enrollmentRepository = new EnrollmentDBRepository(properties);
            officeService = new OfficeService(officeResponsableRepository, challengeRepository, childRepository, enrollmentRepository);
        }
    }
}
