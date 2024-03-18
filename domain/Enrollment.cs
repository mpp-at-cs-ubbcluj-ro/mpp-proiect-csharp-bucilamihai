using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.domain
{
    internal class Enrollment: Entity<long>
    {
        private Child child;
        private Challenge challenge;

        public Enrollment(Child child, Challenge challenge)
        {
            this.child = child;
            this.challenge = challenge;
        }

        public Child Child
        {
            get { return child; }
            set { child = value; }
        }

        public Challenge Challenge
        {
            get { return challenge; }
            set { challenge = value; }
        }
    }
}
