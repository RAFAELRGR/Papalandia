using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IStateGameService
    {
        Task<List<StateGames>> getStateGames();
        Task<StateGames> getStateGame(int StateGameId);
        Task<StateGames> createStateGame(int PlayerLocationId);
        Task<StateGames> updateStateGame(int StateGameId, int? PlayerLocationId = null);
        Task<StateGames> deleteStateGame(int StateGameId);
    }

    public class StateGamesService : IStateGameService
    {
        private readonly IStateGamesRepository _stateGamesRepository;
        public StateGamesService(IStateGamesRepository stateGamesRepository)
        {
            _stateGamesRepository = stateGamesRepository;
        }
        public async Task<StateGames> createStateGame(int PlayerLocationId)
        {
            return await _stateGamesRepository.createStateGame(PlayerLocationId);
        }
        public async Task<StateGames> getStateGame(int StateGameId)
        {
            return await _stateGamesRepository.getStateGame(StateGameId);
        }
        public async Task<List<StateGames>> getStateGames()
        {
            return await _stateGamesRepository.getStateGames();
        }
        public async Task<StateGames> updateStateGame(int StateGameId, int? PlayerLocationId = null)
        {
            StateGames stateGame = await _stateGamesRepository.getStateGame(StateGameId);

            if (stateGame == null)
            {
                return null;
            }

            if (PlayerLocationId != null)
            {
                stateGame.PlayerLocationId = PlayerLocationId.Value;
            }

            return await _stateGamesRepository.updateStateGame(stateGame);
        }
        public async Task<StateGames> deleteStateGame(int StateGameId)
        {
            return await _stateGamesRepository.deleteStateGame(StateGameId);
        }
    }
}
