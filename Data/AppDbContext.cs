using Microsoft.EntityFrameworkCore;
using simpleWebApi.Models;

namespace simpleWebApi.Data
{
    public class AppDbContext : DbContext 
    {
         public AppDbContext (DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<TodoItem> TodoItems {get; set;}
    }
}