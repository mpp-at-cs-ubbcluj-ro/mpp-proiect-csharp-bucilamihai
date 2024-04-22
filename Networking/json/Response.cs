using Model;
using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.json
{
    public enum ResponseType
    {
        OK,
        ERROR,
        GET_ALL_CHALLENGES,
        GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE,
        UPDATE_CHALLENGES
    }

    public class Response
    {
        public ResponseType type { get; set; }
        public string errorMessage { get; set; }
        public ChallengeDTO[] challenges { get; set; }
        public ChildDTO[] children { get; set; }
    }
}
