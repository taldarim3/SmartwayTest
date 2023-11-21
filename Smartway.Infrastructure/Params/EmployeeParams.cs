using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace Smartway.Infrastructure.Params;

public static class EmployeeParams
{
    internal static object GetUpdateParams(this Employee existedEmployee, UpdateEmployee updatedEmployee, int id) => new
    {
        Name = updatedEmployee.Name ?? existedEmployee.Name,
        Surname = updatedEmployee.Surname ?? existedEmployee.Surname,
        Phone = updatedEmployee.Phone ?? existedEmployee.Phone,
        CompanyId = updatedEmployee.CompanyId ?? existedEmployee.CompanyId,
        PassportNumber = updatedEmployee.PassportNumber ?? existedEmployee.Passport.Number,
        Type = updatedEmployee.Type ?? existedEmployee.Passport.Type,
        DepartmentId = updatedEmployee.DepartmentId?? existedEmployee.DepartmentId,
        Id = id
    };

    internal static object GetAddParam(this AddEmployee employee) => new
    {
        Name = employee.Name,
        Surname = employee.Surname,
        Phone = employee.Phone,
        CompanyId = employee.CompanyId,
        PassportNumber = employee.Passport.Number,
        Type = employee.Passport.Type,
        DepartmentId = employee.DepartmentId,
    };
}