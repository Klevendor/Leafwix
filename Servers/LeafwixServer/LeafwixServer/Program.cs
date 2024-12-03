using LeafwixServer.Middleware;
using LeafwixServerBLL.Services.Implementation;
using LeafwixServerBLL.Services.Interfaces;
using LeafwixServerDAL.Constants.Settings;
using LeafwixServerDAL.Context.Implementation;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Repositories.Implementation;
using LeafwixServerDAL.Repositories.Interfaces;
using LeafwixServerDAL.Seeding;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

/* Database */

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

if (seed)
{
    SeedData.AddDatabaseData(connectionString);
}


builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(config =>
                config.UseNpgsql(connectionString));

/* Identity */

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = SecuritySettings.Passwords.RequireDigit;
    options.Password.RequireLowercase = SecuritySettings.Passwords.RequireLowercase;
    options.Password.RequireNonAlphanumeric = SecuritySettings.Passwords.RequireNonAlphanumeric;
    options.Password.RequireUppercase = SecuritySettings.Passwords.RequireUppercase;
    options.Password.RequiredLength = SecuritySettings.Passwords.RequiredLength;
    options.Password.RequiredUniqueChars = SecuritySettings.Passwords.RequiredUniqueChars;
    options.User.RequireUniqueEmail = SecuritySettings.Passwords.RequireUniqueEmail;
    options.SignIn.RequireConfirmedEmail = SecuritySettings.Passwords.RequireConfirmedEmail;
    options.User.AllowedUserNameCharacters = SecuritySettings.Passwords.AllowedUserNameCharacters;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

/* Services & Repositories*/

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddScoped<INotificationSettingsRepository, NotificationSettingsRepository>();
builder.Services.AddScoped<IPlantDiseasesRepository, PlantDiseasesRepository>();
builder.Services.AddScoped<IPlantSpeciesRepository, PlantSpeciesRepository>();
builder.Services.AddScoped<IPlantCareHistoryRepository, PlantCareHistoryRepository>();

builder.Services.AddScoped<INotificationSettingsService, NotificationSettingsService>();
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IPlantDiseasesService, PlantDiseasesService>();
builder.Services.AddScoped<IPlantSpeciesService, PlantSpeciesService>();
//builder.Services.AddScoped<IPlantCareHistoryService, PlantCareHistoryService>();

/* Configs */

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<AppEnvironmentSettings>(options =>
{
    options.RootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
});
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Configuration.AddUserSecrets<Program>();

/* Other */
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "NovelsWordAPI", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    var allowedHost = builder.Configuration.GetValue<string>("ClientHost") ?? "";

    options.AddPolicy("AllowSpecificOrigin",
        option => option
            .WithOrigins(allowedHost)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());

    options.AddPolicy("AllowAll",
        option => option
            .SetIsOriginAllowed(origin => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

/* Mapper */

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

/* ------------------------------------------------------------------- */

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
