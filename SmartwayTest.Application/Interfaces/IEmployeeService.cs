using SmartwayTest.Application.Models;
using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// Добавление нового сотрудника.
    /// </summary>
    /// <param name="request">Запрос с полями для создания сотрудника.</param>
    /// <returns>Id созданного сотрудника</returns>
    Task<int> AddEmployeeAsync(AddEmployee request, CancellationToken token);

    /// <summary>
    /// Получение сотрудников по Id компании.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <returns>Перечисление сотрудников.</returns>
    Task<IEnumerable<Employee>> GetByCompanyIdAsync(int companyId, CancellationToken token);

    /// <summary>
    /// Получение сотрудников по названию отдела.
    /// </summary>
    /// <param name="departmentName">Название отдела.</param>
    /// <returns>Перечисление сотрудников.</returns>
    Task<IEnumerable<Employee>> GetByDepartmentNameAsync(string departmentName, CancellationToken token);

    /// <summary>
    /// Обновление сотрудника по Id.
    /// </summary>
    /// <param name="id">Id обновляемого сотрудника.</param>
    /// <param name="request">Значение полей для обновления</param>
    /// <returns>Id обновлённого сотрудника</returns>
    Task<int> UpdateEmployeeAsync(int id, UpdateEmployee request, CancellationToken token);

    /// <summary>
    /// Удаление сотрудника по Id.
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>0 - сотрудник не удален, 1 - сотрудник удален</returns>
    Task<int> DeleteEmployeeAsync(int id, CancellationToken token);
}