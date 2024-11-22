/*
 * WILLIAM MCPETRIE
 * ST10263164
 * PROG6212
 * POE PART 3
*/

using Microsoft.EntityFrameworkCore;
using ST10263164_MCPETRIE_PROG6212.Models;

namespace ST10263164_MCPETRIE_PROG6212.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Lecturer> Lecturers { get; set;}
        public DbSet<AcademicManager> AcademicManagers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ProgrammeCoordinator> ProgrammeCoordinators { get; set; }

    }
}
