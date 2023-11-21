namespace Smartway.Infrastructure.Queries.Employees;

public static class EmployeesQueries
{
    public static string InsertQuery =>
        @"insert into public.""Employee""(Name, Surname, Phone, CompanyId, PassportNumber, DepartmentId) 
          values (@Name, @Surname, @Phone, @CompanyId, @PassportNumber, @DepartmentId) returning Id;";
          public static string SelectByCompanyIdQuery => 
        @"select e.Id ,
                 e.Name,
                 e.Surname,
                 e.Phone,
                 e.CompanyId,
                 p.Number,
                 p.Type,
                 d.Id,
                 d.Name,
                 d.Phone
          from public.""Employee"" e
          left join public.""Department"" d on e.DepartmentId = d.Id
          left join public.""Passport"" p on e.PassportNumber = p.Number
          where e.CompanyId = @CompanyId;";
    
    public static string SelectByDepartmentNameQuery => 
        @"select e.Id,
                 e.Name,
                 e.Surname,
                 e.Phone,
                 e.CompanyId,
                 p.Number,
                 p.Type,
                 d.Id,
                 d.Name,
                 d.Phone
          from public.""Employee"" e
          left join public.""Department"" d on e.DepartmentId = d.Id
          left join public.""Passport"" p on e.PassportNumber = p.Number
          where d.Name = @DepartmentName;";

    public static string DeleteByIdQuery => 
        @"delete from public.""Employee"" where Id = @Id returning PassportNumber; ";

    public static string GetEmployeeByIdQuery => 
        @"select e.Id,
                 e.Name,
                 e.Surname,
                 e.Phone,
                 e.CompanyId,
                 p.Number,
                 p.Type,
                 d.Id,
                 d.Name,
                 d.Phone
          from public.""Employee"" e
          left join public.""Department"" d on e.DepartmentId = d.Id
          left join public.""Passport"" p on e.PassportNumber = p.Number
          where e.Id = @Id;";

    public static string UpdateQuery => 
        @"update public.""Employee""
          set Name = @Name,
              Surname = @Surname,
              Phone = @Phone,
              CompanyId = @CompanyId,
              PassportNumber = @PassportNumber,
              DepartmentId = @DepartmentId
          where Id = @Id;";
}