using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Persistence
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        void Add(E elem);
        void Delete(E elem);
        void Update(E elem, ID id);
        E FindById(ID id);
        IEnumerable<E> FindAll();
        Collection<E> GetAll();
    }
}
