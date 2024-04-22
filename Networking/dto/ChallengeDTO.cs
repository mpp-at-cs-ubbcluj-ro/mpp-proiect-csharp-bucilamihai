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
        public string name { get; set; }
        public string groupAge {  get; set; }
        public int numberOfParticipants {  get; set; }

        public ChallengeDTO(string name, string groupAge, int numberOfParticipants)
        {
            this.name = name;
            this.groupAge = groupAge;
            this.numberOfParticipants = numberOfParticipants;
        }

        public virtual void increaseNumberOfParticipants()
        {
            numberOfParticipants++;
        }
    }
}
