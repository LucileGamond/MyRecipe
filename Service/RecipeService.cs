using Data;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RecipeService : IRecipeService
    {

        private IRepository<RecipeEntity> _recipeRepository;

        public  RecipeService(IRepository<RecipeEntity> receipeRepository)
        {
            this._recipeRepository = receipeRepository;
        }


        public void Delete(Guid id)
        {
            RecipeEntity recipe =  _recipeRepository.Get(id);
            _recipeRepository.Delete(recipe);
        }

        public RecipeEntity Get(Guid id)
        {
            return _recipeRepository.Get(id);
        }

        public IEnumerable<RecipeEntity> GetAll()
        {
            return _recipeRepository.GetAll();
        }

        public void Insert(RecipeEntity recipe)
        {
             _recipeRepository.Insert(recipe);
        }

        public void Update(RecipeEntity recipe)
        {
            _recipeRepository.Update(recipe);
        }
    }
}
