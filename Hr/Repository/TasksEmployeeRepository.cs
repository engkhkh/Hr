using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class TasksEmployeeRepository : ITasksEmployeeRepository, IDisposable
    {
        private readonly hrContext _context;
        public TasksEmployeeRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<TasksEmployee> GetTasksEmployees()
        {
            return _context.TasksEmployee.ToList();
        }

        public TasksEmployee GetTasksEmployeesByID(int Id)
        {
            return _context.TasksEmployee.Find(Id);
        }

        public void InsertTasksEmployees(TasksEmployee TasksEmployee)
        {
            _context.TasksEmployee.Add(TasksEmployee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTasksEmployees(TasksEmployee TasksEmployee)
        {
            _context.Entry(TasksEmployee).State = EntityState.Modified;
        }

        public void DeleteTasksEmployees(int ID)
        {
            TasksEmployee TasksEmployee = _context.TasksEmployee.Find(ID);
            _context.TasksEmployee.Remove(TasksEmployee);
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
