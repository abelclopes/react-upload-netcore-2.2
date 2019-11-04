using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ApiApplicationDbContext : DbContext
    {
        protected ApiApplicationDbContext(DbContextOptions<ApiApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<FileImage> FileImages { get; set; }
    }
}