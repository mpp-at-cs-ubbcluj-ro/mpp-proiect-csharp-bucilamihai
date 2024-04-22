using Model;
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
        public RequestType type { get; set; }
        public OfficeResponsableDTO officeResponsable { get; set; }
        public ChallengeDTO challenge { get; set; }
        public ChildDTO child { get; set; }
        public string challengeName { get; set; }
    }
}
