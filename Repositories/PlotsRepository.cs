using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IPlotsRepository
    {
        Task<List<Plots>> getPlots();
        Task<Plots> getPlot(int PlotsId);
        Task<Plots> createPlot(decimal PlotsSize, decimal Longitude, decimal Latitude);
        Task<Plots> updatePlot(Plots plots);
        Task<Plots> deletePlot(int PlotsId);
    }
    public class PlotsRepository : IPlotsRepository
    {

        private readonly PapalandiaDbContext _db;

        public PlotsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Plots> createPlot(decimal PlotsSize, decimal Longitude, decimal Latitude)
        {

            Plots plots = new Plots
            {
                PlotsSize = PlotsSize,
                Longitude = Longitude,
                Latitude = Latitude,
            };

            _db.Plots.Add(plots);
            await _db.SaveChangesAsync();

            return plots;

        }

        public async Task<List<Plots>> getPlots()
        {
            return await _db.Plots.ToListAsync();
        }

        public async Task<Plots> getPlot(int PlotsId)
        {
            return await _db.Plots.Where(u => u.PlotsId == PlotsId).FirstOrDefaultAsync();
        }

        public async Task<Plots> updatePlot(Plots plots)
        {
            _db.Plots.Update(plots);
            await _db.SaveChangesAsync();
            return plots;
        }

        public async Task<Plots> deletePlot(int PlotsId)
        {
            Plots plots = await _db.Plots.FindAsync(PlotsId);
            if (plots == null)
            {
                return null;
            }
            _db.Plots.Remove(plots);
            await _db.SaveChangesAsync();
            return plots;

        }

    }
}
