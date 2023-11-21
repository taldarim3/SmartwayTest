using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Models;
/// <summary>
/// DTO для добавления нового сотрудника
/// </summary>
public class AddEmployee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
    public Passport Passport { get; set; }
    public int DepartmentId { get; set; }
}