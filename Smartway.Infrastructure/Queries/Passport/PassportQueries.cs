namespace Smartway.Infrastructure.Queries.Passport;

public class PassportQueries
{
    public static string InsertQuery =>
        @"insert into public.""Passport""(Number, Type) values (@PassportNumber, @Type) returning Number;";
    
    public static string DeleteQuery =>
        @"delete from public.""Passport"" where Number = @Number;";
    
    public static string GetPassportByNumberQuery => 
        @"select * from public.""Passport"" where Number = @Number;";

    public static string UpdateQuery =>
        @"insert into public.""Passport""
          values (@PassportNumber, @Type)
          on conflict (Number)
          do update set Type = @Type
          returning Number;";

}