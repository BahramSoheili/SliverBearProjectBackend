using SilverBear.ValueObjects;
using Core.Aggregates;
using System;

namespace SilverBearDomain.Machines
{
    internal class Computer : Aggregate
    {
        public ComputerInfo Data { get; private set; }
        public Computer()
        {
        }
        public static Computer Update(Guid id, 
            ComputerInfo data, DateTime created)
        {
          return new Computer(id,
             data, DateTime.UtcNow, created);
        }
        public Computer(Guid id, ComputerInfo data, 
            DateTime lastUpdatedTimeStamp, DateTime created)
        {
            Id = id;
            Data = data;
            LastUpdatedTimeStamp = lastUpdatedTimeStamp;
            Created = created;
        }    
    }
}
