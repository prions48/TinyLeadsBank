using Microsoft.EntityFrameworkCore;

namespace TinyLeadsBank.Data.Users
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<Auth0User> Auth0Users { get; set; }
        public DbSet<Auth0UserFile> Auth0UserFiles { get; set; }
        public DbSet<AuditLogin> AuditLogins { get; set; }
    }
}