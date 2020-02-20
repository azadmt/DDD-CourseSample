using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Domain
{
    public class Entity : IEquatable<Entity>
    {

        public Entity()
        {
            id = Guid.NewGuid();
        }

        private Guid id;
        public virtual Guid Id { get => id; }

        public virtual bool Equals(Entity other)
        {
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return base.Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

}
