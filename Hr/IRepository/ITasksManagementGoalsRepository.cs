using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksManagementGoalsRepository:IDisposable
    {
       public IEnumerable<TasksManagementGoals> GetTasksManagementsGoals();
        public TasksManagementGoals GetTasksManagementsGoalsByID(int TasksSerielId);
        public void InsertTasksManagementsGoals(TasksManagementGoals TasksManagementGoals);
        public void DeleteTasksManagementsGoals(int TasksSerielId);
        public void UpdateTasksManagementsGoals(TasksManagementGoals TasksManagementGoals);
        public void Save();
    }
}
