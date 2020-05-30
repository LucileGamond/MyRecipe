using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service;
using Web.Mappers;
using Web.Models;

namespace Web.Controllers
{
    public class RecipeController : Controller
    {


        private  IRecipeService _recipeService;
     
        private RecipeMapper _recipeMapper;

        public RecipeController(IRecipeService recipeService)
        {
            this._recipeService = recipeService;
            this._recipeMapper = new RecipeMapper();
        }

        // GET: Receipe
        public async Task<IActionResult> List()
        {          
            IList<Recipe> recipes = await _recipeService.GetAll();
            IList<RecipeListVM> model = new List<RecipeListVM>();
            model = _recipeMapper.ToListViewModel(recipes);
            return View(model);
        }

        // GET: Receipe/Details/5
        public async Task<IActionResult> Details(Guid Id)
        {
            Recipe recipe = await _recipeService.Get(Id);
            RecipeVM model = _recipeMapper.ToViewModel(recipe);
            return View(model);
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
        public async Task<IActionResult> New(RecipeVM recipeVM)
        {
            try
            {
                Recipe recipeEntity = _recipeMapper.ToModel(recipeVM);
                await _recipeService.Add(recipeEntity);
                if (recipeEntity.Id != Guid.Empty)
                {
                    return RedirectToAction("List");
                }
                return View(recipeVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            Recipe recipe = await _recipeService.Get(Id);
            RecipeVM model = _recipeMapper.ToViewModel(recipe);
            return View(model);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecipeVM recipeVM)
        {
            try
            {
                Recipe recipe = _recipeMapper.ToModel(recipeVM);
                _recipeService.Update(recipe);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        // POST: Recipe/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _recipeService.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

    }
}