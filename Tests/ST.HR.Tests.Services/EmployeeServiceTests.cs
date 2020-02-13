using System.Linq;
using ST.HR.Domain.DAL;
using ST.HR.Domain.DAL.Init;
using ST.HR.Services.Sql;
using ST.HR.Tests.Common;
using Xunit;

namespace ST.HR.Domain.Tests
{
    public class EmployeeServiceTests
    {
        private readonly HrContext _context;

        public EmployeeServiceTests()
        {
            _context = new HrContext(DataBaseOptionsHelper.GetMemoryDbContextOptions());
            DataBaseOptionsHelper.FillDatabase(_context);
        }

        [Fact]
        public void Get_Test()
        {
            var service = new EmployeeService(_context);

            var data = EmployeeInitData.Get();
            
            var employees = service.Get();
            
            Assert.Equal(data.Count, employees.Count());
        }

        [Fact]
        public void Get_Id_Test()
        {
            const long employeeId = 3;
            
            var service = new EmployeeService(_context);

            var data = EmployeeInitData.Get().FirstOrDefault(e => e.Id == employeeId);
            
            var employee = service.Get(employeeId);
            
            Assert.NotNull(data);
            Assert.NotNull(employee);
            Assert.True(data.Equals(employee));
        }
    }
}