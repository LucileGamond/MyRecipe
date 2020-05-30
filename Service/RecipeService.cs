using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Service
{
    public class RecipeService : IRecipeService
    {

        private IRepository<Recipe> _recipeRepository;
        private IRepository<Step> _stepRepository;
        public  RecipeService(IRepository<Recipe> recipeRepository, IRepository<Step> stepRepository)
        {
            this._recipeRepository = recipeRepository;
            this._stepRepository = stepRepository;
        }

        public async Task Delete(Guid id)
        {
            //Delete steps related to the current recipe
            IList<Step> steps = await _stepRepository.GetAsync(x => x.Recipe.Id == id);
            await _stepRepository.DeleteAsync(steps);

            //Delete recipe
            Recipe recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
                throw new ApplicationException($"Recipe could not be loaded.");
            await _recipeRepository.DeleteAsync(recipe);
        }

        public async Task<Recipe> Get(Guid id)
        {
            Recipe recipe = await _recipeRepository.GetByIdAsync(id);
            recipe.Steps = await _stepRepository.GetAsync(x => x.Recipe.Id == id, q => q.OrderBy(s => s.Rank), string.Empty, true);
            return recipe;
        }

        public async Task<IList<Recipe>> GetAll()
        {
            return await _recipeRepository.GetAllAsync();
        }

        public async Task<Guid> Add(Recipe recipe)
        {
             return await _recipeRepository.AddAsync(recipe);
        }

        public async Task Update(Recipe recipe)
        {
            await _recipeRepository.UpdateAsync(recipe);
        }
    }
}
