using SilverBearDomain.Machines.Views;
using Core.Queries;
using System;
using System.Collections.Generic;

namespace SilverBearDomain.Machines.Queries.SearchByCreated
{
    public class SearchComputerByCreated : IQuery<List<ComputerView>>
    {
        public DateTime Created { get; }
        public SearchComputerByCreated(DateTime created)
        {
            Created = created;
        }
    }
}

