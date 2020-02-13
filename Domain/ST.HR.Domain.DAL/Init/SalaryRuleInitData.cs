using System.Collections.Generic;
using ST.HR.Domain.Common;
using ST.HR.Domain.Entities;

namespace ST.HR.Domain.DAL.Init
{
    public static class SalaryRuleInitData
    {
        public static List<SalaryRule> Get()
        {
            return new List<SalaryRule>()
            {
                new SalaryRule()
                {
                    Id = (int) EmployeeGroup.Employee,
                    YearPremium = 3,
                    YearPremiumMax = 30,
                    SubordinatePremium = 0,
                    SubordinateLevelMax = 0
                },
                
                new SalaryRule()
                {
                    Id = (int) EmployeeGroup.Manager,
                    YearPremium = 5,
                    YearPremiumMax = 40,
                    SubordinatePremium = 0.5,
                    SubordinateLevelMax = 1
                },
                
                new SalaryRule()
                {
                    Id = (int) EmployeeGroup.Salesman,
                    YearPremium = 1,
                    YearPremiumMax = 35,
                    SubordinatePremium = 0.3,
                    SubordinateLevelMax = -1
                }
            };
        }
    }
}