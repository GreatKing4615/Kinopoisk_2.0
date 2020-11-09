using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kinopoisk.Domain.Core;
using Kinopoisk.Infrastructure.Data;
using Kinopoisk.Domain.Interfaces;
using Kinopoisk.Infrastructure.Data.Base;

namespace Kinopoisk.Controllers
{
    public class MoviesController : Controller
    {
        UnitOfWork unitOfWork;
        

        public MoviesController(KinopoiskDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }
        #region CRUD
        // GET: Movies
        public IActionResult Index(int options=0)
        {
            return View(unitOfWork.SQLMovie.GetMovieOrdered(options));
        }

        // GET: Movies/Details/5
        [Route("Movies/Details/{id}")]
        public IActionResult Details(int id)
        {

            var movie = unitOfWork.SQLMovie.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // GET: Movies/Create        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Movies/Create")]
        public IActionResult Create([Bind("Id,Name,description,ReleaseDate,Rating,PhotoPath")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SQLMovie.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Route("/Movies/Edit/{id}")]
        public IActionResult Edit(int id)
        {

            var movie = unitOfWork.SQLMovie.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,description,ReleaseDate,Rating,PhotoPath")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.SQLMovie.Update(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            var movie = unitOfWork.SQLMovie.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // POST: Movies/Delete/5
        [Route("/Movies/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = unitOfWork.SQLMovie.FindById(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Like(int id)
        {
            var movie = unitOfWork.SQLMovie.Like(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dislike(int id)
        {
            var movie = unitOfWork.SQLMovie.Dislike(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            if (unitOfWork.SQLMovie.FindById(id) != null)
                return true;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
