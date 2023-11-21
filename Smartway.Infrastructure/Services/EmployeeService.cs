using Smartway.Infrastructure.Mapping;
using SmartwayTest.Application.Interfaces;
using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace Smartway.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPassportRepository _passportRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IPassportRepository passportRepository)
    {
        _employeeRepository = employeeRepository;
        _passportRepository = passportRepository;
    }


    public async Task<int> AddEmployeeAsync(AddEmployee request, CancellationToken token)
    {
        var passportNumber = await _passportRepository.AddPassport(request.Passport, token);

        var id = await _employeeRepository.AddEmployee(request, token);

        return id;
    }

    public async Task<IEnumerable<Employee>> GetByCompanyIdAsync(int companyId, CancellationToken token)
    {
        return await _employeeRepository.GetByCompanyId(companyId, token);
    }


    public async Task<IEnumerable<Employee>> GetByDepartmentNameAsync(string departmentName, CancellationToken token)
    {
        return await _employeeRepository.GetByDepartment(departmentName, token);
    }


    public async Task<int> UpdateEmployeeAsync(int id, UpdateEmployee request, CancellationToken token)
    {   
        var existedEmployee = await _employeeRepository.GetById(id, token);

        if (existedEmployee is null) throw new Exception("Сотрудника с указанным id не найдено!");

        var oldPassportNumber = existedEmployee.Passport.Number;

        var isNeedToUpdatePassport = false;
        if (request.PassportNumber is null )
        {
            request.PassportNumber = oldPassportNumber;
        }
        else
        {
            isNeedToUpdatePassport = true;
        }
        if (request.Type is null)
        {
            request.Type = existedEmployee.Passport.Type;
        }
        else
        {
            isNeedToUpdatePassport = true;
        }

        if (isNeedToUpdatePassport)
        {
            await _passportRepository.UpdatePassport(new Passport()
            {
                Number = request.PassportNumber,
                Type = request.Type
            }, token);
        }

        var result = await _employeeRepository.UpdateEmployee(existedEmployee, request, token);

        if (oldPassportNumber != request.PassportNumber)
        {
            await _passportRepository.DeletePassport(oldPassportNumber, token);
        }

        return result;
    }

    public async Task<int> DeleteEmployeeAsync(int id, CancellationToken token)
    {
        try
        {
            var passportNumber = await _employeeRepository.DeleteEmployee(id, token);
            
            await _passportRepository.DeletePassport(passportNumber, token);
        }
        catch (Exception e)
        {
            throw new Exception("Удаление сотрудника с указанным id не удалось!", e);
        }

        return id;
    }
}