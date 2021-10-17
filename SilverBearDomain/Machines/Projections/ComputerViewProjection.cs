using SilverBearDomain.Machines.Views;
using Marten.Events.Projections;
using System;
namespace SilverBearDomain.Machines.Projections
{
    public class ComputerViewProjection : ViewProjection<ComputerView, Guid>
    {
        public ComputerViewProjection()
        {
           // ProjectEvent<ComputerUpdated>(e => e.Id, Apply);
        }        
    }
}
