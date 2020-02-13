using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ST.HR.Domain.Common;
using ST.HR.Domain.Entities;
using ST.HR.Services.Sql.Interfaces;

namespace ST.HR.UI.Data
{
    public class EmployeeModel
    {
        public static async Task<EmployeeModel> CreateInstance(IEmployeeService service, Employee employee)
        {
            if (employee.HeadId != 0)
            {
                var head = await service.GetAsync(employee.HeadId);

                if (head != null)
                    return await CreateInstance(service, employee, new EmployeeModel(head));
            }

            return await CreateInstance(service, employee, null);
        }

        public static async Task<EmployeeModel> CreateInstance(IEmployeeService service, Employee employee,
            EmployeeModel head)
        {
            var instance = new EmployeeModel(employee) {Head = head};

            var subordinate = await service.GetSubordinateAsync(instance.Id);
            instance.Subordinate = new List<EmployeeModel>();

            foreach (var sub in subordinate)
                instance.Subordinate.Add(await CreateInstance(service, sub, instance));

            return instance;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime EmploymentDate { get; set; }

        public EmployeeGroup Group { get; set; }

        public double BaseSalaryRate { get; set; }

        public double YearPremium { get; set; }

        public double SubordinatePremium { get; set; }

        public EmployeeModel Head { get; set; }

        public ICollection<EmployeeModel> Subordinate { get; set; }

        public double Salary { get; set; }

        public bool Calculated { get; set; }

        private EmployeeModel(Employee employee)
        {
            Id = employee.Id;
            Name = employee.FullName;
            EmploymentDate = employee.EmploymentDate;
            Group = employee.Group;
            BaseSalaryRate = employee.BaseSalaryRate;
        }

        public void Calculate(DateTime dateFrom, DateTime dateTo, List<SalaryRule> rules)
        {
            if (Calculated || EmploymentDate > dateTo)
                return;

            var rule = rules.FirstOrDefault(r => r.Id == (int) Group);
            if (rule == null)
                throw new Exception($"{typeof(SalaryRule)} with id {Group} not found");

            if (Math.Abs(rule.SubordinatePremium) > 0.001)
            {
                foreach (var model in Subordinate) 
                    model.Calculate(dateFrom, dateTo, rules);

                if (rule.SubordinateLevelMax != 0)
                {
                    SubordinatePremium =
                        CalculateSubordinate(this, rule.SubordinateLevelMax) * rule.SubordinatePremium / 100;
                }
            }

            var dateStart = EmploymentDate > dateFrom ? EmploymentDate : dateFrom;

            var days = (dateTo - dateStart).TotalDays + 1;

            var years = dateFrom.Year - EmploymentDate.Year;
            if (EmploymentDate.Date > dateFrom.AddYears(-years)) 
                years--;

            YearPremium = Math.Min(rule.YearPremium * years, rule.YearPremiumMax) / 100 * BaseSalaryRate * days;

            Salary = BaseSalaryRate * days + YearPremium + SubordinatePremium;

            Calculated = true;
        }

        private static double CalculateSubordinate(EmployeeModel model, int level)
        {
            var newLevel = level == -1 ? level : level - 1;
            if (newLevel == 0)
                return model.Subordinate.Sum(subModel => subModel.Salary);
            else
                return model.Subordinate.Sum(subModel => subModel.Salary + CalculateSubordinate(subModel, newLevel));
        }
    }
}