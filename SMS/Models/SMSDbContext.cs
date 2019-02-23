using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMS.Models
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext() : base("ConnectionString")
        {
            //Database.SetInitializer<SMSDbContext>(new DropCreateDatabaseIfModelChanges<SMSDbContext>());
        }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<StatusMaster> StatusMasters { get; set; }

        public DbSet<CategoryMaster> CategoryMasters { get; set; }
        public DbSet<SubCategoryMaster> SubCategoryMasters { get; set; }
        public DbSet<EmployeeMaster> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<ClientMaster> ClientMasters { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<ImageUploader> ImageUploaders { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}