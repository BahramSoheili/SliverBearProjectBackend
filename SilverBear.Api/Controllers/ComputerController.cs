using Core.Commands;
using Core.Queries;
using SilverBearDomain.Machines.Commands.Update;
using SilverBearDomain.Machines.Queries.GetAll;
using SilverBearDomain.Machines.Queries.SearchByAppId;
using SilverBearDomain.Machines.Queries.SearchById;
using SilverBearDomain.Machines.Views;
using Microsoft.AspNetCore.Mvc;
using SilverBear.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilverBearDomain.Machines.Commands.Create;

namespace SilverBear.Api.Controllers
{
    public class ComputerController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        public ComputerController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }
        [HttpGet("{id}")]
        public Task<ComputerView> Get(Guid id)
        {
            return _queryBus.Send<SearchComputerById, ComputerView>
                (new SearchComputerById(id));
        }
        [HttpGet("GetAppId/{appId}")]
        public Task<ComputerView> Get(int appId)
        {
            return _queryBus.Send<SearchComputerByAppId, ComputerView>
                (new SearchComputerByAppId(appId));
        }
        [HttpGet("GetAll/")]
        public Task<IReadOnlyCollection<ComputerInfo>> GetAll()
        {
            return _queryBus.Send<GetAllComputers, IReadOnlyCollection<ComputerInfo>>
                (new GetAllComputers());
        }
        [HttpPost]
        public async Task<IActionResult> Post(
         [FromBody] ComputerView Data)
        {
            try
            {
                Guid id = Guid.NewGuid();
                await _commandBus.Send(new CreateComputer(id, Data));
                return Ok();
            }
            catch (Exception)
            {

                throw new Exception("Creating Object has problem");
            }          
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,
         [FromBody] ComputerInfo Data)
        {
            var ComputerInfo = Data;
            var Computer = Get(id).Result;
            if (Computer != null)
            {
                await _commandBus.Send(new UpdateComputer(id, Data));
                return Ok();
            }
            else
            {
                throw new Exception("Object does not exist.");           
            }            
            throw new Exception("Modifying Object has problem");
        }
    }
}
