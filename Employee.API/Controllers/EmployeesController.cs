using Employee.Core.Entities;
using Employee.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _repository;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(IEmployeeRepository repository, ILogger<EmployeesController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving all employees");
        var items = await _repository.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving employee {Id}", id);
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeEntity employee, CancellationToken cancellationToken)
    {
        var created = await _repository.AddAsync(employee, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.EmployeeId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeEntity employee, CancellationToken cancellationToken)
    {
        var exists = await _repository.GetByIdAsync(id, cancellationToken);
        if (exists is null) return NotFound();
        employee.EmployeeId = id;
        await _repository.UpdateAsync(employee, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var exists = await _repository.GetByIdAsync(id, cancellationToken);
        if (exists is null) return NotFound();
        await _repository.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
