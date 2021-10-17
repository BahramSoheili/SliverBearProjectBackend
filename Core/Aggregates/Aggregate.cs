using System;
using System.Collections.Generic;
using System.Linq;
using Core.Events;
using Newtonsoft.Json;

namespace Core.Aggregates
{
    public abstract class Aggregate: EventMetaData, IAggregate
    {
        public int Version { get; protected set; }

        public Guid Id { get; protected set; }

       
        protected Aggregate() { }
      
    }
}
