using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.controller
{
    internal class LoginController
    {
        private OfficeService officeService;

        public LoginController(OfficeService officeService)
        {
            this.officeService = officeService;
        }

        internal OfficeService GetService()
        {
            return officeService;
        }

        internal bool UserExists(string username, string password)
        {
            return officeService.UserExists(username, password);
        }
    }
}
