using Microsoft.EntityFrameworkCore;
using SwaranSoftCurd.Models;

namespace SwaranSoftCurd.Models
{
    public class DatabseContext:DbContext
    {
        public DatabseContext(DbContextOptions<DatabseContext>option):base(option)
        {

        }
       public DbSet<Student>Students { get; set; }
       public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<SwaranSoftCurd.Models.StudentJoin> StudentJoin { get; set; } = default!;

    }
}
