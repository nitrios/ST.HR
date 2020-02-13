using System;
using ST.HR.Domain.DAL;
using ST.HR.Services.Sql;
using ST.HR.Tests.Common;
using ST.HR.UI.Data;
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
            const long employeeId = 7;
            
            var employeeService = new EmployeeService(_context);
            var employee = employeeService.Get(employeeId);

            var model = EmployeeModel.CreateInstance(employeeService, employee).Result;
            Assert.Equal(employee.Id, model.Id);
            Assert.Equal(employee.FullName, model.Name);
            Assert.Equal(employee.EmploymentDate, model.EmploymentDate);
            Assert.Equal(employee.Group, model.Group);
            Assert.Equal(employee.BaseSalaryRate, model.BaseSalaryRate);
        }

        [Fact]
        public void Calculate_Test()
        {
            const long employeeId = 7;
            
            var ruleService = new SalaryRuleService(_context);
            var employeeService = new EmployeeService(_context);

            var rules = ruleService.Get();
            
            var employee = employeeService.Get(employeeId);

            var model = EmployeeModel.CreateInstance(employeeService, employee).Result;
            model.Calculate(DateTime.Today.AddYears(1), DateTime.Today.AddDays(9).AddYears(1), rules);
            
            Assert.True(Math.Abs(254.01722725 - model.Salary) < 0.0001);
            Assert.True(Math.Abs(2.5 - model.YearPremium) < 0.0001);
            Assert.True(Math.Abs(1.5172725 - model.SubordinatePremium) < 0.0001);
        }
    }
}