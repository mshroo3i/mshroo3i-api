using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mshroo3i.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; private set; }
        public DateTime LastModified {  set; get; }

        public Entity() { }

        public Entity(DateTime created)
        {
            Created = created;
        }
    }
}
