using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Persistence.interfaces
{
    public interface IChallengeRepository : IRepository<long, Challenge>
    {
        Challenge GetByNameAndGroupAge(string challengeName, string groupAge);
    }
}
