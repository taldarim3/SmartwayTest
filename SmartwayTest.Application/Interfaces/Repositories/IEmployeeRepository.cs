using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Interfaces;

public interface IEmployeeRepository
{
    /// <summary>
    /// Добавление сотрудника в базу данных
    /// </summary>
    /// <param name="employee">Объект сотрудника</param>
    /// <returns>Id добавленного сотрудника</returns>
    Task<int> AddEmployee(AddEmployee employee, CancellationToken token);

    /// <summary>
    /// Удаление сотрудника из базы данных
    /// </summary>
    /// <param name="employeeId">Id сотрудника</param>
    /// <returns>Номер паспорта удаленного сотрудника</returns>
    Task<string> DeleteEmployee(int employeeId, CancellationToken token);

    /// <summary>
    /// Получение сотрудника по идентификатору компании
    /// </summary>
    /// <param name="companyId">Id компании</param>
    /// <returns>Перечисление сотрудников</returns>
    Task<IEnumerable<Employee>> GetByCompanyId(int companyId, CancellationToken token);
    
    /// <summary>
    /// Получение сотрудника по названию отдела
    /// </summary>
    /// <param name="departmentName">Название отдела</param>
    /// <returns>Перечисление сотрудников</returns>
    Task<IEnumerable<Employee>> GetByDepartment(string departmentName, CancellationToken token);
    
    /// <summary>
    /// Изменение существующего сотрудника
    /// </summary>
    /// <param name="existedEmployee">Объект изменяемого сотрудника</param>
    /// <param name="employee">Объект c изменениями сотрудника</param>
    /// <returns>Id изменяемого сотрудника</returns>
    Task<int> UpdateEmployee(Employee existedEmployee, UpdateEmployee employee, CancellationToken token);
    
    /// <summary>
    /// Получение сотрудника по идентификатору
    /// </summary>
    /// <param name="employeeId">Id сотрудника</param>
    /// <returns>Перечисление сотрудников</returns>
    Task<Employee> GetById(int employeeId, CancellationToken token);
}