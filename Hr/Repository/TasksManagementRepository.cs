using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksManagementRepository : ITasksManagementRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksManagementRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksManagement> GetTasksManagements()
        {
            return _context.TasksManagement.ToList();
        }

        public TasksManagement GetTasksManagementByID(int Id)
        {
            return _context.TasksManagement.Find(Id);
        }

        public void InsertTasksManagements(TasksManagement TasksManagement)
        {
            _context.TasksManagement.Add(TasksManagement);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksManagements(TasksManagement TasksManagement)
        {
            _context.Entry(TasksManagement).State = EntityState.Modified;
        }

        public void DeleteTasksManagements(int ID)
        {
            TasksManagement TasksManagement = _context.TasksManagement.Find(ID);
            _context.TasksManagement.Remove(TasksManagement);
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
