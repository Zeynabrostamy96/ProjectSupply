using Microsoft.EntityFrameworkCore;
using Project.Domain.Entites;
using Project.Domain.Entites.Departments;
using Project.Domain.Entites.Log;
using Project.Domain.Entites.Users;


namespace Project.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Supply> supplies { get; set; }
        DbSet<Log> logs { get; set; }
        DbSet<Department> departments { get; set; }
        int SaveChanges();
  
    }
}
