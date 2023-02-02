using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
  public interface IAGoalLogsRepository:IDisposable
    {
       public IEnumerable<AGoalsLogs> GetAGoalsLogs();
        public AGoalsLogs GetAGoalsLogsByID(int AGoalsLogsId);
        public void InsertAGoalsLogs(AGoalsLogs AGoalsLogs);
        public void DeleteAGoalsLogs(int AGoalsLogsID);
        public void UpdateAGoalsLogs(AGoalsLogs AGoalsLogs);
        public void Save();
    }
}
