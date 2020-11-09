using Kinopoisk.Domain.Core;
using Kinopoisk.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kinopoisk.Infrastructure.Data.Actors
{
    public class SQLActorRepository :Base.EFGenericRepository<Actor>, IActorRepository
    {
        private readonly KinopoiskDbContext _context;
        public int Options { get; set; }

        public SQLActorRepository(KinopoiskDbContext kinopoiskDbContext):base(kinopoiskDbContext)
        {
            _context = kinopoiskDbContext;
        }




        public IQueryable<Actor> GetActorOrdered(int options)
        {
            switch (options)
            {
                case 0:
                    {
                        return _context.Actors.OrderBy(m => m.Name);
                    }
                case 1:
                    {
                        //SortOrder.Ascending()
                        return _context.Actors.OrderBy(m => m.Birthday);
                    }
                case 2:
                    {

                        return _context.Actors.OrderByDescending(m => m.Name);
                    }
                case 3:
                    {
                        return _context.Actors.OrderByDescending(m => m.Birthday);
                    }
                case 4:
                    {
                        return _context.Actors.OrderByDescending(m => m.Rating);
                    }
                case 5:
                    {

                        return _context.Actors.OrderBy(m => m.Rating);
                    }
                default: return null;
            }
        }

        
        public Actor GetActor(int id)
        {
            var actor = _context.Actors.AsNoTracking()
                                      .AsQueryable()
                                      .Include(c => c.Movies).ThenInclude(t => t.Movie)
                                      .FirstOrDefault(p => p.Id == id);
            if (actor == null)
            {
                return null;
            }
            return actor;
        }

        [Authorize(Roles = "user")]
        public Actor Dislike(int id)
        {
            Actor updactor = _context.Actors.Find(id);
            if (updactor.Rating > 0) { 
              updactor.Rating -= 1;
              _context.Entry(updactor).State = EntityState.Modified;
              _context.SaveChanges();
            }
            return updactor;
        }

        [Authorize(Roles = "user")]
        public Actor Like(int id)
        {
            Actor updactor = _context.Actors.Find(id);
            updactor.Rating += 1;
            _context.Entry(updactor).State = EntityState.Modified;
            _context.SaveChanges();
            return updactor;
        }

        
    }
}
