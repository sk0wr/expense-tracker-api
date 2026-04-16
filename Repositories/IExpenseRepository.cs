using Expense_Tracker_API.Models;

namespace Expense_Tracker_API.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> AddAsync(Expense expense);
        Task<List<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(Guid id);
        Task UpdateAsync(Expense expense);
    }
}