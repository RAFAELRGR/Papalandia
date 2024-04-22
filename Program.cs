using Microsoft.EntityFrameworkCore;
using Papalandia.Context;
using Papalandia.Repositories;
using Papalandia.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<PapalandiaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Repositories
builder.Services.AddScoped<IPotatoesRepository, PotatoesRepository>();
builder.Services.AddScoped<ITypePotatoesRepository, TypePotatoesRepository>();
builder.Services.AddScoped<ITypeSuppliesRepository, TypeSuppliesRepository>();
builder.Services.AddScoped<ISuppliesRepository, SuppliesRepository>();
builder.Services.AddScoped<IPestsRepository, PestsRepository>();
builder.Services.AddScoped<IPlotsRepository, PlotsRepository>();
builder.Services.AddScoped<IStateCropsRepository, StateCropsRepository>();

#endregion

#region Services
builder.Services.AddScoped<IPotatoesService, PotatoesService>();
builder.Services.AddScoped<ITypePotatoesService, TypePotatoesService>();
builder.Services.AddScoped<ITypeSuppliesService, TypeSuppliesService>();
builder.Services.AddScoped<ISuppliesService, SuppliesService>();
builder.Services.AddScoped<IPestsService, PestsService>();
builder.Services.AddScoped<IPlotsService, PlotsService>();  
builder.Services.AddScoped<IStateCropsService, StateCropsService>();

#endregion


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
