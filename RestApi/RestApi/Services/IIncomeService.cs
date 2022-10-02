using ErrorOr;
using RestApi.Models;

namespace RestApi.Services
{
    public interface IIncomeService
    {   
        Task<Income> GetItemAsync(Guid id);
        Task<IEnumerable<Income>> GetItemsAsync();
        Task CreateItemAsync(Income income);
        Task UpdateItemAsync(Income income);
        Task DeleteItemAsync(System.Guid id);
        // ErrorOr<Created> CreateIncome(Income income);
        // ErrorOr<Income> GetIncome(Guid id);
        // ErrorOr<UpsertedIncome> UpsertIncome(Income income);
        // ErrorOr<Deleted> DeleteIncome(Guid id);

    }
}