using Model;
using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.json
{
    public static class JsonProtocolUtils
    {
        public static Response CreateOkResponse()
        {
            Response resp = new Response();
            resp.Type = ResponseType.OK;
            return resp;
        }

        public static Response CreateErrorResponse(string errorMessage)
        {
            Response resp = new Response();
            resp.Type = ResponseType.ERROR;
            resp.ErrorMessage = errorMessage;
            return resp;
        }

        public static Request CreateLoginRequest(OfficeResponsable officeResponsable)
        {
            Request request = new Request();
            request.Type = RequestType.LOGIN;
            request.OfficeResponsable = DTOUtils.GetDTO(officeResponsable);
            return request;
        }

        public static Request CreateAllChallengesRequest()
        {
            Request request = new Request();
            request.Type = RequestType.GET_ALL_CHALLENGES;
            return request;
        }

        public static Response CreateAllChallengesResponse(Challenge[] challenges)
        {
            Response response = new Response();
            response.Type = ResponseType.GET_ALL_CHALLENGES;
            response.Challenges = DTOUtils.GetDTO(challenges);
            return response;
        }


        public static Request CreateGetChildrenByChallengeNameAndGroupAgeRequest(Challenge challenge)
        {
            Request request = new Request();
            request.Type = RequestType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE;
            request.Challenge = DTOUtils.GetDTO(challenge);
            return request;
        }

        public static Response CreateAllChildrenByChallengeNameAndGroupAgeResponse(Child[] children)
        {
            Response response = new Response();
            response.Type = ResponseType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE;
            response.Children = DTOUtils.GetDTO(children);
            return response;
        }

        public static Request CreateEnrollChildRequest(Child child, string challengeName)
        {
            Request request = new Request();
            request.Type = RequestType.ENROLL_CHILD;
            request.Child = DTOUtils.GetDTO(child);
            request.ChallengeName = challengeName;
            return request;
        }

        public static Response CreateUpdateChallengesResponse()
        {
            Response response = new Response();
            response.Type = ResponseType.UPDATE_CHALLENGES;
            return response;
        }
    }
}
