namespace Eg.Core
{
    using System.Collections.Generic;

    public class Moive : Product
    {
        public virtual string Director { get; set; }
        public virtual IList<ActorRole> Actors { get; set; }
    }
}