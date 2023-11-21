using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Interfaces;

public interface IPassportRepository
{

    /// <summary>
    /// Добавление паспорта в базу данных.
    /// </summary>
    /// <param name="passport">Объект паспорта.</param>
    /// <returns>Номер добавленного паспорта</returns>
    Task<int> AddPassport(Passport passport, CancellationToken token);

    /// <summary>
    /// Удаление паспорта из базы данных.
    /// </summary>
    /// <param name="passportNumber">Номер паспорта</param>
    /// <returns>0 - паспорт не удален, 1 - паспорт удален.</returns>
    Task<int> DeletePassport(string passportNumber, CancellationToken token);

    /// <summary>
    /// Изменение типа паспорта.
    /// </summary>
    /// <param name="passport">Объект паспорта.</param>
    /// <returns>Id измененного паспорта</returns>
    Task<string> UpdatePassport(Passport passport, CancellationToken token);
}