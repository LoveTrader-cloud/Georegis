using System;
using System.Collections.Generic;
using System.Data.Entity;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context
{
    public class NpgsqlContext : DbContext
    {
        public NpgsqlContext() : base("NpgsqlContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<DraftTask> DraftTasks {get; set;}

        public DbSet<Department> Departments { get; set; }

        public DbSet<ExecDep> ExecDeps { get; set; }

        public DbSet<Executor> Executors { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<ProcessSession> ProcessSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DraftTask>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(t => t.Login).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.FullName).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(t => t.ShortName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.TelNo).HasMaxLength(15);
            modelBuilder.Entity<User>().Property(t => t.Email).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(t => t.Company).HasMaxLength(100);

            modelBuilder.Entity<Executor>().HasKey(x => x.Id);
            modelBuilder.Entity<Executor>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Executor>().Property(t => t.Resolution).HasMaxLength(500);
            //связи Executor
            modelBuilder.Entity<Executor>().HasOptional(x => x.User).WithMany(x => x.Executors).WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>().Property(t => t.Value).HasMaxLength(50);
            modelBuilder.Entity<Status>().Property(t => t.Name).HasMaxLength(50);

            modelBuilder.Entity<ExecDep>().HasKey(x => x.Id);
            modelBuilder.Entity<ExecDep>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ExecDep>().Property(t => t.Resolution).HasMaxLength(500);

            modelBuilder.Entity<ProcessSession>().HasKey(x => x.Id);
            modelBuilder.Entity<ProcessSession>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Department>().Property(t => t.Title).HasMaxLength(150);
            modelBuilder.Entity<Department>().Property(t => t.DepartmentCode).HasMaxLength(15);
            modelBuilder.Entity<Department>().Property(t => t.Description).HasMaxLength(250);
            modelBuilder.Entity<Department>().Property(t => t.DepartmentPrefix).HasMaxLength(15);
            modelBuilder.Entity<Department>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Связи Department
            modelBuilder.Entity<Department>().HasOptional(x => x.UserGroupManager).WithMany(x => x.ManagedDepartments);
            
        }
    }


    
    }
