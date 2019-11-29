using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;
using CQRS_Assignment.Service.Queries;
using CQRS_Assignment.Web.Controllers;
using FakeItEasy;
using Xunit;

namespace CQRS_Assignment.Web.Tests
{
    public class EmployeesControllerTests
    {
        private readonly Fake<IQueriesService> _fakeQueries;
        private readonly Fake<ICommandService> _fakeCommands;
        private readonly EmployeesController _controller;

        public EmployeesControllerTests()
        {
            _fakeQueries = new Fake<IQueriesService>();
            _fakeCommands = new Fake<ICommandService>();
            _controller = new EmployeesController(_fakeQueries.FakedObject, _fakeCommands.FakedObject);
        }

        [Fact]
        public async Task test_GetAllEmployees()
        {
            _fakeQueries.CallsTo(r => r.GetAllEmployees()).WithAnyArguments().Returns(new List<Employee>() { new Employee() { Id = 1, Name = "user1", Department = "dept1" } });

            var result = await _controller.Get();

            _fakeQueries.CallsTo(r => r.GetAllEmployees()).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value.Count() == 1);
        }

        [Fact]
        public async Task test_GetEmployeeById()
        {
            _fakeQueries.CallsTo(r => r.GetEmployeeById(1)).WithAnyArguments().Returns(new Employee() { Id = 1, Name = "user1", Department = "dept1" });

            var result = await _controller.GetById(1);

            _fakeQueries.CallsTo(r => r.GetEmployeeById(1)).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value.Id == 1);
        }


        [Fact]
        public async Task test_AddEmployee()
        {
            _fakeCommands.CallsTo(r => r.AddEmployee(new Employee())).WithAnyArguments().Returns(true);

            var result = await _controller.AddEmployee(new Employee());

            _fakeCommands.CallsTo(r => r.AddEmployee(new Employee())).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value);
        }

        [Fact]
        public async Task test_UpdateEmployee()
        {
            _fakeCommands.CallsTo(r => r.UpdateEmployee(new Employee())).WithAnyArguments().Returns(true);

            var result = await _controller.UpdateEmployee(new Employee());

            _fakeCommands.CallsTo(r => r.UpdateEmployee(new Employee())).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value);
        }

        [Fact]
        public async Task test_RemoveEmployeeById()
        {
            _fakeCommands.CallsTo(r => r.RemoveEmployeeById(1)).WithAnyArguments().Returns(true);

            var result = await _controller.RemoveEmployeeById(1);

            _fakeCommands.CallsTo(r => r.RemoveEmployeeById(1)).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value);
        }

        [Fact]
        public async Task test_RemoveAllEmployees()
        {
            _fakeCommands.CallsTo(r => r.RemoveAllEmployees()).WithAnyArguments().Returns(true);

            var result = await _controller.RemoveAllEmployees();

            _fakeCommands.CallsTo(r => r.RemoveAllEmployees()).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Value);
        }
    }
}
