using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Challenge: Entity<long>
    {
        public string name { get; set; }
        public string groupAge { get; set; }
        public int numberOfParticipants { get; set; }

        public Challenge(string name, string groupAge, int numberOfParticipants)
        {
            this.name = name;
            this.groupAge = groupAge;
            this.numberOfParticipants = numberOfParticipants;
        }

        public void increaseNumberOfParticipants()
        {
            this.numberOfParticipants++;
        }
    }
}
