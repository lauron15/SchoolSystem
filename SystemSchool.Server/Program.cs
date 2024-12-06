using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esse builder abaixo � o que devemos fazer sempre, para a conec��o com o banco de dados a utiliza��o do mesmo. )
//Essa conex�o � a conex�o para MySQL

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//Essa abaixo � para SQL server

//builder.Services.AddDbContext<ApplicationDBContext>(options =>
//{
//options.UseSqlServer(
//  builder.Configuration.GetConnectionString("DefaultConnection")
//   );
//});


builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
