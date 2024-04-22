using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.json
{
    public enum RequestType
    {
        LOGIN,
        GET_ALL_CHALLENGES,
        GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE,
        ENROLL_CHILD
    }

    public class Request
    {
        public RequestType Type { get; set; }
        public OfficeResponsableDTO OfficeResponsable { get; set; }
        public ChallengeDTO Challenge { get; set; }
        public ChildDTO Child { get; set; }
        public string ChallengeName { get; set; }
    }
}
