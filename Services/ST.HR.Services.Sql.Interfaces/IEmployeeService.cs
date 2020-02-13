using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ST.HR.Domain.Entities;

namespace ST.HR.Services.Sql.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> Get();

        Task<List<Employee>> GetAsync(CancellationToken cancellationToken = default);

        Employee Get(long id);

        Task<Employee> GetAsync(long id, CancellationToken cancellationToken = default);
        
        List<Employee> GetSubordinate(long headId);

        Task<List<Employee>> GetSubordinateAsync(long headId, CancellationToken cancellationToken = default);
        
        Employee GetByPasswordHash(string name, string passwordHash);

        Task<Employee> GetByPasswordHashAsync(string name, string passwordHash, CancellationToken cancellationToken = default);

        long Save(Employee employee);

        Task<long> SaveAsync(Employee employee, CancellationToken cancellationToken = default);

        void Delete(long id);

        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}