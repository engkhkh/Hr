using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface ITasksEmployeeGoalsRepository:IDisposable
    {
       public IEnumerable<TasksEmployeeGoals> GetTasksEmployeesGoals();
        public TasksEmployeeGoals GetTasksEmployeesGoalsByID(int TasksSerielId);
        public void InsertTasksEmployeesGoals(TasksEmployeeGoals TasksEmployeeGoals);
        public void DeleteTasksEmployeesGoals(int TasksSerielId);
        public void UpdateTasksEmployeesGoals(TasksEmployeeGoals TasksEmployeeGoals);
        public void Save();
    }
}
