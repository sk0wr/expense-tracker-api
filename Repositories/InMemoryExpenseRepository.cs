using Expense_Tracker_API.Models;

namespace Expense_Tracker_API.Repositories
{
    public class InMemoryExpenseRepository : IExpenseRepository
    {
        private static readonly List<Expense> _expenses = new();

        public Task<Expense> AddAsync(Expense expense)
        {
            _expenses.Add(expense);
            return Task.FromResult(expense);
        }

        public Task<List<Expense>> GetAllAsync()
        {
            var result = _expenses
                .OrderByDescending(x => x.ExpenseDate)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<Expense?> GetByIdAsync(Guid id)
        {
            var expense = _expenses.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(expense);
        }

        public Task UpdateAsync(Expense expense)
        {
            var existingExpense = _expenses.FirstOrDefault(x => x.Id == expense.Id);

            if (existingExpense is not null)
            {
                existingExpense.Title = expense.Title;
                existingExpense.Amount = expense.Amount;
                existingExpense.Category = expense.Category;
                existingExpense.ExpenseDate = expense.ExpenseDate;
                existingExpense.Description = expense.Description;
                existingExpense.UpdatedAt = expense.UpdatedAt;
            }

            return Task.CompletedTask;
        }
    }
}