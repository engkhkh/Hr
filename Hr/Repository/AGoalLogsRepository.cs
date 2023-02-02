using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Repository
{
    public class AGoalLogsRepository : IAGoalLogsRepository, IDisposable
    {
        private readonly hrContext _context;
        public AGoalLogsRepository(hrContext context)
        {
            _context = context;
        }

        public IEnumerable<AGoalsLogs> GetAGoalsLogs()
        {
            return _context.AGoalsLogs.ToList();
        }

        public AGoalsLogs GetAGoalsLogsByID(int Id)
        {
            return _context.AGoalsLogs.Find(Id);
        }

        public void InsertAGoalsLogs(AGoalsLogs AGoalsLogs)
        {
            _context.AGoalsLogs.Add(AGoalsLogs);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAGoalsLogs(AGoalsLogs AGoalsLogs)
        {
            _context.Entry(AGoalsLogs).State = EntityState.Modified;
        }

        public void DeleteAGoalsLogs(int ID)
        {
            AGoalsLogs AGoalsLogs = _context.AGoalsLogs.Find(ID);
            _context.AGoalsLogs.Remove(AGoalsLogs);
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
