using System.Collections.Generic;
using System.Linq;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.Commands;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;
using CQRS_Assignment.Service.Queries;
using FakeItEasy;
using System.Threading.Tasks;
using Xunit;

namespace CQRS_Assignment.Service.Tests
{
    public class QueriesServiceTests
    {
        private readonly Fake<IEmployeeReadOnlyRepository> _fakeRepo;
        private readonly QueriesService _queriesService;

        public QueriesServiceTests()
        {
            _fakeRepo = new Fake<IEmployeeReadOnlyRepository>();
            _queriesService = new QueriesService(_fakeRepo.FakedObject);
        }

        [Fact]
        public async Task test_GetAllEmployees()
        {
            _fakeRepo.CallsTo(r => r.GetAllEmployees()).WithAnyArguments().Returns(new List<EmployeeEntity>() { new EmployeeEntity() { Id = 1, Name = "user1", Department = "dept1" } });

            var result = await _queriesService.GetAllEmployees();

            _fakeRepo.CallsTo(r => r.GetAllEmployees()).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Count() == 1);
        }

        [Fact]
        public async Task test_GetEmployeeById()
        {
            _fakeRepo.CallsTo(r => r.GetEmployeeById(1)).WithAnyArguments().Returns(new EmployeeEntity() { Id = 1, Name = "user1", Department = "dept1" });

            var result = await _queriesService.GetEmployeeById(1);

            _fakeRepo.CallsTo(r => r.GetEmployeeById(1)).WithAnyArguments().MustHaveHappened();
            Assert.True(result?.Id == 1);
        }
    }
}
