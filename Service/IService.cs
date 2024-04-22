using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Service
{
    public interface IService
    {
        public void Login(OfficeResponsable officeResponsable, IObserver client);
        public Collection<Challenge> GetAllChallenges();
        public Collection<Child> GetEnrolledChildren(string challengeName, string groupAge);
        public void EnrollChild(long cnp, string name, int age, string challengeName);
    }
}
