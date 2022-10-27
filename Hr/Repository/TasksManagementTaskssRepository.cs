using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksManagementTaskssRepository : ITasksMnagementTaskssRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksManagementTaskssRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksManagementTasks> GetTasksManagementsTaskss()
        {
            return _context.TasksManagementTasks.ToList();
        }

        public TasksManagementTasks GetTasksManagementsTasksByID(int Id)
        {
            return _context.TasksManagementTasks.Find(Id);
        }

        public void InsertTasksManagementsTasks(TasksManagementTasks TasksManagementTasks)
        {
            _context.TasksManagementTasks.Add(TasksManagementTasks);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksManagementsTaskss(TasksManagementTasks TasksManagementTasks)
        {
            _context.Entry(TasksManagementTasks).State = EntityState.Modified;
        }

        public void DeleteTasksManagementsTaskss(int ID)
        {
            TasksManagementTasks TasksManagementTasks = _context.TasksManagementTasks.Find(ID);
            _context.TasksManagementTasks.Remove(TasksManagementTasks);
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
