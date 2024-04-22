using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class ChallengeDTO
    {
        private string name;
        private string groupAge;
        private int numberOfParticipants;

        public ChallengeDTO(string name, string groupAge, int numberOfParticipants)
        {
            this.name = name;
            this.groupAge = groupAge;
            this.numberOfParticipants = numberOfParticipants;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string GroupAge
        {
            get { return groupAge; }
            set { groupAge = value; }
        }

        public virtual int NumberOfParticipants
        {
            get { return numberOfParticipants; }
            set { numberOfParticipants = value; }
        }

        public virtual void increaseNumberOfParticipants()
        {
            numberOfParticipants++;
        }
    }
}
