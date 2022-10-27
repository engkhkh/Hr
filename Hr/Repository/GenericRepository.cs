using Hr.Interfaces;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.IRepository
{
    public class GenericRepository<t> :IGenericRepository<t> where t : class

    {
        public hrContext Context { get; }
        private DbSet<t> table = null;

        public GenericRepository(hrContext context)
        {
            this.Context = context;
            table = Context.Set<t>();
        }



        //

        public void delete(object id)
        {
            t existing = getbyid(id);
            table.Remove(existing);
        }

        public IEnumerable<t> GetAll()
        {
            return table.ToList();
        }
      

        public t getbyid(object id)
        {
            return table.Find(id);
        }

        public void insert(t entity)
        {
            table.Add(entity);
        }

        public void update(t entity)
        {
            table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<t> GetWithRawSql(string query, params object[] parameters)
        {
            return table.FromSqlRaw(query, parameters).ToList();
        }
       
    }
}
