using DataContext.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Data
{
    public partial class Context : DbContext
    {
        public Context() : base("conn")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        //Property to be used if we want to call the datacontext directly (I.E using statement)
        public DbSet<Entry> Entry { get; set; }
        public DbSet<PhoneBook> Phonebook { get; set; }

        public override int SaveChanges() => base.SaveChanges();

        public bool DatabaseExists() => Database.Exists();

        public void ExecuteSql(string sql) => Database.ExecuteSqlCommand(sql);
    }
}
