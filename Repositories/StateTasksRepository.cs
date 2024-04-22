using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IStateTasksRepository
    {
        Task<List<StateTasks>> getStateTasks();
        Task<StateTasks> getStateTask(int StateTasksId);
        Task<StateTasks> createStateTask(string StateTasksName);
        Task<StateTasks> updateStateTask(StateTasks stateTasks);
        Task<StateTasks> deleteStateTask(int StateTasksId);
    }

    public class StateTasksRepository : IStateTasksRepository
    {

        private readonly PapalandiaDbContext _db;

        public StateTasksRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<StateTasks> createStateTask(string StateTasksName)
        {

            StateTasks newStateTasks = new StateTasks
            {
                StateTasksName = StateTasksName,
            };

            _db.StateTasks.Add(newStateTasks);
            await _db.SaveChangesAsync();

            return newStateTasks;

        }

        public async Task<List<StateTasks>> getStateTasks()
        {
            return await _db.StateTasks.ToListAsync();
        }

        public async Task<StateTasks> getStateTask(int stateTasksId)
        {
            return await _db.StateTasks.Where(u => u.StateTasksId == stateTasksId).FirstOrDefaultAsync();
        }

        public async Task<StateTasks> updateStateTask(StateTasks stateTasks)
        {
            _db.StateTasks.Update(stateTasks);
            await _db.SaveChangesAsync();
            return stateTasks;
        }

        public async Task<StateTasks> deleteStateTask(int stateTasksId)
        {
            StateTasks stateTasks = await _db.StateTasks.FindAsync(stateTasksId);
            if (stateTasks == null)
            {
                return null;
            }
            _db.StateTasks.Remove(stateTasks);
            await _db.SaveChangesAsync();
            return stateTasks;

        }

    }
}
