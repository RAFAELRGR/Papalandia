using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> getTasks();
        Task<Tasks> getTask(int TasksId);
        Task<Tasks> createTask(int CropsId, string Description, DateOnly DateTask, int StateTasksId, int UserId);
        Task<Tasks> updateTask(Tasks tasks);
        Task<Tasks> deleteTask(int TasksId);
    }

    public class TasksRepository : ITasksRepository
    {

        private readonly PapalandiaDbContext _db;

        public TasksRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Tasks> createTask(int CropsId, string Description, DateOnly DateTask, int StateTasksId, int UserId)
        {

            Tasks newTasks = new Tasks
            {
                CropsId = CropsId,
                Description = Description,
                DateTask = DateTask,
                StateTasksId = StateTasksId,
                UserId = UserId
            };

            _db.Tasks.Add(newTasks);
            await _db.SaveChangesAsync();

            return newTasks;

        }

        public async Task<List<Tasks>> getTasks()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<Tasks> getTask(int TasksId)
        {
            return await _db.Tasks.Where(u => u.TasksId == TasksId).FirstOrDefaultAsync();
        }

        public async Task<Tasks> updateTask(Tasks tasks)
        {
            _db.Tasks.Update(tasks);
            await _db.SaveChangesAsync();
            return tasks;
        }

        public async Task<Tasks> deleteTask(int tasksId)
        {
            Tasks taskdelete = await _db.Tasks.FindAsync(tasksId);
            if (taskdelete == null)
            {
                return null;
            }
            _db.Tasks.Remove(taskdelete);
            await _db.SaveChangesAsync();
            return taskdelete;
        }


    }
}
