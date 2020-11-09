using Kinopoisk.Domain.Core;
using Kinopoisk.Domain.Interfaces;
using Kinopoisk.Infrastructure.Data;
using Kinopoisk.Infrastructure.Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinopoisk.Services.Movies
{
    public class SQLMovieRepository :EFGenericRepository<Movie>, IMovieRepository
    {
        private readonly KinopoiskDbContext _context;
        public SQLMovieRepository(KinopoiskDbContext kinopoiskDbContext) : base(kinopoiskDbContext)
        {
            _context = kinopoiskDbContext;
        }

        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.AsNoTracking()
                                       .AsQueryable()
                                       .Include(c => c.Actors).ThenInclude(t => t.Actor)
                                       .First(p => p.Id == id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        [Authorize]
        public Movie Like(int id)
        {
            Movie updmovie = _context.Movies.Find(id);
            updmovie.Rating += 1;
            _context.Entry(updmovie).State = EntityState.Modified;          
                _context.SaveChanges();        
            return updmovie;
        }




        public IOrderedQueryable<Movie> GetMovieOrdered(int options)
        {
            switch (options)
            {
                case 0:
                    {
                        return _context.Movies.OrderBy(m => m.Name);
                    }
                case 1:
                    {
                        return _context.Movies.OrderByDescending(m => m.Name);
                    }
                case 2:
                    {
                        return _context.Movies.OrderByDescending(m => m.ReleaseDate);
                    }
                case 3:
                    {
                        return _context.Movies.OrderBy(m => m.ReleaseDate);

                    }
                case 4:
                    {

                        return _context.Movies.OrderByDescending(m => m.Rating);
                    }
                case 5:
                    {
                        return _context.Movies.OrderBy(m => m.Rating);
                    }
                default: return null;
            }
        }
        public Movie Dislike(int id)
        {
            Movie updmovie = _context.Movies.Find(id);
            if (updmovie.Rating > 0)
            {
                updmovie.Rating -= 1;
                _context.Entry(updmovie).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return updmovie;
        }
    }
}
