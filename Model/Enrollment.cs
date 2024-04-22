using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enrollment: Entity<long>
    {
        public Child child { get; set; }
        public Challenge challenge {  get; set; }

        public Enrollment(Child child, Challenge challenge)
        {
            this.child = child;
            this.challenge = challenge;
        }
    }
}
