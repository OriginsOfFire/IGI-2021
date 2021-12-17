using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<GuitarGroup> GuitarGroups { get; set; }
    }
}
