using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksManagementRepository:IDisposable
    {
       public IEnumerable<TasksManagement> GetTasksManagements();
        public TasksManagement GetTasksManagementByID(int TasksSerielId);
        public void InsertTasksManagements(TasksManagement TasksManagement);
        public void DeleteTasksManagements(int TasksSerielId);
        public void UpdateTasksManagements(TasksManagement TasksManagement);
        public void Save();
    }
}
