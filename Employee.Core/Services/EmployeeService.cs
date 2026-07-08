using Employee.Core.Entities;
using Employee.Core.Interfaces;

namespace Employee.Core.Services;

public sealed class EmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<EmployeeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<EmployeeEntity> CreateAsync(EmployeeEntity employee, CancellationToken cancellationToken = default)
    {
        return await _repository.AddAsync(employee, cancellationToken);
    }

    public async Task<bool> UpdateAsync(int id, EmployeeEntity employee, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (existing is null) return false;
        employee.EmployeeId = id;
        await _repository.UpdateAsync(employee, cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (existing is null) return false;
        await _repository.DeleteAsync(id, cancellationToken);
        return true;
    }
}
