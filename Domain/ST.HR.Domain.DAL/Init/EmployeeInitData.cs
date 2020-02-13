using System;
using System.Collections.Generic;
using ST.HR.Common.Tools;
using ST.HR.Domain.Common;
using ST.HR.Domain.Entities;

namespace ST.HR.Domain.DAL.Init
{
    public static class EmployeeInitData
    {
        public static List<Employee> Get()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Group = EmployeeGroup.Manager,
                    EmploymentDate = DateTime.Today,
                    FullName = "Administrator",
                    UserName = "Admin",
                    PasswordHash = HashHelper.GenerateHash("admin"),
                    Administrator = true,
                    BaseSalaryRate = 50.1,
                    HeadId = 0,
                },

                new Employee()
                {
                    Id = 2,
                    Group = EmployeeGroup.Manager,
                    EmploymentDate = DateTime.Today,
                    FullName = "User U. A.",
                    UserName = "user1",
                    PasswordHash = HashHelper.GenerateHash("111"),
                    Administrator = false,
                    BaseSalaryRate = 10.0,
                    HeadId = 0,
                },

                new Employee()
                {
                    Id = 3,
                    Group = EmployeeGroup.Employee,
                    EmploymentDate = DateTime.Today,
                    FullName = "User GU. GA.",
                    UserName = "user2",
                    PasswordHash = HashHelper.GenerateHash("222"),
                    Administrator = false,
                    BaseSalaryRate = 20.0,
                    HeadId = 2,
                },

                new Employee()
                {
                    Id = 4,
                    Group = EmployeeGroup.Employee,
                    EmploymentDate = DateTime.Today,
                    FullName = "User RU. RA.",
                    UserName = "user3",
                    PasswordHash = HashHelper.GenerateHash("333"),
                    Administrator = false,
                    BaseSalaryRate = 20.0,
                    HeadId = 2,
                },

                new Employee()
                {
                    Id = 5,
                    Group = EmployeeGroup.Manager,
                    EmploymentDate = DateTime.Today,
                    FullName = "User With Sub Employees",
                    UserName = "user4",
                    PasswordHash = HashHelper.GenerateHash("444"),
                    Administrator = false,
                    BaseSalaryRate = 10.0,
                    HeadId = 2,
                },

                new Employee()
                {
                    Id = 6,
                    Group = EmployeeGroup.Employee,
                    EmploymentDate = DateTime.Today,
                    FullName = "Sub SUB Employees",
                    UserName = "user5",
                    PasswordHash = HashHelper.GenerateHash("555"),
                    Administrator = false,
                    BaseSalaryRate = 10.0,
                    HeadId = 5,
                },

                new Employee()
                {
                    Id = 7,
                    Group = EmployeeGroup.Salesman,
                    EmploymentDate = DateTime.Today,
                    FullName = "Salesman Man Sales",
                    UserName = "user6",
                    PasswordHash = HashHelper.GenerateHash("666"),
                    Administrator = false,
                    BaseSalaryRate = 25.0,
                    HeadId = 0,
                },

                new Employee()
                {
                    Id = 8,
                    Group = EmployeeGroup.Salesman,
                    EmploymentDate = DateTime.Today,
                    FullName = "Salesman Sub Man Sales",
                    UserName = "user6",
                    PasswordHash = HashHelper.GenerateHash("666"),
                    Administrator = false,
                    BaseSalaryRate = 25.0,
                    HeadId = 7,
                },

                new Employee()
                {
                    Id = 9,
                    Group = EmployeeGroup.Salesman,
                    EmploymentDate = DateTime.Today,
                    FullName = "Salesman Sub Man Sales",
                    UserName = "user7",
                    PasswordHash = HashHelper.GenerateHash("777"),
                    Administrator = false,
                    BaseSalaryRate = 25.0,
                    HeadId = 8,
                }
            };
        }
    }
}