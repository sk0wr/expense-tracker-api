namespace Expense_Tracker_API.DTOs
{
    public class CreateExpenseRequest
    {


        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }
    }
}
