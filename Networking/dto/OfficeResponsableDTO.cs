using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class OfficeResponsableDTO
    {
        private string username;
        private string password;

        public OfficeResponsableDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
