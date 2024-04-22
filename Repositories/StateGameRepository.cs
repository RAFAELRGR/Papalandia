using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IStateGamesRepository
    {
        Task<List<StateGames>> getStateGames();
        Task<StateGames> getStateGame(int StateGameId);
        Task<StateGames> createStateGame(int PlayerLocationId);
        Task<StateGames> updateStateGame(StateGames stateGames);
        Task<StateGames> deleteStateGame(int StateGameId);
    }

    public class StateGameRepository : IStateGamesRepository
    {

        private readonly PapalandiaDbContext _db;

        public StateGameRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<StateGames> createStateGame(int PlayerLocationId)
        {

            StateGames newStateGames = new StateGames
            {
                PlayerLocationId = PlayerLocationId,
            };

            _db.StateGames.Add(newStateGames);
            await _db.SaveChangesAsync();

            return newStateGames;

        }

        public async Task<List<StateGames>> getStateGames()
        {
            return await _db.StateGames.ToListAsync();
        }

        public async Task<StateGames> getStateGame(int StateGameId)
        {
            return await _db.StateGames.Where(u => u.StateGameId == StateGameId).FirstOrDefaultAsync();
        }

        public async Task<StateGames> updateStateGame(StateGames stateGames)
        {
            _db.StateGames.Update(stateGames);
            await _db.SaveChangesAsync();
            return stateGames;
        }

        public async Task<StateGames> deleteStateGame(int stateGamesId)
        {
            StateGames stateGames = await getStateGame(stateGamesId);
            // student.IsDeleted = true;
            return await updateStateGame(stateGames);
        }

    }
}
