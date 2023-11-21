using Microsoft.AspNetCore.Mvc;
using SmartwayTest.Application.Interfaces;
using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace SmartwwayTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController  : ControllerBase
{
    private readonly IEmployeeService _service;
    
    public EmployeeController(IEmployeeService service) => _service = service;

    /// <summary>
    ///  Добавление сотрудника
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<int>> AddEmployeeAsync([FromBody] AddEmployee employeeRequest, CancellationToken token)
    {
        var id = await _service.AddEmployeeAsync(employeeRequest, token);
        return Ok(id);
    }
    
    /// <summary>
    /// Получение сотрудника по идентификатору компании
    /// </summary>
    [HttpGet("{companyId:int}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByCompanyAsync(int companyId, CancellationToken token)
    {
        var employees = await _service.GetByCompanyIdAsync(companyId, token);
        return Ok(employees);
    }
    
    /// <summary>
    /// Получение сотрудника по названию отдела
    /// </summary>
    [HttpGet("{departmentName}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByDepartmentAsync(string departmentName, CancellationToken token)
    {
        var employees = await _service.GetByDepartmentNameAsync(departmentName, token);
        return Ok(employees);
    }

    /// <summary>
    /// Удаление сотрудника по идентификатору
    /// </summary>
    [HttpDelete]
    public async Task<ActionResult<int>> DeleteEmployeeAsync(int id, CancellationToken token)
    {
        var deletedId = await _service.DeleteEmployeeAsync(id, token);
        return Ok(deletedId);
    }

    /// <summary>
    /// Обновление сотрудника по идентификатору 
    /// </summary>
    [HttpPatch]
    public async Task<ActionResult<int>> UpdateEmployeeAsync(int id, [FromBody] UpdateEmployee request, CancellationToken token)
    {
        var updatedId = await _service.UpdateEmployeeAsync(id, request, token);
        return Ok(updatedId);
    }
    
}