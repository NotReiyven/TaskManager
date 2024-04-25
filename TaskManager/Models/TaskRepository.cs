using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Models
{
    public class TaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public TaskRepository()
        {
            _tasks.Add(new Task { Id = 1, Title = "Task 1", Details = "Task 1 details", DueDate = DateTime.Now.AddDays(1), IsDone = false });
            _tasks.Add(new Task { Id = 2, Title = "Task 2", Details = "Task 2 details", DueDate = DateTime.Now.AddDays(2), IsDone = false });
            _tasks.Add(new Task { Id = 3, Title = "Task 3", Details = "Task 3 details", DueDate = DateTime.Now.AddDays(3), IsDone = true });
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTask(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Task task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Details = task.Details;
                existingTask.DueDate = task.DueDate;
                existingTask.IsDone = task.IsDone;
            }
        }

        public void DeleteTask(int id)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
            }
        }
    }
}
