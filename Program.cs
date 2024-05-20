using Microsoft.EntityFrameworkCore;
using Papalandia.Context;
using Papalandia.Repositories;
using Papalandia.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("Connection");


builder.Services.AddDbContext<PapalandiaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("http://localhost:5173") 
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


#region Repositories
builder.Services.AddScoped<IPotatoesRepository, PotatoesRepository>();
builder.Services.AddScoped<ITypePotatoesRepository, TypePotatoesRepository>();
builder.Services.AddScoped<ITypeSuppliesRepository, TypeSuppliesRepository>();
builder.Services.AddScoped<ISuppliesRepository, SuppliesRepository>();
builder.Services.AddScoped<IPestsRepository, PestsRepository>();
builder.Services.AddScoped<IPlotsRepository, PlotsRepository>();
builder.Services.AddScoped<IStateCropsRepository, StateCropsRepository>();
builder.Services.AddScoped<IStateTasksRepository, StateTasksRepository>();
builder.Services.AddScoped<IUserRolRepository, UserRolRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ICropsRepository, CropsRepository>();
builder.Services.AddScoped<IAchievementsRepository, AchievementsRepository>();
builder.Services.AddScoped<IPlayerLocationRepository, PlayerLocationRepository>();
builder.Services.AddScoped<IStateGamesRepository, StateGameRepository>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IGamesAchievementsRepository, GamesAchievementsRepository>();
#endregion

#region Services
builder.Services.AddScoped<IPotatoesService, PotatoesService>();
builder.Services.AddScoped<ITypePotatoesService, TypePotatoesService>();
builder.Services.AddScoped<ITypeSuppliesService, TypeSuppliesService>();
builder.Services.AddScoped<ISuppliesService, SuppliesService>();
builder.Services.AddScoped<IPestsService, PestsService>();
builder.Services.AddScoped<IPlotsService, PlotsService>();
builder.Services.AddScoped<IStateCropsService, StateCropsService>();
builder.Services.AddScoped<IStateTasksService, StateTasksService>();
builder.Services.AddScoped<IUserRolService, UserRolService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ICropsService, CropsService>();
builder.Services.AddScoped<IAchievementsService, AchievementsService>();
builder.Services.AddScoped<IPlayerLocationService, PlayerLocationService>();
builder.Services.AddScoped<IStateGameService, StateGamesService>();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IGamesAchievementsService, GamesAchievementsService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
