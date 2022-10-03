using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksEmployeeTaskssRepository : ITasksEmployeeTasksRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksEmployeeTaskssRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksEmployeeTasks> GetTasksEmployeesTaskss()
        {
            return _context.TasksEmployeeTasks.ToList();
        }

        public TasksEmployeeTasks GetTasksEmployeesTasksByID(int Id)
        {
            return _context.TasksEmployeeTasks.Find(Id);
        }

        public void InsertTasksEmployeesTasks(TasksEmployeeTasks TasksEmployeeTasks)
        {
            _context.TasksEmployeeTasks.Add(TasksEmployeeTasks);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksEmployeesTaskss(TasksEmployeeTasks TasksEmployeeTasks)
        {
            _context.Entry(TasksEmployeeTasks).State = EntityState.Modified;
        }

        public void DeleteTasksEmployeesTaskss(int ID)
        {
            TasksEmployeeTasks TasksEmployeeTasks = _context.TasksEmployeeTasks.Find(ID);
            _context.TasksEmployeeTasks.Remove(TasksEmployeeTasks);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
