using System;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;

namespace CQRS_Assignment.Service.Commands
{
    public class CommandService : ICommandService
    {
        private readonly IEmployeeWriteOnlyRepository _employeeWriteOnlyRepository;

        public CommandService(IEmployeeWriteOnlyRepository employeeWriteOnlyRepository)
        {
            _employeeWriteOnlyRepository = employeeWriteOnlyRepository ?? throw new ArgumentNullException(nameof(_employeeWriteOnlyRepository));
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeWriteOnlyRepository.AddEmployee(new EmployeeEntity() { Name = employee.Name, Department = employee.Department });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                await _employeeWriteOnlyRepository.UpdateEmployee(new EmployeeEntity() { Id = employee.Id, Name = employee.Name, Department = employee.Department });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RemoveEmployeeById(int id)
        {
            try
            {
                await _employeeWriteOnlyRepository.RemoveEmployee(new EmployeeEntity() { Id = id });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RemoveAllEmployees()
        {
            try
            {
                await _employeeWriteOnlyRepository.RemoveAllEmployees();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}
