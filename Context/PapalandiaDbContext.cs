using Microsoft.EntityFrameworkCore;
using Papalandia.Models;

namespace Papalandia.Context
{
    public class PapalandiaDbContext : DbContext
    {
        public PapalandiaDbContext(DbContextOptions<PapalandiaDbContext>options):base(options) 
        {

        }

        public DbSet<Potatoes> Potatoes { get; set;}
        public DbSet<Plots> Plots { get; set;}  
        public DbSet<Achievements> Achievements { get; set;}
        public DbSet<Crops> Crops { get; set;}
        public DbSet<Games> Games { get; set;}
        public DbSet<GamesAchievements> GamesAchievements { get;set;}
        public DbSet<Pests> Pests { get; set;}
        public DbSet<PlayerLocation> PlayerLocation { get; set;}    
        public DbSet<StateCrops> StateCrops { get; set;}
        public DbSet<StateGames> StateGames { get; set;}    
        public DbSet<StateTasks> StateTasks { get; set;}
        public DbSet<Supplies> Supplies { get; set;}
        public DbSet<Tasks> Tasks { get; set;}  
        public DbSet<TypePotatoes> TypePotatoes { get; set;}
        public DbSet<TypeSupplies> TypeSupplies { get; set;}    
        public DbSet<UserRol> UserRols { get; set;}
        public DbSet<Users> Users { get; set;}
        
    }
}
