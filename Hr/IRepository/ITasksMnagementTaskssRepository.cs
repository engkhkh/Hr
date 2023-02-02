using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksMnagementTaskssRepository: IDisposable
    {
       public IEnumerable<TasksManagementTasks> GetTasksManagementsTaskss();
        public TasksManagementTasks GetTasksManagementsTasksByID(int TasksSerielId);
        public void InsertTasksManagementsTasks(TasksManagementTasks TasksManagementTasks);
        public void DeleteTasksManagementsTaskss(int TasksSerielId);
        public void UpdateTasksManagementsTaskss(TasksManagementTasks TasksManagementTasks);
        public void Save();
    }
}
