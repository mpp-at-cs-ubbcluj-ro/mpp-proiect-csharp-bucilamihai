using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Persistence.interfaces
{
    public interface IChildRepository : IRepository<long, Child>
    {
        Child GetByCnp(long cnp);
        Collection<Child> GetEnrolledChildren(string challengeName, string groupAge);
    }
}
