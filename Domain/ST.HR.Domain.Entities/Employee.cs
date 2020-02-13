using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ST.HR.Domain.Common;
using ST.HR.Domain.Common.Base;

namespace ST.HR.Domain.Entities
{
    public class Employee : DataEntity
    {
        public string FullName { get; set; }
        
        public DateTime EmploymentDate { get; set; }
            
        public EmployeeGroup Group { get; set; }
        
        public double BaseSalaryRate { get; set; }
        
        [ForeignKey("Id")]
        public long HeadId { get; set; }
        
        public string UserName { get; set; }
        
        public string PasswordHash { get; set; }

        public bool Administrator { get; set; }

        public override bool Equals(object? obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case Employee employee:
                    return Equals(employee);
                default:
                    return false;
            }
        }

        protected bool Equals(Employee other)
        {
            return Id == other.Id
                    && FullName == other.FullName 
                   && EmploymentDate.Equals(other.EmploymentDate) 
                   && Group == other.Group 
                   && BaseSalaryRate.Equals(other.BaseSalaryRate) 
                   && HeadId == other.HeadId
                   && UserName == other.UserName 
                   && PasswordHash == other.PasswordHash 
                   && Administrator == other.Administrator;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(FullName);
            hashCode.Add(EmploymentDate);
            hashCode.Add((int) Group);
            hashCode.Add(BaseSalaryRate);
            hashCode.Add(HeadId);
            hashCode.Add(UserName);
            hashCode.Add(PasswordHash);
            hashCode.Add(Administrator);

            return hashCode.ToHashCode();
        }
    }
}