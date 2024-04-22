using System.Collections.ObjectModel;

using Model;
using Persistence.interfaces;
using Service;

namespace Server
{
    public class OfficeService : IService
    {
        private IOfficeResponsableRepository officeResponsableRepository;
        private IChallengeRepository challengeRepository;
        private IChildRepository childRepository;
        private IEnrollmentRepository enrollmentRepository;
        private readonly IDictionary<string, IObserver> loggedResponsables;

        public OfficeService(IOfficeResponsableRepository officeResponsableRepository, IChallengeRepository challengeRepository, IChildRepository childRepository, IEnrollmentRepository enrollmentRepository)
        {
            this.officeResponsableRepository = officeResponsableRepository;
            this.challengeRepository = challengeRepository;
            this.childRepository = childRepository;
            this.enrollmentRepository = enrollmentRepository;
            loggedResponsables = new Dictionary<string, IObserver>();  
        }

        public void Login(OfficeResponsable officeResponsable, IObserver client)
        {
            OfficeResponsable officeResponsableFound = officeResponsableRepository.GetByUsernameAndPassword(officeResponsable.username, officeResponsable.password);
            if (officeResponsableFound != null)
            {
                if (loggedResponsables.ContainsKey(officeResponsableFound.username))
                    throw new ServiceException("User already logged in.");
                loggedResponsables[officeResponsableFound.username] = client;
            }
            else
                throw new ServiceException("Invalid username or password");
        }

        public Collection<Challenge> GetAllChallenges()
        {
            return challengeRepository.GetAll();
        }

        public Collection<Child> GetEnrolledChildren(string challengeName, string groupAge)
        {
            return childRepository.GetEnrolledChildren(challengeName, groupAge);
        }

        public void EnrollChild(long cnp, string name, int age, string challengeName)
        {
            Child child = new Child(cnp, name, age);
            childRepository.Add(child);
            Child childWithId = childRepository.GetByCnp(cnp);
            String groupAge;
            if (6 <= age && age <= 8)
                groupAge = "6-8";
            else if (9 <= age && age <= 11)
                groupAge = "9-11";
            else if (12 <= age && age <= 15)
                groupAge = "12-15";
            else
                groupAge = "";
            Challenge challenge = challengeRepository.GetByNameAndGroupAge(challengeName, groupAge);
            Enrollment enrollment = new Enrollment(childWithId, challenge);
            enrollmentRepository.Add(enrollment);
            challenge.increaseNumberOfParticipants();
            challengeRepository.Update(challenge, challenge.id);
            NotifyLoggedResponsables();
        }

        private void NotifyLoggedResponsables()
        {
            foreach(var kvp in loggedResponsables)
            {
                IObserver observer = kvp.Value;
                Task.Run(() => observer.UpdateEnrolledChildren());
            }
        }
    }
}