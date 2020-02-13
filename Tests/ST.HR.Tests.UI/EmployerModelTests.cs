using ST.HR.Domain.DAL;
using ST.HR.Tests.Common;
using Xunit;

namespace ST.HR.Tests.UI
{
    public class EmployerModelTests
    {
        private readonly HrContext _context;

        public EmployerModelTests()
        {
            _context = new HrContext(DataBaseOptionsHelper.GetMemoryDbContextOptions());
            DataBaseOptionsHelper.FillDatabase(_context);
        }

        [Fact]
        public void Generate_Test()
        {
            
        }
    }
}