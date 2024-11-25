using LeafwixServerDAL.Constants.Settings;
using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace LeafwixServerDAL.Seeding
{
    public class SeedData
    {
        public static async void AddDatabaseData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString)
            );

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var contextApplication = scope.ServiceProvider.GetService<ApplicationDbContext>();
                contextApplication.Database.Migrate();
                await AddUserData(scope);

            }
        }

        private async static Task AddUserData(IServiceScope scope)
        {
            var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole<Guid>>>();

            var superUserCheck = await userManager.FindByNameAsync(AuthorizationSettings.DefaultUsername);
            if (superUserCheck == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(AppRoles.Administrator.ToString()));
                await roleManager.CreateAsync(new IdentityRole<Guid>(AppRoles.User.ToString()));

                var superUser = new User { UserName = AuthorizationSettings.DefaultUsername, Email = AuthorizationSettings.DefaultEmail, EmailConfirmed = true, PhoneNumberConfirmed = true, SecurityStamp = "SuperUser" };
                if (userManager.Users.All(u => u.Id != superUser.Id))
                {
                    await userManager.CreateAsync(superUser, AuthorizationSettings.DefaultPassword);
                    await userManager.AddToRoleAsync(superUser, AuthorizationSettings.SuperUserRole.ToString());
                }
            }
        }
    }
}
