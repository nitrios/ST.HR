using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ST.HR.Domain.Entities;

namespace ST.HR.Services.Sql.Interfaces
{
    public interface ISalaryRuleService
    {
        List<SalaryRule> Get();

        Task<List<SalaryRule>> GetAsync(CancellationToken cancellationToken = default);

        SalaryRule Get(long id);

        Task<SalaryRule> GetAsync(long id, CancellationToken cancellationToken = default);
        
        long Save(SalaryRule salaryRule);

        Task<long> SaveAsync(SalaryRule salaryRule, CancellationToken cancellationToken = default);

        void Delete(long id);

        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}