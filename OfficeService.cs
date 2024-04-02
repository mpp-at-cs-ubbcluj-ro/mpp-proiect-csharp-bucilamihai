using ChildrenContest.domain;
using ChildrenContest.repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChildrenContest
{
    internal class OfficeService
    {
        private IOfficeResponsableRepository officeResponsableRepository;
        private IChallengeRepository challengeRepository;
        private IChildRepository childRepository;
        private IEnrollmentRepository enrollmentRepository;

        public OfficeService(IOfficeResponsableRepository officeResponsableRepository, IChallengeRepository challengeRepository, IChildRepository childRepository, IEnrollmentRepository enrollmentRepository)
        {
            this.officeResponsableRepository = officeResponsableRepository;
            this.challengeRepository = challengeRepository;
            this.childRepository = childRepository;
            this.enrollmentRepository = enrollmentRepository;
        }

        public Collection<Challenge> GetAllChallenges()
        {
            return challengeRepository.GetAll();
        }

        public Collection<Child> GetAllChildren()
        {
            return childRepository.GetAll();
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
            challengeRepository.Update(challenge, challenge.Id);
        }

        internal bool UserExists(string username, string password)
        {
            return officeResponsableRepository.UserExists(username, password);
        }
    }
}