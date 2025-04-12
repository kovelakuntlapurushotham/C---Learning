using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using UserManagement.Configurations;
using UserManagement.Data;
using UserManagement.Filters;
using UserManagement.Helpers;
using UserManagement.Repositories;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Logging (Serilog)
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// 🔹 Configuration Binding
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));

// 🔹 Add Core Services
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// 🔹 Add Custom Services
builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenService>();
builder.Services.AddTransient<IUserManagementService, UserManagementService>();

// 🔹 Add Database Context
builder.Services.AddDbContext<UserManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserManagementConnection")));

// 🔹 Add Controllers + Filters + JSON Options
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; 
});

// 🔹 Swagger / API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 JWT Authentication
var jwtConfig = builder.Configuration.GetSection(nameof(JwtConfiguration));
var secretKey = jwtConfig.GetValue<string>("SecretKey");
var issuer = jwtConfig.GetValue<string>("Issuer");
var audience = jwtConfig.GetValue<string>("Audience");
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false, // You can change to true if you validate issuer
        ValidateAudience = false, // Same for audience
        ValidAudience = audience,
        ValidIssuer = issuer
    };
});

var app = builder.Build();

// 🔹 Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication(); // ⬅️ Make sure authentication comes before authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
