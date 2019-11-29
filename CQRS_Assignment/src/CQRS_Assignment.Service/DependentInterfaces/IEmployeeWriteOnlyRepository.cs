using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS_Assignment.Service.Entities;

namespace CQRS_Assignment.Service.DependentInterfaces
{
    public interface IEmployeeWriteOnlyRepository
    {
        Task<bool> AddEmployee(EmployeeEntity employee);
        Task<bool> UpdateEmployee(EmployeeEntity employee);
        Task<bool> RemoveEmployee(EmployeeEntity employee);
        Task<bool> RemoveAllEmployees();
    }
}
