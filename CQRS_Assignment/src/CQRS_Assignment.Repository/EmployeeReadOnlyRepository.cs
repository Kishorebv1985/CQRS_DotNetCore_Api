using CQRS_Assignment.Service.DependentInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CQRS_Assignment.Common.Models;
using CQRS_Assignment.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Assignment.Repository
{
    public class EmployeeReadOnlyRepository : IEmployeeReadOnlyRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeReadOnlyRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
