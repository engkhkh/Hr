using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksEmployeeRepository:IDisposable
    {
       public IEnumerable<TasksEmployee> GetTasksEmployees();
        public TasksEmployee GetTasksEmployeesByID(int TasksSerielId);
        public void InsertTasksEmployees(TasksEmployee TasksEmployee);
        public void DeleteTasksEmployees(int TasksSerielId);
        public void UpdateTasksEmployees(TasksEmployee TasksEmployee);
        public void Save();
    }
}
