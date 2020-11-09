using Kinopoisk.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kinopoisk.Infrastructure.Data.Base
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly KinopoiskDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        /**********************************************************/
        /// <summary>
        /// Для вызова связанных данных
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        /*********************************************************/


        public EFGenericRepository(KinopoiskDbContext kinopoiskDbContext)
        {
            _context = kinopoiskDbContext;
            _dbSet = kinopoiskDbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity Object)
        {
            _dbSet.Add(Object);
            _context.SaveChanges();
            return Object;
        }

        public TEntity Delete(int id)
        {
            var objectdelete = _dbSet.Find(id);
            if (objectdelete != null)
                _dbSet.Remove(objectdelete);
            _context.SaveChanges();
            return objectdelete;
        }


        //TODO:Доделать
        public IEnumerable<TEntity> Search(Func<TEntity, bool> predicate)
        {
          return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAllObjects()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public TEntity Update(TEntity Object)
        {
            _context.Entry(Object).State = EntityState.Modified;
            _context.SaveChanges();
            return Object;
        }



        public TEntity GetObject(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(predicate);
        }

       
    

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
