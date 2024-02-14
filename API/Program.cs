using PizzaExample.Data;
using PizzaExample.Business;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/* builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>();
builder.Services.AddScoped<IngredienteService>(); */


builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaEFRepository>();

builder.Services.AddScoped<IIngredienteService, IngredienteService>();
builder.Services.AddScoped<IIngredientesRepository, IngredienteEFRepository>();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information));
  
  



/* builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider => 
    new PizzaSqlRepository(connectionString));

    builder.Services.AddScoped<IIngredientesRepository, IngredienteSqlRepository>(serviceProvider => 
    new IngredienteSqlRepository(connectionString)); */


/* builder.Services.AddScoped<IngredienteService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>(); */

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
