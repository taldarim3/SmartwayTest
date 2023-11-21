using System.Data;
using Dapper;
using Npgsql;
using Smartway.Infrastructure.Mapping;
using Smartway.Infrastructure.Params;
using Smartway.Infrastructure.Queries.Employees;
using SmartwayTest.Application.Interfaces;
using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace Smartway.Infrastructure.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;

    public EmployeeRepository(string connectionString) => _connectionString = connectionString;

    public async Task<int> AddEmployee(AddEmployee employee, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        
        var id = await dbConnection.QuerySingleAsync<int>(new CommandDefinition(
            EmployeesQueries.InsertQuery, 
            new
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                CompanyId = employee.CompanyId,
                PassportNumber = employee.Passport.Number,
                Type = employee.Passport.Type,
                DepartmentId = employee.DepartmentId, 
            },
            cancellationToken: token));
        
        return id;
    }

    public async Task<string> DeleteEmployee(int employeeId, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        return await dbConnection.QuerySingleAsync<string>(
            new CommandDefinition(EmployeesQueries.DeleteByIdQuery, new { Id = employeeId },
                cancellationToken: token));
    }

    public async Task<IEnumerable<Employee>> GetByCompanyId(int companyId, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        
        var employees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>(
            new CommandDefinition(EmployeesQueries.SelectByCompanyIdQuery, new {CompanyId = companyId},
                cancellationToken: token),
             map: EmployeesMapping.Map, splitOn:"Number, Id");
        
        return employees;
    }

    public async Task<IEnumerable<Employee>> GetByDepartment(string departmentName, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        
        var employees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>(
            new CommandDefinition(EmployeesQueries.SelectByDepartmentNameQuery, new { DepartmentName = departmentName },
                cancellationToken: token),
            map: EmployeesMapping.Map,
            splitOn:"Number, Id");
        
        return employees;
    }

    public async Task<int> UpdateEmployee(Employee existedEmployee, UpdateEmployee employee, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        
        await dbConnection.ExecuteAsync(EmployeesQueries.UpdateQuery,
            new
            {
                Name = employee.Name ?? existedEmployee.Name,
                Surname = employee.Surname ?? existedEmployee.Surname,
                Phone = employee.Phone ?? existedEmployee.Phone,
                CompanyId = employee.CompanyId ?? existedEmployee.CompanyId,
                PassportNumber = employee.PassportNumber ?? existedEmployee.Passport.Number,
                Type = employee.Type ?? existedEmployee.Passport.Type,
                DepartmentId = employee.DepartmentId?? existedEmployee.DepartmentId,
                Id = existedEmployee.Id
            });

        return existedEmployee.Id;
    }

    public async Task<Employee> GetById(int employeeId, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        var existedEmployees = await dbConnection.QueryAsync<Employee, Passport, Department, Employee>(
            new CommandDefinition(EmployeesQueries.GetEmployeeByIdQuery, new { Id = employeeId },
                cancellationToken: token),
            map: EmployeesMapping.Map,
            splitOn: "Number, Id");

        return existedEmployees.SingleOrDefault(); 
    }
}