using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IGamesService
    {
        Task<List<Games>> getGames();
        Task<Games> getGame(int GameId);
        Task<Games> createGame(DateTime StartGame, DateTime EndGame, int UserId, int StateGameId);
        Task<Games> updateGame(int GameId, DateTime? StartGame=null, DateTime? EndGame=null, int? UserId=null, int? StateGameId=null);
        Task<Games> deleteGame(int GameId);
    }

    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {

            _gamesRepository = gamesRepository;

        }

        public async Task<Games> createGame(DateTime StartGame, DateTime EndGame, int UserId, int StateGameId)
        {
            return await _gamesRepository.createGame(StartGame, EndGame, UserId, StateGameId);
        }

        public async Task<Games> getGame(int GameId)
        {
            return await _gamesRepository.getGame(GameId);
        }

        public async Task<List<Games>> getGames()
        {
            return await _gamesRepository.getGames();
        }

        public async Task<Games> updateGame(int GameId, DateTime? StartGame = null, DateTime? EndGame = null, int? UserId = null, int? StateGameId = null)
        {
            Games games = await _gamesRepository.getGame(GameId);

            if (games == null)
            {
                return null;
            }
            else
                if (StartGame != null)
            {
                games.StartGame = StartGame;
            }
            if (EndGame != null)
            {
                games.EndGame = EndGame;
            }
            if (UserId != null)
            {
                games.UserId = UserId;
            }
            if (StateGameId != null)
            {
                games.StateGameId = StateGameId;
            }

            return await _gamesRepository.updateGame(games);
        }

        public async Task<Games> deleteGame(int GameId)
        {
            return await _gamesRepository.deleteGame(GameId);
        }

    }
}
