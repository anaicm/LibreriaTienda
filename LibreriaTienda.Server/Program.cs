using LibreriaTienda.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//para añadir tablas a las BD solo hay que cambiar "AddDbContext<CasasContext>" por el context de la tabla
//ya que hay es donde viene el nombre que va a tener la tabla
builder.Services.AddDbContext<LibreriaContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=TiendaLibros;User Id=sa;Password=rootadmin;Encrypt=false"));
//---------------------------

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
