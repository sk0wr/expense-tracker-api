using Expense_Tracker_API.DTOs;
using Expense_Tracker_API.Models;
using Expense_Tracker_API.Repositories;

namespace Expense_Tracker_API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExpenseResponse> CreateAsync(CreateExpenseRequest request)
        {
            Validate(request.Title, request.Amount, request.Category, request.ExpenseDate);

            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Title = request.Title.Trim(),
                Amount = request.Amount,
                Category = request.Category.Trim(),
                ExpenseDate = request.ExpenseDate,
                Description = request.Description?.Trim(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            var created = await _repository.AddAsync(expense);
            return Map(created);
        }

        public async Task<List<ExpenseResponse>> GetAllAsync()
        {
            var expenses = await _repository.GetAllAsync();
            return expenses.Select(Map).ToList();
        }

        public async Task<ExpenseResponse?> GetByIdAsync(Guid id)
        {
            var expense = await _repository.GetByIdAsync(id);
            return expense is null ? null : Map(expense);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateExpenseRequest request)
        {
            Validate(request.Title, request.Amount, request.Category, request.ExpenseDate);

            var existingExpense = await _repository.GetByIdAsync(id);
            if (existingExpense is null)
                return false;

            existingExpense.Title = request.Title.Trim();
            existingExpense.Amount = request.Amount;
            existingExpense.Category = request.Category.Trim();
            existingExpense.ExpenseDate = request.ExpenseDate;
            existingExpense.Description = request.Description?.Trim();
            existingExpense.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existingExpense);
            return true;
        }

        private static void Validate(string title, decimal amount, string category, DateTime expenseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Cat is required.");

            if (expenseDate == default)
                throw new ArgumentException("ExpenseDate is required.");
        }

        private static ExpenseResponse Map(Expense expense)
        {
            return new ExpenseResponse
            {
                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                ExpenseDate = expense.ExpenseDate,
                Description = expense.Description,
                CreatedAt = expense.CreatedAt,
                UpdatedAt = expense.UpdatedAt
            };
        }
    }
}