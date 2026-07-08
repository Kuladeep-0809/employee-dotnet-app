using Employee.Core.Entities;

namespace Employee.Core.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<EmployeeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<EmployeeEntity> AddAsync(EmployeeEntity employee, CancellationToken cancellationToken = default);
    Task UpdateAsync(EmployeeEntity employee, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
