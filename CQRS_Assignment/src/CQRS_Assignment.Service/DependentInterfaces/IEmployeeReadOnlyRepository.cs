using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS_Assignment.Service.Entities;

namespace CQRS_Assignment.Service.DependentInterfaces
{
    public interface IEmployeeReadOnlyRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllEmployees();
        Task<EmployeeEntity> GetEmployeeById(int id);
    }
}
