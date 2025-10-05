﻿namespace Domain;

public class UserRole
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}
