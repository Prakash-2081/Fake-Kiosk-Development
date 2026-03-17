using Common.Identity.API.Data;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.Departments;
using Common.Identity.API.Departments.Contracts;
using Common.Identity.API.ModulePermissions;
using Common.Identity.API.ModulePermissions.Contracts;
using Common.Identity.API.ModulePermissions.Modules;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Common.Identity.API.Permissions;
using Common.Identity.API.Permissions.Contracts;
using Common.Identity.API.Roles;
using Common.Identity.API.Roles.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IModulePermissionService,ModulePermissionService>();
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IDepartmentService,DepartmentService>();
        }
    }
}
