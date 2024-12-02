using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esse builder abaixo é o que devemos fazer sempre, para a conecção com o banco de dados a utilização do mesmo. )
//Essa conexão é a conexão para MySQL

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//Essa abaixo é para SQL server

//builder.Services.AddDbContext<ApplicationDBContext>(options =>
//{
//options.UseSqlServer(
//  builder.Configuration.GetConnectionString("DefaultConnection")
//   );
//});


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
