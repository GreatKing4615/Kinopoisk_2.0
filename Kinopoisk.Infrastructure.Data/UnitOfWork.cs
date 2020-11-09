using Kinopoisk.Infrastructure.Data.Actors;
using Kinopoisk.Infrastructure.Data.Persons;
using Kinopoisk.Services.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinopoisk.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private KinopoiskDbContext db;
        private SQLActorRepository SQLActorRepository;
        private SQLMovieRepository SQLMovieRepository;
        private SQLPersonRepository SQLPersonRepository;

        public UnitOfWork(KinopoiskDbContext kinopoiskDbContext)
        {
            db = kinopoiskDbContext;
        }

        public SQLActorRepository SQLActor
        {
            get
            {
                if (SQLActorRepository == null)
                    SQLActorRepository = new SQLActorRepository(db);
                return SQLActorRepository;
            }
        }

        public SQLMovieRepository SQLMovie
        {
            get
            {
                if (SQLMovieRepository == null)
                    SQLMovieRepository = new SQLMovieRepository(db);
                return SQLMovieRepository;
            }
        }

        public SQLPersonRepository SQLPerson
        {
            get
            {
                if (SQLPersonRepository == null)
                    SQLPersonRepository = new SQLPersonRepository(db);
                return SQLPersonRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
