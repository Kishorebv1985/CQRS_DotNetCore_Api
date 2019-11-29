using System;
using System.Threading.Tasks;
using CQRS_Assignment.Service.DependentInterfaces;
using CQRS_Assignment.Service.Entities;

namespace CQRS_Assignment.Repository
{
    public class EmployeeWriteOnlyRepository : IEmployeeWriteOnlyRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeWriteOnlyRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddEmployee(EmployeeEntity employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeEntity employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RemoveEmployee(EmployeeEntity employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
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
                _context.Employees.RemoveRange(_context.Employees);
                await _context.SaveChangesAsync();
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
