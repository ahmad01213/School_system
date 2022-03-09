using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Helpers
{
    public class Functions
    {
        

      public static async Task<User> getCurrentUser(IHttpContextAccessor _httpContextAccessor, AppDbContext _context)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await _context.Users.FindAsync(userId);
        return user;
    }
    }
}