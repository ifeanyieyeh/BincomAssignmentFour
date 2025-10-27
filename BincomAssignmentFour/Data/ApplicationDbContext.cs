using BincomAssignmentFour.Models;
using BincomAssignmentFour.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BincomAssignmentFour.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
}
