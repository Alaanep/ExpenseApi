using ErrorOr;
using RestApi.Models;

namespace RestApi.Services
{
    public interface IIncomeService
    {
        ErrorOr<Created> CreateIncome(Income income);
        ErrorOr<Income> GetIncome(Guid id);
        ErrorOr<UpsertedIncome> UpsertIncome(Income income);
        ErrorOr<Deleted> DeleteIncome(Guid id);
    }
}