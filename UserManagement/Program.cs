using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Configurations;
using UserManagement.Data;
using UserManagement.Filters;
using UserManagement.Helpers;
using UserManagement.Repositories;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
}).AddJsonOptions(options =>
{
    // Preserve original property names during JSON serialization/deserialization.
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//this line is required for autoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenService>();

builder.Services.AddTransient<IUserManagementService, UserManagementService>();

builder.Services.AddDbContext<UserManagementContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserManagementConnection")));
var section = builder.Configuration.GetSection(nameof(JwtConfiguration));
var secret = section.GetValue<string>("SecretKey");
var issuer = section.GetValue<string>("Issuer");
var audience = section.GetValue<string>("Audience");
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               // services.AddAuthentication("Bearer")
               .AddJwtBearer(opt => {
                   opt.IncludeErrorDetails = true;
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = false,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateAudience = false,
                       ValidAudience = audience,

                   };
               });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
