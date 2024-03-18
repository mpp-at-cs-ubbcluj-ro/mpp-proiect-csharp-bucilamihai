using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.domain
{
    internal class Entity<ID>
    {
        private ID id;

        public ID Id 
        { 
            get { return id; } 
            set { id = value; }
        }
    }
}
