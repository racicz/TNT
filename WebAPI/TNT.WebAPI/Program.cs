using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TNT.Business.Interfaces.User;
using TNT.Business.Repositories;
using TNT.Data.AuthenticationModel;
using TNT.Data.Model;
using TNT.EmailService;
using TNT.Shared.Model.User;
using TNT.WebAPI.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration["AuthConnection:DBConnectionString"]));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;

    opt.User.RequireUniqueEmail = true;

    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    opt.Lockout.MaxFailedAccessAttempts = 3;
})
.AddEntityFrameworkStores<AuthContext>()
.AddDefaultTokenProviders();

builder.Services.AddDbContext<TNTContext>(options => options.UseSqlServer(builder.Configuration["TNTConnection:DBConnectionString"]));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUser, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

app.Run();
