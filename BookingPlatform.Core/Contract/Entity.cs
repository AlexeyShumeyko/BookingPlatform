using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Core.Contract
{
    public class Entity<TIdentifier> : IEntity
    {
        public TIdentifier? Id { get; set; }
    }
}
