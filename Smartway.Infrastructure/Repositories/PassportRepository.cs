using System.Data;
using Dapper;
using Npgsql;
using Smartway.Infrastructure.Mapping;
using Smartway.Infrastructure.Queries.Passport;
using SmartwayTest.Application.Interfaces;
using SmartwayTest.Domain.Entities;

namespace Smartway.Infrastructure.Services;

public class PassportRepository : IPassportRepository
{
    private readonly string _connectionString;

    public PassportRepository(string connectionString) => _connectionString = connectionString;

    public async Task<int> AddPassport(Passport passport, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        var number = await dbConnection.QuerySingleAsync<int>(
            new CommandDefinition(PassportQueries.InsertQuery,
                new
                {
                    PassportNumber = passport.Number,
                    Type = passport.Type
                }, cancellationToken: token));

        return number;
    }

    public async Task<int> DeletePassport(string passportNumber, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        return await dbConnection.ExecuteAsync(
            new CommandDefinition(
            PassportQueries.DeleteQuery, 
            new { Number = passportNumber },
            cancellationToken: token));
    }

    public async Task<string> UpdatePassport(Passport passport, CancellationToken token)
    {
        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        return await dbConnection.QuerySingleAsync<string>(
            new CommandDefinition(
            PassportQueries.UpdateQuery, new
        {
            PassportNumber = passport.Type,
            Type = passport.Type
            
        }, cancellationToken: token));
    }
}