using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinopoisk.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllObjects();
        TEntity GetObject(Func<TEntity, bool> predicate);
        TEntity FindById(int id);
        TEntity Add(TEntity Object);
        TEntity Delete(int id);
        TEntity Update(TEntity Object);
        IEnumerable<TEntity> Search(Func<TEntity, bool> predicate);

    }
}
