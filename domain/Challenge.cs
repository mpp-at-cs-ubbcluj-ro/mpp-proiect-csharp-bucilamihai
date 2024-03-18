using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.domain
{
    internal class Challenge: Entity<long>
    {
        private string name;
        private string groupAge;
        private int numberOfParticipants;

        public Challenge(string name, string groupAge, int numberOfParticipants)
        {
            this.name = name;
            this.groupAge = groupAge;
            this.numberOfParticipants = numberOfParticipants;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string GroupAge
        {
            get { return groupAge; }
            set {  groupAge = value; }
        }

        public int NumberOfParticipants
        {
            get { return numberOfParticipants; }
            set { numberOfParticipants = value; }
        }

        public void increaseNumberOfParticipants()
        {
            this.numberOfParticipants++;
        }
    }
}
