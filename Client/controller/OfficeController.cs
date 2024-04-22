using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Model;
using Service;

namespace Client.controller
{
    public class OfficeController : IObserver
    {
        public event EventHandler<UserEventArgs> updateEvent; //controller calls it when it has received an update
        private readonly IService server;
        private OfficeResponsable officeResponsable;


        public OfficeController(IService server)
        {
            this.server = server;
            officeResponsable = null;
        }

        internal void SetLoggedOfficeResponsable(OfficeResponsable officeResponsable)
        {
            this.officeResponsable = officeResponsable;
        }

        public Collection<Challenge> GetAllChallenges()
        {
            return server.GetAllChallenges();
        }

        public Collection<Child> GetEnrolledChildren(string challengeName, string groupAge)
        {
            return server.GetEnrolledChildren(challengeName, groupAge);
        }

        public void EnrollChild(long cnp, string name, int age, string challengeName)
        {
            server.EnrollChild(cnp, name, age, challengeName);
        }

        public void UpdateEnrolledChildren()
        {
            UserEventArgs userEventArgs = new UserEventArgs(UserEvent.UPDATE_CHALLENGES, null);
            OnUserEvent(userEventArgs);
        }

        protected virtual void OnUserEvent(UserEventArgs userEventArgs)
        {
            if (updateEvent == null)
                return;
            updateEvent(this, userEventArgs);
            Console.WriteLine("Update Event called!");
        }
    }
}