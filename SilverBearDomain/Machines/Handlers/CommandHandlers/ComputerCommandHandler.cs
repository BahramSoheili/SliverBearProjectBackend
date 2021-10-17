using SilverBearDomain.Machines.Commands.Create;
using SilverBearDomain.Machines.Commands.Delete;
using SilverBearDomain.Machines.Commands.Update;
using SilverBearDomain.Machines.Queries.SearchById;
using SilverBearDomain.Machines.Views;
using Core.Commands;
using Core.Queries;
using Core.Storage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SilverBear;
using System.Net.Http;

namespace SilverBearDomain.Machines.Handlers.CommandHandlers
{
    internal class ComputerCommandHandler:
        ICommandHandler<CreateComputer>,
        ICommandHandler<UpdateComputer>
    {
        private readonly IRepository<Computer> _repositoryComputer;
        private readonly IQueryBus _queryBus;

        public ComputerCommandHandler(
            IRepository<Computer> repositoryComputer,
            IQueryBus queryBus)
        {
            this._repositoryComputer = repositoryComputer ?? 
                throw new ArgumentNullException(nameof(repositoryComputer));
            this._queryBus = queryBus ?? 
                throw new ArgumentNullException(nameof(queryBus));

        }
        public async Task<Unit> Handle(UpdateComputer request, CancellationToken cancellationToken)
        {
            var Computer = _repositoryComputer.FindById(request.Id, cancellationToken).Result;
            if (Computer != null)
            {
                var document = Computer
                    .Update(Computer.Id, Computer.Data, Computer.Created);
                await _repositoryComputer.Update(Computer, cancellationToken);
                return Unit.Value;
            }
            throw new Exception("Computer does not exist.");
        }
        public async Task<Unit> Handle(CreateComputer request, CancellationToken cancellationToken)
        {
            var Computer = _repositoryComputer.FindById(request.Id, cancellationToken).Result;
            if (Computer != null)
            {
                var document = Computer
                    .Update(Computer.Id, Computer.Data, Computer.Created);
                await _repositoryComputer.Update(Computer, cancellationToken);
                return Unit.Value;
            }
            throw new Exception("Computer does not exist.");
        }      
    }
}


