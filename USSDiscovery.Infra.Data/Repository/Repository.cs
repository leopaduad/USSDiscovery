using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using USSDiscovery.Domain.Interfaces;
using USSDiscovery.Infra.Data.Context;

namespace USSDiscovery.Infra.Data.Repository
{
    public class Repository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly USSDiscoveryContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(USSDiscoveryContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            var s = SaveChanges();
        }
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
