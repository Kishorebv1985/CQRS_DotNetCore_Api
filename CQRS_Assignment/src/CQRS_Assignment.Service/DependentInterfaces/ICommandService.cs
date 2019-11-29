using CQRS_Assignment.Common.Models;
using System.Threading.Tasks;

namespace CQRS_Assignment.Service.DependentInterfaces
{
    public interface ICommandService
    {
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> RemoveEmployeeById(int id);
        Task<bool> RemoveAllEmployees();
    }
}
