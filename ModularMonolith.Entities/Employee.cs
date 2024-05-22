using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Entities;

public class Employee : Entity<int>
{
    public string? Name { get; set; }  
    public string? Email { get; set; }
    public string? Function { get; set; }
    public int CompanyId { get; init; }
    public Company? Company { get; init; }
}