using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr.Interfaces;
using Hr.IRepository;
using Hr.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr.UnitOfWork
{
    public class UnitOfWork<t> : IunitOfWork<t> where t : class
    {
        public hrContext Context { get; }
        private IGenericRepository<t> _entity;
        public UnitOfWork(hrContext context)

        {
            Context = context;
        }





        public IGenericRepository<t> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<t>(Context));
            }


        }

        public void save()
        {
            Context.SaveChanges();
        }
    }
}
