using Core.Queries;
using Marten;
using System;
using System.Threading;
using System.Threading.Tasks;
using SilverBearDomain.Machines.Views;
using SilverBearDomain.Machines.Queries.SearchById;
using System.Collections.Generic;
using SilverBearDomain.Machines.Queries;
using SilverBearDomain.Machines.Queries.GetAll;
using System.Linq;
using SilverBearDomain.Machines.Queries.SearchByAppId;
using SilverBear.ValueObjects;

namespace SilverBearDomain.Machines.Handlers.QueryHandlers
{
    internal class ComputerQueryHandler
        : IQueryHandler<GetAllComputers, IReadOnlyCollection<ComputerInfo>>
        , IQueryHandler<SearchComputerByAppId, ComputerView>        
    {
        private readonly IDocumentSession session;
        public ComputerQueryHandler(IDocumentSession session)
        {
            this.session = session ??
                throw new ArgumentNullException(nameof(session));
        }
        public Task<IReadOnlyCollection<ComputerInfo>> Handle(GetAllComputers request, CancellationToken cancellationToken)
        {
            var res = session.Query<ComputerInfo>().ToList();
            IReadOnlyCollection<ComputerInfo> computers = res.AsReadOnly();
            return Task.FromResult(computers);

        }
        public Task<ComputerView> Handle(SearchComputerByAppId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<ComputerView>()
                .Where(l => l.Data.appId == request.AppId).FirstOrDefault());
        }
    }
}

