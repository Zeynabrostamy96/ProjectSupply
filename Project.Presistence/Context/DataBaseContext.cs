
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces.Contexts;
using Project.Domain.Entites;
using Project.Domain.Entites.Departments;
using Project.Domain.Entites.Log;
using Project.Domain.Entites.Users;

namespace Project.Presistence.Context
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>options):base(options)
        {

        }
       public DbSet<User> Users { get; set; }
       public DbSet<Supply> supplies { get; set; }
       public  DbSet<Log> logs { get; set; }
       public   DbSet<Department> departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data
            SeedDate(modelBuilder);
 
            //عدم نمایش اطلاعات حذف شده--
            ApplyQueryFilter(modelBuilder);
        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsRemoved);
            modelBuilder.Entity<Supply>().HasQueryFilter(x => !x.IsRemoved);
        }
        private void SeedDate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name ="اموراداری ",UserId=1 });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "امورانسانی  ", UserId = 2 });

            modelBuilder.Entity<User>().HasData(new User { Id = 1,Name="user1", Email="gmail@.com" });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Name = "user2", Email = "gmail1@.com" });
        }
       
    }
}
