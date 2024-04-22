using Client.views;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.controller
{
    public class LoginController
    {
        private IService server;

        public LoginController(IService server)
        {
            this.server = server;
        }

        internal IService GetService()
        {
            return server;
        }

        public void Login(string username, string password, OfficeController officeController)
        {
            try
            {
                server.Login(new OfficeResponsable(username, password), officeController);
            }
            catch (ServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
