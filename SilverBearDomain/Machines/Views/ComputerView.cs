using SilverBear.ValueObjects;
using Core.Events;
namespace SilverBearDomain.Machines.Views
{
    public class ComputerView: EventMetaData
    {
        public ComputerInfo Data { get; set; }      
    }
}
