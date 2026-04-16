using Expense_Tracker_API.DTOs;

namespace Expense_Tracker_API.Services
{
    public interface IExpenseService
    {
        Task<ExpenseResponse> CreateAsync(CreateExpenseRequest request);
        Task<List<ExpenseResponse>> GetAllAsync();
        Task<ExpenseResponse?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, UpdateExpenseRequest request);
    }
}