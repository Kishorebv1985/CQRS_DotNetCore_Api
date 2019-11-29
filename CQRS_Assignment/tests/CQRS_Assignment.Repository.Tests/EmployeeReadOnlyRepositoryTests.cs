using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_Assignment.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CQRS_Assignment.Repository.Tests
{
    public class EmployeeReadOnlyRepositoryTests
    {

        [Fact]
        public async Task test_GetAllEmployees()
        {
            //Assemble
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "in-memory-read-db")
                .Options;

            IEnumerable<EmployeeEntity> employees;
            using (var context = new EmployeeContext(options))
            {
                var writeRepo = new EmployeeWriteOnlyRepository(context);
                //act
                await writeRepo.AddEmployee(new EmployeeEntity() { Name = "user1", Department = "dept1" });
            }

            using (var context = new EmployeeContext(options))
            {
                var readRepo = new EmployeeReadOnlyRepository(context);
                employees = await readRepo.GetAllEmployees();
            }

            //Assert
            Assert.True(employees.Count() == 1);
        }

        [Fact]
        public async Task test_GetEmployeeById()
        {
            //Assemble
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "in-memory-read-db-2")
                .Options;

            EmployeeEntity employee;
            using (var context = new EmployeeContext(options))
            {
                var writeRepo = new EmployeeWriteOnlyRepository(context);
                //act
                await writeRepo.AddEmployee(new EmployeeEntity() { Name = "user2", Department = "dept2" });
            }

            using (var context = new EmployeeContext(options))
            {
                var readRepo = new EmployeeReadOnlyRepository(context);
                employee = await readRepo.GetEmployeeById(2);
            }

            //Assert
            Assert.True(employee.Name == "user2");
        }
    }
}
