using CQRS_Assignment.Service.DependentInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;

namespace CQRS_Assignment.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IQueriesService _queries;
        private readonly ICommandService _commands;

        public EmployeesController(IQueriesService queries, ICommandService commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return (await _queries.GetAllEmployees()).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return (await _queries.GetEmployeeById(id));
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddEmployee([FromBody] Employee employee)
        {
            return (await _commands.AddEmployee(employee));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateEmployee([FromBody] Employee employee)
        {
            return (await _commands.UpdateEmployee(employee));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveAllEmployees()
        {
            return (await _commands.RemoveAllEmployees());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> RemoveEmployeeById(int id)
        {
            return (await _commands.RemoveEmployeeById(id));
        }

    }
}
