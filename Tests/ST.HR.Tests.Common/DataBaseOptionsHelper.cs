using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ST.HR.Domain.DAL;
using ST.HR.Domain.DAL.Init;

namespace ST.HR.Tests.Common
{
    public static class DataBaseOptionsHelper
    {
        public static DbContextOptions<HrContext> GetMemoryDbContextOptions()
        {
            var rnd = new Random();
            var databaseName = Guid.NewGuid().ToString() + rnd.Next();
            return GetMemoryDbContextOptions(databaseName);
        }
        
        public static DbContextOptions<HrContext> GetMemoryDbContextOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<HrContext>()
                .UseInMemoryDatabase(databaseName)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        public static void FillDatabase(HrContext context)
        {
            context.AddRange(EmployeeInitData.Get());
            context.AddRange(SalaryRuleInitData.Get());
            
            context.SaveChanges();
        }
    }
}