using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksEmployeeTasksRepository:IDisposable
    {
       public IEnumerable<TasksEmployeeTasks> GetTasksEmployeesTaskss();
        public TasksEmployeeTasks GetTasksEmployeesTasksByID(int TasksSerielId);
        public void InsertTasksEmployeesTasks(TasksEmployeeTasks TasksEmployeeTasks);
        public void DeleteTasksEmployeesTaskss(int TasksSerielId);
        public void UpdateTasksEmployeesTaskss(TasksEmployeeTasks TasksEmployeeTasks);
        public void Save();
    }
}
