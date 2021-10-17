using SilverBearDomain.Machines.Views;
using Core.Queries;
using System;

namespace SilverBearDomain.Machines.Queries.SearchById
{
    public class SearchComputerById : IQuery<ComputerView>
    {
        public Guid Id { get; }

        public SearchComputerById(Guid id)
        {
            Id = id;
        }
    }
}
