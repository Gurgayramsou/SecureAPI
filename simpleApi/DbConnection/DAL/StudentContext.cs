using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using DbConnection.Model;

namespace DbConnection.DAL
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("name=StudentContext")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { 

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
