using SilverBearDomain.Machines.Projections;
using Marten;
namespace SilverBearDomain.Machines.DomainConfig
{
    public static class ConfigMachinesMarten
    {
        public static void AddMachinesConfigureMarten(StoreOptions options)
        {
            options.Events.InlineProjections.AggregateStreamsWith<Computer>();
            options.Events.InlineProjections.Add<ComputerViewProjection>();
        }
    }
}
