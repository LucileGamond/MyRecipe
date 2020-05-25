using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;

namespace Web.Controllers
{
    public class RecipeController : Controller
    {
        private  IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this._recipeService = recipeService;
        }

        // GET: Receipe
        public ActionResult List()
        {
            List<RecipeListVM> model = new List<RecipeListVM>();
            var recipes = _recipeService.GetAll().ToList();
            recipes.ForEach(r =>
            {
                RecipeEntity userProfile = _recipeService.Get(r.Id);
                RecipeListVM recipe = new RecipeListVM
                {
                    Id = r.Id,
                    Title = r.Title,
                    DifficultyLevel = r.DifficultyLevel,
                    CookingDuration = r.CookingDuration,
                    PersCount = r.PersCount,
                    PrepDuration = r.PrepDuration
                };
                model.Add(recipe);
            });


            return View(model);
        }

        // GET: Receipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receipe/New
        public ActionResult New()
        {
            RecipeVM model = new RecipeVM();
            return View(model);
        }

        // POST: Receipe/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(RecipeVM model)
        {
            try
            {
                RecipeEntity recipeEntity = new RecipeEntity
                {
                    PersCount = model.PersCount,
                    Title = model.Title,
                    PrepDuration = model.PrepDuration,
                    CookingDuration= model.CookingDuration,
                    DifficultyLevel = model.DifficultyLevel
                };
                _recipeService.Insert(recipeEntity);
                if (recipeEntity.Id != Guid.Empty)
                {
                    return RedirectToAction("List");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _recipeService.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

    }
}