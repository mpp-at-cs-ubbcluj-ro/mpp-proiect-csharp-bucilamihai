using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.domain
{
    internal class Child: Entity<long>
    {
        private long cnp;
        private string name;
        private int age;

        public Child(long cnp, string name, int age)
        {
            this.cnp = cnp;
            this.name = name;
            this.age = age;
        }

        public long Cnp
        {
            get { return cnp; }
            set { cnp = value; }
        }

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
