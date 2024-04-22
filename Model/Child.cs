using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Child: Entity<long>
    {
        public long cnp { get; set; }
        public string name { get; set; }
        public int age {  get; set; }

        public Child(long cnp, string name, int age)
        {
            this.cnp = cnp;
            this.name = name;
            this.age = age;
        }
    }
}
