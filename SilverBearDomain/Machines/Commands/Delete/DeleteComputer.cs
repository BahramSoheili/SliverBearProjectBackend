using Core.Commands;
using System;

namespace SilverBearDomain.Machines.Commands.Delete
{
    public class DeleteComputer : ICommand
    {
        public Guid Id { get; }
        public DateTime LastUpdatedTimeStampFace { get; }

        public DeleteComputer(Guid id, DateTime lastUpdatedTimeStampFace)
        {
            Id = id;
            LastUpdatedTimeStampFace = lastUpdatedTimeStampFace;
        }
    }
}
