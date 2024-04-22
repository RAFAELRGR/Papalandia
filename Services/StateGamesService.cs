using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IStateGameService
    {
        Task<List<StateGames>> getStateGames();
        Task<StateGames> getStateGame(int StateGameId);
        Task<StateGames> createStateGame(int PlayerLocationId);
        Task<StateGames> updateStateGame(int StateGameId, int? PlayerLocationId=null);
        Task<StateGames> deleteStateGame(int AchievementsId);
    }

    public class StateGamesService
    {


        private readonly IStateGamesRepository _stateGamesRepository;

        public StateGamesService(IStateGamesRepository stateGamesRepository)
        {

            _stateGamesRepository = stateGamesRepository;

        }

        public async Task<StateGames> createStateGames(int PlayerLocationId)
        {
            return await _stateGamesRepository.createStateGame (PlayerLocationId);
        }

        public async Task<StateGames> GetStateGames(int StateGameId)
        {
            return await _stateGamesRepository.createStateGame(StateGameId);
        }

        public async Task<List<StateGames>> getStateGames()
        {
            return await _stateGamesRepository.getStateGames();
        }

        public async Task<StateGames> updateStateGames(int StateGameId, int? PlayerLocationId = null)
        {
            StateGames stateGames = await _stateGamesRepository.getStateGame(StateGameId);

            if (stateGames == null)
            {
                return null;
            }
            else
                if (PlayerLocationId != null)
            {
                stateGames.PlayerLocationId = PlayerLocationId;
            }

            return await _stateGamesRepository.updateStateGame(stateGames);
        }

        public async Task<StateGames> deleteStateGame(int StateGameId)
        {
            return await _stateGamesRepository.deleteStateGame(StateGameId);
        }

    }
}
