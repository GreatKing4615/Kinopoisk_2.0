using Kinopoisk.Domain.Core;
using Kinopoisk.Domain.Interfaces;
using Kinopoisk.Infrastructure.Data;
using Kinopoisk.Infrastructure.Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kinopoisk.Controllers
{
    
    public class ActorsController : Controller
    {
        
        UnitOfWork unitOfWork;

        public ActorsController(KinopoiskDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }


        // GET: Actors
        [HttpGet]

        public IActionResult Index(int options = 0 )
        {
           
                return View(unitOfWork.SQLActor.GetActorOrdered(options));
            
            
        }

        
        #region CRUD
        // GET: Actors/Details/5
        [Route("/Details/{id}")]
        public IActionResult Details(int id)
        {

            var actor = unitOfWork.SQLActor.GetActor(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }
            // GET: Actors/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Bio,Birthday,Rating,PhotoPath")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SQLActor.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public IActionResult Edit(int id)
        {

            var actor = unitOfWork.SQLActor.FindById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Bio,Birthday,Rating,PhotoPath")] Actor actor)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.SQLActor.Update(actor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        public IActionResult Delete(int id)
        {
           
            var actor = unitOfWork.SQLActor.FindById(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = unitOfWork.SQLActor.FindById(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Like(int id)
        {
            var actor = unitOfWork.SQLActor.Like(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dislike(int id)
        {
            var actor = unitOfWork.SQLActor.Dislike(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult SearchTerm(string term)
        {
            return RedirectToAction("Index1", unitOfWork.SQLActor.Search(x => x.Name.ToLower().Contains(term.ToLower())));
        }

        private bool ActorExists(int id)
        {
            if (unitOfWork.SQLActor.FindById(id)!=null)
                return true;
            return false;
        }
        
    }
}
