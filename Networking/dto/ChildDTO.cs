using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class ChildDTO
    {
        public long cnp { get; set; }
        public string name {  get; set; }
        public int age {  get; set; }

        public ChildDTO(long cnp, string name, int age)
        {
            this.cnp = cnp;
            this.name = name;
            this.age = age;
        }
    }
}
