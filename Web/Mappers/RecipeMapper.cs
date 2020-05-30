using Data;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Mappers
{
    public class RecipeMapper : IMapper<Recipe, RecipeVM, RecipeListVM>
    {

        public Recipe ToModel(RecipeVM recipeVM)
        {
            Recipe recipe = new Recipe();
            recipe.Id = recipeVM.Id;
            recipe.PrepDuration = recipeVM.PrepDuration;
            recipe.CookingDuration = recipeVM.CookingDuration;
            recipe.Title = recipeVM.Title;
            recipe.PersCount = recipeVM.PersCount;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            recipe.Steps = recipeVM.Steps;
            return recipe;
        }
        public Recipe ToModel(RecipeListVM recipeVM)
        {
            Recipe recipe = new Recipe();
            recipe.Id = recipeVM.Id;
            recipe.PrepDuration = recipeVM.PrepDuration;
            recipe.CookingDuration = recipeVM.CookingDuration;
            recipe.Title = recipeVM.Title;
            recipe.PersCount = recipeVM.PersCount;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            return recipe;
        }
        public IList<Recipe> ToModel(IList<RecipeListVM> recipeVMs)
        {
            List<Recipe> recipes = new List<Recipe>();
            foreach (RecipeListVM recipeVM in recipeVMs)
            {
                recipes.Add(ToModel(recipeVM));
            }
            return recipes;
        }

        public RecipeListVM ToListViewModel(Recipe recipe)
        {
            RecipeListVM recipeVM = new RecipeListVM();
            recipeVM.Id = recipe.Id;
            recipeVM.PrepDuration = recipe.PrepDuration;
            recipeVM.CookingDuration = recipe.CookingDuration;
            recipeVM.Title = recipe.Title;
            recipeVM.PersCount = recipe.PersCount;
            recipeVM.DifficultyLevel = recipe.DifficultyLevel;
            return recipeVM;
        }

        public IList<RecipeListVM> ToListViewModel(IList<Recipe> recipes)
        {
            IList<RecipeListVM> recipeVMs = new List<RecipeListVM>();
            foreach (Recipe recipe in recipes)
            {
                recipeVMs.Add(ToListViewModel(recipe));
            }
            return recipeVMs;
        }

        public RecipeVM ToViewModel(Recipe recipe)
        {
            RecipeVM recipeVM = new RecipeVM();
            recipeVM.Id = recipe.Id;
            recipeVM.PrepDuration = recipe.PrepDuration;
            recipeVM.CookingDuration = recipe.CookingDuration;
            recipeVM.Title = recipe.Title;
            recipeVM.PersCount = recipe.PersCount;
            recipeVM.DifficultyLevel = recipe.DifficultyLevel;
            recipeVM.Steps = recipe.Steps;
            return recipeVM;
        }

        public IList<RecipeVM> ToViewModel(IList<Recipe> recipes)
        {
            IList<RecipeVM> recipeVMs = new List<RecipeVM>();
            foreach (Recipe recipe in recipes)
            {
                recipeVMs.Add(ToViewModel(recipe));
            }
            return recipeVMs;
        }
    }
}
