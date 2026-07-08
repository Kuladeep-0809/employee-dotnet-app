using Employee.Core.Entities;
using Employee.Core.Interfaces;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repositories;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeContext _context;

    public EmployeeRepository(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<EmployeeEntity> AddAsync(EmployeeEntity employee, CancellationToken cancellationToken = default)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return employee;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _context.Employees.FindAsync(new object[] { id }, cancellationToken);
        if (existing is null) return;
        _context.Employees.Remove(existing);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<EmployeeEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<EmployeeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == id, cancellationToken);
    }

    public async Task UpdateAsync(EmployeeEntity employee, CancellationToken cancellationToken = default)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
