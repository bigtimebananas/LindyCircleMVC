using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LindyCircleMVC.Models
{
    public class UsersDbContext : IdentityDbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options) {
        }
    }
}
