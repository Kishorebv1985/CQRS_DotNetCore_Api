using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.Commands;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;
using FakeItEasy;
using Xunit;

namespace CQRS_Assignment.Service.Tests
{
    public class CommandServiceTests
    {
        private readonly Fake<IEmployeeWriteOnlyRepository> _fakeRepo;
        private readonly CommandService _commandService;

        public CommandServiceTests()
        {
            _fakeRepo = new Fake<IEmployeeWriteOnlyRepository>();
            _commandService = new CommandService(_fakeRepo.FakedObject);
        }

        [Fact]
        public async Task test_AddEmployee()
        {
            _fakeRepo.CallsTo(r => r.AddEmployee(new EmployeeEntity())).WithAnyArguments().Returns(true);

            var result = await _commandService.AddEmployee(new Employee());

            _fakeRepo.CallsTo(r => r.AddEmployee(new EmployeeEntity())).WithAnyArguments().MustHaveHappened();
            Assert.True(result);
        }

        [Fact]
        public async Task test_UpdateEmployee()
        {
            _fakeRepo.CallsTo(r => r.UpdateEmployee(new EmployeeEntity())).WithAnyArguments().Returns(true);

            var result = await _commandService.UpdateEmployee(new Employee());

            _fakeRepo.CallsTo(r => r.UpdateEmployee(new EmployeeEntity())).WithAnyArguments().MustHaveHappened();
            Assert.True(result);
        }

        [Fact]
        public async Task test_RemoveEmployeeById()
        {
            _fakeRepo.CallsTo(r => r.RemoveEmployee(new EmployeeEntity())).WithAnyArguments().Returns(true);

            var result = await _commandService.RemoveEmployeeById(1);

            _fakeRepo.CallsTo(r => r.RemoveEmployee(new EmployeeEntity())).WithAnyArguments().MustHaveHappened();
            Assert.True(result);
        }

        [Fact]
        public async Task test_RemoveAllEmployees()
        {
            _fakeRepo.CallsTo(r => r.RemoveAllEmployees()).WithAnyArguments().Returns(true);

            var result = await _commandService.RemoveAllEmployees();

            _fakeRepo.CallsTo(r => r.RemoveAllEmployees()).WithAnyArguments().MustHaveHappened();
            Assert.True(result);
        }
    }
}
