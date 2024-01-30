using PizzaExample.Business;
using PizzaExample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>();
builder.Services.AddScoped<IngredienteService>();


//builder.Services.AddScoped<IPizzaService, PizzaService>();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider => 
    new PizzaSqlRepository(connectionString));


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
