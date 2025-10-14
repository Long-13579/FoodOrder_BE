using Application.Common.Models;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid> 
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
