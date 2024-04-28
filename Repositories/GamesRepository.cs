using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;
using System;

namespace Papalandia.Repositories
{
    public interface IGamesRepository
    {

        Task<List<Games>> getGames();
        Task<Games> getGame(int GameId);
        Task<Games> createGame(DateTime StartGame, DateTime EndGame, int UserId, int StateGameId);
        Task<Games> updateGame(Games games);
        Task<Games> deleteGame(int GameId);
    }

    public class GamesRepository: IGamesRepository
    {

        private readonly PapalandiaDbContext _db;

        public GamesRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Games> createGame(DateTime StartGame, DateTime EndGame, int UserId, int StateGameId)
        {

            Games newGames = new Games
            {
                StartGame = StartGame,
                EndGame = EndGame,
                UserId = UserId,
                StateGameId = StateGameId,
            };

            _db.Games.Add(newGames);
            await _db.SaveChangesAsync();

            return newGames;

        }

        public async Task<List<Games>> getGames()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<Games> getGame(int GameId)
        {
            return await _db.Games.Where(u => u.GameId == GameId).FirstOrDefaultAsync();
        }

        public async Task<Games> updateGame(Games games)
        {
            _db.Games.Update(games);
            await _db.SaveChangesAsync();
            return games;
        }

        public async Task<Games> deleteGame(int GameId)
        {
            var gameToDelete = await getGame(GameId);
            if (gameToDelete == null)
            {
                return null;
            }
            _db.Games.Remove(gameToDelete);
            await _db.SaveChangesAsync();
            return gameToDelete;
        }


    }
}
