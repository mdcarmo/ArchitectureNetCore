using ArchitectureNetCore.Data.EF.Context;
using ArchitectureNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchitectureNetCore.Data.EF
{
    public class RepositoryBaseEF<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext db;

        public RepositoryBaseEF()
        {
            db = new AppDbContext();
        }

        public virtual void Add(TEntity obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int? id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
