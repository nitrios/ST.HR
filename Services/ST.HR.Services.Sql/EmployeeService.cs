using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ST.HR.Domain.DAL;
using ST.HR.Domain.Entities;
using ST.HR.Services.Sql.Interfaces;

namespace ST.HR.Services.Sql
{
    public class EmployeeService : IEmployeeService
    {
        private HrContext _context;
        
        public EmployeeService(HrContext context)
        {
            _context = context;
        }
        
        public List<Employee> Get()
        {
            return GetAsync().Result;
        }

        public async Task<List<Employee>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Employees
                .OrderBy(e => e.Id)
                .Take(100)
                .ToListAsync(cancellationToken);
        }

        public Employee Get(long id)
        {
            return GetAsync(id).Result;
        }

        public async Task<Employee> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public List<Employee> GetSubordinate(long headId)
        {
            return GetSubordinateAsync(headId).Result;
        }

        public async Task<List<Employee>> GetSubordinateAsync(long headId, CancellationToken cancellationToken = default)
        {
            return await _context.Employees
                .Where(e => e.HeadId == headId)
                .ToListAsync(cancellationToken);
        }

        public Employee GetByPasswordHash(string name, string passwordHash)
        {
            return GetByPasswordHashAsync(name, passwordHash).Result;
        }

        public async Task<Employee> GetByPasswordHashAsync(string name, string passwordHash, CancellationToken cancellationToken = default)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.UserName == name && e.PasswordHash == passwordHash, cancellationToken);
        }

        public long Save(Employee employee)
        {
            return SaveAsync(employee).Result;
        }

        public async Task<long> SaveAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            if (employee.Id != 0)
            {
                _context.Attach(employee);
            }
            else
            {
                _context.Add(employee);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

        public void Delete(long id)
        {
            DeleteAsync(id).Wait();
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            
            if (employee == null)
                return;

            _context.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}