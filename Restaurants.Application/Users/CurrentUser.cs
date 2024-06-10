﻿namespace Restaurants.Application.Users;

public record CurrentUser(string Id, string Email, IEnumerable<string> Roles)
{
    public bool IsInROle(string role) => Roles.Contains(role);
}