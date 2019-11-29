using System;
using CQRS_Assignment.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace CQRS_Assignment.Repository.Tests
{
    public class EmployeeWriteOnlyRepositoryTests
    {
        [Fact]
        public async Task test_AddEmployee()
        {
            //Assemble
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "in-memory-db")
                .Options;

            bool addResult;
            using (var context = new EmployeeContext(options))
            {
                var writeRepo = new EmployeeWriteOnlyRepository(context);

                //act
                addResult = await writeRepo.AddEmployee(new EmployeeEntity(){Name = "user1", Department = "dept1"});
            }
            
            //Assert
            Assert.True(addResult);
            using (var context = new EmployeeContext(options))
            {
                Assert.True(await context.Employees.AnyAsync(p => p.Id == 1));
            }
        }

        [Fact]
        public async Task test_UpdateEmployee()
        {
            //Assemble
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "in-memory-db")
                .Options;

            bool updateResult;
            using (var context = new EmployeeContext(options))
            {
                var writeRepo = new EmployeeWriteOnlyRepository(context);

                //act
                await writeRepo.AddEmployee(new EmployeeEntity() { Name = "user1", Department = "dept1" });
                updateResult = await writeRepo.UpdateEmployee(new EmployeeEntity() { Id = 1, Name = "user1", Department = "dept2" });
            }

            //Assert
            Assert.True(updateResult);
            using (var context = new EmployeeContext(options))
            {
                Assert.True(await context.Employees.AnyAsync(p => p.Department == "dept2"));
            }
        }
    }
}
