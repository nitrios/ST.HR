using ST.HR.Domain.Common.Base;

namespace ST.HR.Domain.Entities
{
    public class SalaryRule : DataEntity
    {
        public double YearPremium { get; set; }
        
        public double YearPremiumMax { get; set; }
        
        public double SubordinatePremium { get; set; }
        
        public int SubordinateLevelMax { get; set; }
    }
}