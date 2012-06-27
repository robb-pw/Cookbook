namespace Eg.Core
{
    using System;

    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }
        //public virtual Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public static bool IsTransient(Entity<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private Type GetUnProxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
            {
                var otherType = other.GetUnProxiedType();
                var thisType = GetUnProxiedType();

                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Equals(Id, default(TId)) ? base.GetHashCode() : Id.GetHashCode();
        }
    }

    public abstract class Entity : Entity<Guid>
    {
        
    }
}