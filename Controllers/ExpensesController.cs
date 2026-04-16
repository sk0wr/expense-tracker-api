using Expense_Tracker_API.DTOs;
using Expense_Tracker_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseRequest request)
        {
            try
            {
                var created = await _service.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _service.GetAllAsync();
            return Ok(expenses);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var expense = await _service.GetByIdAsync(id);
            if (expense is null)
                return NotFound(new { message = "Expense not found." });

            return Ok(expense);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpenseRequest request)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, request);
                if (!updated)
                    return NotFound(new { message = "Expense not found." });

                return Ok(new { message = "Expense updated successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}