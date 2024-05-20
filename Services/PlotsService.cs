using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IPlotsService
    {
        Task<List<Plots>> getPlots();
        Task<Plots> getPlot(int PlotsId);
        Task<Plots> createPlot(decimal PlotsSize, decimal Longitude, decimal Latitude);
        Task<Plots> updatePlot(int PlotsId, decimal? PlotsSize=null, decimal? Longitude=null, decimal? Latitude=null);
        Task<Plots> deletePlot(int PlotsId);
    }

    public class PlotsService : IPlotsService
    {

        private readonly IPlotsRepository _plotsRepository;

        public PlotsService(IPlotsRepository plotsRepository)
        {

            _plotsRepository = plotsRepository;

        }

        public async Task<Plots> createPlot(decimal PlotsSize, decimal Longitude, decimal Latitude)
        {
            return await _plotsRepository.createPlot(PlotsSize, Longitude, Latitude);
        }

        public async Task<Plots> getPlot(int PlotId)
        {
            return await _plotsRepository.getPlot(PlotId);
        }

        public async Task<List<Plots>> getPlots()
        {
            return await _plotsRepository.getPlots();
        }

        public async Task<Plots> updatePlot(int PlotsId, decimal? PlotsSize = null, decimal? Longitude = null, decimal? Latitude = null)
        {
            Plots plots = await _plotsRepository.getPlot(PlotsId);

            if (plots == null)
            {
                return null;
            }
                if (PlotsSize != null)
            {
                plots.PlotsSize = PlotsSize;
            }
            if (Longitude != null)
            {
                plots.Longitude = Longitude;
            }
            if (Latitude != null)
            {
                plots.Latitude = Latitude;
            }

            return await _plotsRepository.updatePlot(plots);
        }

        public async Task<Plots> deletePlot(int PlotsId)
        {
            return await _plotsRepository.deletePlot(PlotsId);
        }

    }
}
