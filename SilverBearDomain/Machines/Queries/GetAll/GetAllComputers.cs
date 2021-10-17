using SilverBearDomain.Machines.Views;
using Core.Queries;
using System.Collections.Generic;
using SilverBear.ValueObjects;

namespace SilverBearDomain.Machines.Queries.GetAll
{
    public class GetAllComputers : IQuery<IReadOnlyCollection<ComputerInfo>>
    {        

        public GetAllComputers()
        {
        }
        
    }
}
