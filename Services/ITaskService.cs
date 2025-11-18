using Test.Models;

namespace test.Services

{
    public interface ITaskService
    {
        Task<TaskItem> CreateTask(TaskItem task);
        Task<List<TaskItem>> GetAll();
        Task<TaskItem?> GetTaskById(int id);
        //Task<TaskItem?> UpdateAsync(int id, TaskItem task);
        //Task<bool> DeleteAsync(int id);
    }
}