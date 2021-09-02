using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MasterContext:DbContext
    {
        public MasterContext()
        {

        }
        public MasterContext(DbContextOptions<MasterContext>dbContext)
        {

        }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(x => x.BookId);
            modelBuilder.Entity<Writer>().HasKey(x => x.WriterId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL("Server=localhost;Database=dbBookTable;Uid=root;Pwd=123456;port=3306");
        }
    }
}
