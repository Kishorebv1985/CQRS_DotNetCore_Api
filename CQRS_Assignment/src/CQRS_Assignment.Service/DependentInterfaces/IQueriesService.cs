using CQRS_Assignment.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_Assignment.Service.DependentInterfaces
{
    public interface IQueriesService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}
