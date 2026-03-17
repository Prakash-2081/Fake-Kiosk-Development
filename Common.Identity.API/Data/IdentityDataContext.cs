using Common.Identity.API.Common.Data.Data;
using Common.Identity.API.Departments;
using Common.Identity.API.ModulePermissions;
using Common.Identity.API.ModulePermissions.Modules;
using Common.Identity.API.Permissions;
using Common.Identity.API.RoleModulePermissions;
using Common.Identity.API.Roles;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Data
{
    public class IdentityDataContext:DbContext
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModulePermission> ModulePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleModulePermission> RoleModulePermissions { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var provider = this.Database.ProviderName;
            var entities = modelBuilder.Model.GetEntityTypes()
                .Where(e=>e.ClrType.BaseType==typeof(BaseEntity));

            foreach(var entity in entities)
            {
                if (provider.Contains("SqlServer", StringComparison.OrdinalIgnoreCase))
                {
                    modelBuilder.Entity(entity.Name)
                        .Property(nameof(BaseEntity.Id))
                        .HasColumnType("uniqueidentifier");
                }
                else
                {
                    modelBuilder.Entity(entity.Name)
                        .Property(nameof(BaseEntity.Id))
                        .HasColumnType("uuid");
                }
            }
            modelBuilder.Entity<ModulePermission>()
                .HasOne(x => x.Module)
                .WithMany()
                .HasForeignKey(x => x.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModulePermission>()
                .HasOne(x => x.Permission)
                .WithMany()
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoleModulePermission>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoleModulePermission>()
                .HasOne(x => x.ModulePermission)
                .WithMany()
                .HasForeignKey(x => x.ModulePermissionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
                string databaseProvider = configuration["DatabaseProvider"] ?? "SqlServer";
                if (databaseProvider.Equals("SqlServer", StringComparison.OrdinalIgnoreCase)) 
                {
                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                }
                else
                {
                    throw new Exception("Unsupported database Provider");
                }
            }
        }
    }
}
