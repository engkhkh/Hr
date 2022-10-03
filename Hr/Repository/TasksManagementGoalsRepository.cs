using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksManagementGoalsRepository : ITasksManagementGoalsRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksManagementGoalsRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksManagementGoals> GetTasksManagementsGoals()
        {
            return _context.TasksManagementGoals.ToList();
        }

        public TasksManagementGoals GetTasksManagementsGoalsByID(int Id)
        {
            return _context.TasksManagementGoals.Find(Id);
        }

        public void InsertTasksManagementsGoals(TasksManagementGoals TasksManagementGoals)
        {
            _context.TasksManagementGoals.Add(TasksManagementGoals);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksManagementsGoals(TasksManagementGoals TasksManagementGoals)
        {
            _context.Entry(TasksManagementGoals).State = EntityState.Modified;
        }

        public void DeleteTasksManagementsGoals(int ID)
        {
            TasksManagementGoals TasksManagementGoals = _context.TasksManagementGoals.Find(ID);
            _context.TasksManagementGoals.Remove(TasksManagementGoals);
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
