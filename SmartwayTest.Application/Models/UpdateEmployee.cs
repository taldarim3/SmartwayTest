using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Models;
/// <summary>
/// DTO для изменения имеющегося сотрудника
/// </summary>
public class UpdateEmployee
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
    public int? CompanyId { get; set; }
    public string? PassportNumber { get; set; }
    public string? Type { get; set; }
    public int? DepartmentId { get; set; }
}