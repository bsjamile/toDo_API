using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;

namespace WoMakersCode.ToDoList.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=todolist;User Id=todolistuser;Password=340$Uuxwp7Mcxo7Khy;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskList>(m =>
            {
                m.ToTable("tasklists");
                m.HasKey(m => m.Id);
                m.Property(m => m.ListName).HasColumnType("VARCHAR(100)").IsRequired();
                m.HasOne(h => h.Color)
                .WithOne(w => w.TaskList)
                .HasForeignKey<TaskList>(fk => fk.IdColor);
            });

            modelBuilder.Entity<TaskDetail>(m =>
            {
                m.ToTable("taskdetails");
                m.HasKey(m => m.Id);
                m.Property(m => m.Descricao).HasColumnType("VARCHAR(300)").IsRequired();
                m.Property(m => m.DataHora).HasColumnType("DATETIME").IsRequired();
                m.Property(m => m.Executado).HasColumnType("INT").IsRequired();
                m.HasOne<TaskList>(m => m.TaskList)
                    .WithMany(m => m.Details)
                    .HasForeignKey(f => f.IdTaskList).IsRequired();
            });

            modelBuilder.Entity<Color>(m =>
            {
                m.ToTable("colors");
                m.HasKey(m => m.Id);
                m.Property(m => m.Name).HasColumnType("VARCHAR(100)").IsRequired();
            });
        }
    }
}
