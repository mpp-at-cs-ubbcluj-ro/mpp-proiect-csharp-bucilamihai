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
        private long cnp;
        private string name;
        private int age;

        public ChildDTO(long cnp, string name, int age)
        {
            this.cnp = cnp;
            this.name = name;
            this.age = age;
        }

        public virtual long Cnp
        {
            get { return cnp; }
            set { cnp = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}
