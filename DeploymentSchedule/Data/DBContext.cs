using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLite.CodeFirst;
using System.Data.Entity;
using DeploymentSchedule.Models;

namespace DeploymentSchedule.Data
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("DeploymentConnectionString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DbContext>());

            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DbContext>(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Deployment> Deployments { get; set; }

    }
}