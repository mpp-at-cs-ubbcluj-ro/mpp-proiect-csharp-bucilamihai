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
            resp.type = ResponseType.OK;
            return resp;
        }

        public static Response CreateErrorResponse(string errorMessage)
        {
            Response resp = new Response();
            resp.type = ResponseType.ERROR;
            resp.errorMessage = errorMessage;
            return resp;
        }

        public static Request CreateLoginRequest(OfficeResponsable officeResponsable)
        {
            Request request = new Request();
            request.type = RequestType.LOGIN;
            request.officeResponsable = DTOUtils.GetDTO(officeResponsable);
            return request;
        }

        public static Request CreateAllChallengesRequest()
        {
            Request request = new Request();
            request.type = RequestType.GET_ALL_CHALLENGES;
            return request;
        }

        public static Response CreateAllChallengesResponse(Challenge[] challenges)
        {
            Response response = new Response();
            response.type = ResponseType.GET_ALL_CHALLENGES;
            response.challenges = DTOUtils.GetDTO(challenges);
            return response;
        }


        public static Request CreateGetChildrenByChallengeNameAndGroupAgeRequest(Challenge challenge)
        {
            Request request = new Request();
            request.type = RequestType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE;
            request.challenge = DTOUtils.GetDTO(challenge);
            return request;
        }

        public static Response CreateAllChildrenByChallengeNameAndGroupAgeResponse(Child[] children)
        {
            Response response = new Response();
            response.type = ResponseType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE;
            response.children = DTOUtils.GetDTO(children);
            return response;
        }

        public static Request CreateEnrollChildRequest(Child child, string challengeName)
        {
            Request request = new Request();
            request.type = RequestType.ENROLL_CHILD;
            request.child = DTOUtils.GetDTO(child);
            request.challengeName = challengeName;
            return request;
        }

        public static Response CreateUpdateChallengesResponse()
        {
            Response response = new Response();
            response.type = ResponseType.UPDATE_CHALLENGES;
            return response;
        }
    }
}
