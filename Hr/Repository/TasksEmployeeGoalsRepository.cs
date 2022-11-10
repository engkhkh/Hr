using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksEmployeeGoalsRepository : ITasksEmployeeGoalsRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksEmployeeGoalsRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksEmployeeGoals> GetTasksEmployeesGoals()
        {
            return _context.TasksEmployeeGoals.ToList();
        }

        public TasksEmployeeGoals GetTasksEmployeesGoalsByID(int Id)
        {
            return _context.TasksEmployeeGoals.Find(Id);
        }

        public void InsertTasksEmployeesGoals(TasksEmployeeGoals TasksEmployeeGoals)
        {
            _context.TasksEmployeeGoals.Add(TasksEmployeeGoals);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksEmployeesGoals(TasksEmployeeGoals TasksEmployeeGoals)
        {
            _context.Entry(TasksEmployeeGoals).State = EntityState.Modified;
        }

        public void DeleteTasksEmployeesGoals(int ID)
        {
            TasksEmployeeGoals TasksEmployeeGoals = _context.TasksEmployeeGoals.Find(ID);
            _context.TasksEmployeeGoals.Remove(TasksEmployeeGoals);
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
