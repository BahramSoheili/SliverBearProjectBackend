using Core.Storage;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SilverBearDomain.Machines.Queries;
using SilverBearDomain.Machines.Queries.SearchById;
using SilverBearDomain.Machines.Queries.GetAll;
using SilverBearDomain.Machines.Commands.Create;
using SilverBearDomain.Machines.Handlers.CommandHandlers;
using SilverBearDomain.Machines.Commands.Delete;
using SilverBearDomain.Machines.Commands.Update;
using SilverBearDomain.Machines.Views;
using SilverBearDomain.Machines.Handlers.QueryHandlers;
using SilverBearDomain.Storage;
using SilverBear.ValueObjects;
using SilverBearDomain.Machines.Queries.SearchByAppId;

namespace SilverBearDomain.Machines.DomainConfig
{
    public static class ConfigMachines
    {
        public static void AddConfigMachines(this IServiceCollection services)
        {        
            services.AddComputerScope();           
        }     
        private static void AddComputerScope(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Computer>, MartenRepository<Computer>>();
            services.AddScoped<IRequestHandler<UpdateComputer, Unit>, ComputerCommandHandler>();
            services.AddScoped<IRequestHandler<CreateComputer, Unit>, ComputerCommandHandler>();
            services.AddScoped<IRequestHandler<SearchComputerByAppId, ComputerView>, ComputerQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllComputers, IReadOnlyCollection<ComputerInfo>>, ComputerQueryHandler>();
        }   
    }
}
