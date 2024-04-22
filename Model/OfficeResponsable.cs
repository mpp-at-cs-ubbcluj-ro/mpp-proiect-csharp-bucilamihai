using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OfficeResponsable: Entity<long>
    {
        public string username {get; set;}
        public string password {get; set;}

        public OfficeResponsable(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
