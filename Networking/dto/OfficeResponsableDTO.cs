using Model;
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
        public string username { get; set; }
        public string password { get; set; }

        public OfficeResponsableDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
