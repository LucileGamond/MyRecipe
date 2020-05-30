using Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
   public  interface IRecipeService
    {
        Task<IList<Recipe>> GetAll();
        Task<Recipe> Get(Guid id);
        Task<Guid> Add(Recipe recipe);
        Task Update(Recipe recipe);
        Task Delete(Guid id);
    }
}
