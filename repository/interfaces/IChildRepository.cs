using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.repository
{
    internal interface IChildRepository : IRepository<long, Child>
    {
        Child GetByCnp(long cnp);
        Collection<Child> GetEnrolledChildren(string challengeName, string groupAge);
    }
}
