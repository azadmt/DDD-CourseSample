using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

        public virtual bool IsEqual(ValueObject<T> other)
        {
            if (other == null)
            {
                return false;
            }
            return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        

        public override int GetHashCode()
        {
            int hash =0;
            foreach (var obj in this.GetAttributesToIncludeInEqualityCheck())
                hash = hash  + (obj == null ? 0 : obj.GetHashCode());

            return hash;
        }

        public override bool Equals(object obj)
        {
            return IsEqual((ValueObject<T>)obj);
        }

        
    }
}
