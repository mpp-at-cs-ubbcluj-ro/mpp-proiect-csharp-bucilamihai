using Model;

namespace Networking.dto
{

    public class DTOUtils
    {
        public static OfficeResponsable GetFromDTO(OfficeResponsableDTO officeResponsableDTO)
        {
            string username = officeResponsableDTO.Username;
            string password = officeResponsableDTO.Password;
            return new OfficeResponsable(username, password);
        }

        public static OfficeResponsableDTO GetDTO(OfficeResponsable user)
        {
            string username = user.Username;
            string password = user.Password;
            return new OfficeResponsableDTO(username, password);
        }

        public static Challenge GetFromDTO(ChallengeDTO challengeDTO)
        {
            string name = challengeDTO.Name;
            string groupAge = challengeDTO.GroupAge;
            int numberOfParticipants = challengeDTO.NumberOfParticipants;
            return new Challenge(name, groupAge, numberOfParticipants);
        }

        public static ChallengeDTO GetDTO(Challenge challenge)
        {
            string name = challenge.Name;
            string groupAge = challenge.GroupAge;
            int numberOfParticipants = challenge.NumberOfParticipants;
            return new ChallengeDTO(name, groupAge, numberOfParticipants);
        }

        public static Challenge[] GetFromDTO(ChallengeDTO[] challengesDTO)
        {
            Challenge[] challenges = new Challenge[challengesDTO.Length];
            for (int i = 0; i < challengesDTO.Length; i++)
            {
                challenges[i] = GetFromDTO(challengesDTO[i]);
            }
            return challenges;
        }

        public static ChallengeDTO[] GetDTO(Challenge[] challenges)
        {
            ChallengeDTO[] challengesDTO = new ChallengeDTO[challenges.Length];
            for (int i = 0; i < challenges.Length; i++)
            {
                challengesDTO[i] = GetDTO(challenges[i]);
            }
            return challengesDTO;
        }

        public static Child[] GetFromDTO(ChildDTO[] childrenDTO)
        {
            Child[] children = new Child[childrenDTO.Length];
            for (int i = 0; i < childrenDTO.Length; i++)
            {
                children[i] = GetFromDTO(childrenDTO[i]);
            }
            return children;
        }

        public static ChildDTO[] GetDTO(Child[] children)
        {
            ChildDTO[] childrenDTO = new ChildDTO[children.Length];
            for (int i = 0; i < children.Length; i++)
            {
                childrenDTO[i] = GetDTO(children[i]);
            }
            return childrenDTO;
        }

        public static ChildDTO GetDTO(Child child)
        {
            long cnp = child.Cnp;
            string name = child.Name;
            int age = child.Age;
            return new ChildDTO(cnp, name, age);
        }

        public static Child GetFromDTO(ChildDTO childDTO)
        {
            long cnp = childDTO.Cnp;
            string name = childDTO.Name;
            int age = childDTO.Age;
            return new Child(cnp, name, age);
        }
    }
}