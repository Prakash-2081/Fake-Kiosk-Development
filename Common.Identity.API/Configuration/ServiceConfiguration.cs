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
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddMassTransit(x =>
            {
                //x.AddConsumer<LibraryEventConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });
                    //cfg.ReceiveEndpoint("identity.library-event", e =>
                    //{
                    //    e.ConfigureConsumer<LibraryEventConsumer>(context);
                    //});
                });
            });
            //Waits until RabbitMQ bus is started
            services.AddOptions<MassTransitHostOptions>().Configure(options =>
            {
                options.WaitUntilStarted = true;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IModulePermissionService,ModulePermissionService>();
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IDepartmentService,DepartmentService>();
        }
    }
}
