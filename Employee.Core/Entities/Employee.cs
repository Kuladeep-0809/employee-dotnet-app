namespace Employee.Core.Entities;

public sealed class EmployeeEntity
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string Designation { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
