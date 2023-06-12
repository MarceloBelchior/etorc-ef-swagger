using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using torc.database.helper;
using torc.Iface;

namespace torc.database
{


    public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        protected torc.database.TorcDB dbContext;

        public BaseRepository(TorcDB _dbcontext) => dbContext = _dbcontext;


        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
            IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null)
        {
            try
            {
                IQueryable<TEntity> data = dbContext.Set<TEntity>();

                if (where != null)
                {
                    data = data.Where(where);
                }

                if (orderBy != null)
                {
                    bool isFirstSort = true;

                    orderBy.ToList().ForEach(one =>
                    {
                        data = one.ApplySort(data, isFirstSort);
                        isFirstSort = false;
                    });
                }

                if (skip > 0)
                {
                    data = data.Skip(skip);
                }
                if (top > 0)
                {
                    data = data.Take(top);
                }

                if (include != null)
                {
                   // data.Include(one)
                    include.ToList().ForEach(one => data = data.Include(one));
                }

                foreach (TEntity item in data)
                {
                    yield return item;
                }
            }
            finally
            {
            }
        }

        public TEntity SelectById(int id)
        {
            try
            {
                return dbContext.Set<TEntity>()
                    .Find(id);
            }
            finally
            {
            }
        }

        public virtual TEntity Insert(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = dbContext.Set<TEntity>();

                set.Add(item);

                if (saveImmediately)
                {
                    dbContext.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public TEntity Update(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = dbContext.Set<TEntity>();

                EntityEntry<TEntity> entry = dbContext.Entry(item);

                if (entry != null)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    set.Attach(item);

                    dbContext.Entry(item).State = EntityState.Modified;
                }

                if (saveImmediately)
                {
                    dbContext.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public void Delete(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = dbContext.Set<TEntity>();

                EntityEntry<TEntity> entry = dbContext.Entry(item);

                if (entry != null)
                {
                    entry.State = EntityState.Deleted;
                }
                else
                {
                    set.Attach(item);

                    dbContext.Entry(item).State = EntityState.Deleted;
                }

                if (saveImmediately)
                {
                    dbContext.SaveChanges();
                }
            }
            finally
            {
            }
        }

  
        public void Save()
        {
            dbContext.SaveChanges();

          
        }

      
    }
}
