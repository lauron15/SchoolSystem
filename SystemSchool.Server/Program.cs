using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SystemSchool.Server.Data;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;
using SystemSchool.Server.Repository;
using SystemSchool.Server.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esse builder abaixo é o que devemos fazer sempre, para a conecção com o banco de dadoSystem.IO.InvalidDataException: 'Failed to load configuration from file 'C:\Users\Laurim\Desktop\SystemSchool\SystemSchool\SystemSchool.Server\appsettings.json'.'
//s a utilização do mesmo. )
//Essa conexão é a conexão para MySQL

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")
    ));


//configuração para o token e criptografia. 
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = 
    Options.DefaultChallengeScheme = 
    Options.DefaultForbidScheme = 
    Options.DefaultScheme = 
    Options.DefaultSignInScheme = 
    Options.DefaultSignOutScheme= JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(
    
    Options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
                )
        };
    }
    );


builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

//Colocar para fazer meu repository rodar. 
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddScoped<ITokenService,TokenService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
