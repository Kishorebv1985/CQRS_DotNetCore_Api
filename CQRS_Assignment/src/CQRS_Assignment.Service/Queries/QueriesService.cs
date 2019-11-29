using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;
using Microsoft.Extensions.Configuration;

namespace CQRS_Assignment.Service.Queries
{
    public class QueriesService : IQueriesService
    {
        private readonly IEmployeeReadOnlyRepository _employeeReadOnlyRepository;

        public QueriesService(IEmployeeReadOnlyRepository employeeReadOnlyRepository)
        {
            _employeeReadOnlyRepository = employeeReadOnlyRepository ?? throw new ArgumentNullException(nameof(employeeReadOnlyRepository));
        }


        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _employeeReadOnlyRepository.GetAllEmployees();
            return employees?.Select(e => new Employee()
            {
                Id = e.Id,
                Name = e.Name,
                Department = e.Department
            }).ToList();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _employeeReadOnlyRepository.GetEmployeeById(id);
            return employee != null
                ? new Employee() { Id = employee.Id, Name = employee.Name, Department = employee.Department }
                : null;
        }
    }
}
