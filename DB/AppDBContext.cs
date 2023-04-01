using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebCore.Model;
namespace WebCore.DB
{
    public class AppDBContext: IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }
        
        public DbSet<employees> employees { get; set; }
    }
}
