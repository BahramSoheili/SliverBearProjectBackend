using SilverBear.ValueObjects;
using Core.Commands;
using System;
using SilverBearDomain.Machines.Views;

namespace SilverBearDomain.Machines.Commands.Create
{
    public class CreateComputer : ICommand
    {
        public Guid Id { get; }
        public ComputerView Data { get; }
        public CreateComputer(Guid id, ComputerView data)
        {
            Id = id;
            Data = data;
        }
    }
}
