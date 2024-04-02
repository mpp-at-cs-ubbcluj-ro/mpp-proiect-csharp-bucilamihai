using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChildrenContest
{
    internal class OfficeController
    {
        private OfficeService officeService;

        public OfficeController(OfficeService officeService)
        {
            this.officeService = officeService;
        }

        public Collection<Challenge> GetAllChallenges()
        {
            return officeService.GetAllChallenges();
        }

        public Collection<Child> GetEnrolledChildren(string challengeName, string groupAge)
        {
            return officeService.GetEnrolledChildren(challengeName, groupAge);
        }

        public void EnrollChild(long cnp, string name, int age, string challengeName)
        {
            officeService.EnrollChild(cnp, name, age, challengeName);
        }
    }
}