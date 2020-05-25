using Data;
using System;
using System.Collections.Generic;


namespace Service
{
   public  interface IRecipeService
    {
        IEnumerable<RecipeEntity> GetAll();
        RecipeEntity Get(Guid id);
        void Insert(RecipeEntity recipe);
        void Update(RecipeEntity recipe);
        void Delete(Guid id);
    }
}
