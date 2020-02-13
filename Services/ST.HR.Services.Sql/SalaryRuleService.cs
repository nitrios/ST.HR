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
    public class SalaryRuleService : ISalaryRuleService
    {
        private HrContext _context;
        
        public SalaryRuleService(HrContext context)
        {
            _context = context;
        }
        
        public List<SalaryRule> Get()
        {
            return GetAsync().Result;
        }

        public async Task<List<SalaryRule>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SalaryRules
                .OrderBy(e => e.Id)
                .Take(100)
                .ToListAsync(cancellationToken);
        }

        public SalaryRule Get(long id)
        {
            return GetAsync(id).Result;
        }

        public async Task<SalaryRule> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _context.SalaryRules
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
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

        public long Save(SalaryRule salaryRule)
        {
            return SaveAsync(salaryRule).Result;
        }

        public async Task<long> SaveAsync(SalaryRule salaryRule, CancellationToken cancellationToken = default)
        {
            if (salaryRule.Id != 0)
            {
                _context.Attach(salaryRule);
            }
            else
            {
                _context.Add(salaryRule);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return salaryRule.Id;
        }

        public void Delete(long id)
        {
            DeleteAsync(id).Wait();
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = await _context.SalaryRules.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            
            if (employee == null)
                return;

            _context.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}