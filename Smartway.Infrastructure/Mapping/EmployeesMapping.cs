using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace Smartway.Infrastructure.Mapping;

public static class EmployeesMapping
{
    public static Employee Map(Employee employee, Passport passport, Department department)
    {
        employee.DepartmentId = department.Id;
        employee.Passport = passport;
        employee.Department = department;   
        
        return employee;
    }
}