using SilverBearDomain.Machines.Views;
using Core.Queries;
using System;

namespace SilverBearDomain.Machines.Queries.SearchByAppId
{
    public class SearchComputerByAppId : IQuery<ComputerView>
    {
        public int AppId { get; }

        public SearchComputerByAppId(int appId)
        {
            AppId = appId;
        }
    }
}
