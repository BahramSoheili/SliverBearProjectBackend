using SilverBear.ValueObjects;
using Core.Commands;
using System;

namespace SilverBearDomain.Machines.Commands.Update
{
    public class UpdateComputer : ICommand
    {
        public Guid Id { get; }
        public ComputerInfo Data { get; }
        public UpdateComputer(Guid id, ComputerInfo data)
        {
            Id = id;
            Data = data;
        }
    }
}
