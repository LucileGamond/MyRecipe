using Data;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Mappers
{
    public class RecipeMapper : IMapper<RecipeEntity, RecipeVM, RecipeListVM>
    {

        public RecipeEntity ToModel(RecipeVM recipeVM)
        {
            RecipeEntity recipe = new RecipeEntity();
            recipe.Id = recipeVM.Id;
            recipe.PrepDuration = recipeVM.PrepDuration;
            recipe.CookingDuration = recipeVM.CookingDuration;
            recipe.Title = recipeVM.Title;
            recipe.PersCount = recipeVM.PersCount;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            return recipe;
        }
        public RecipeEntity ToModel(RecipeListVM recipeVM)
        {
            RecipeEntity recipe = new RecipeEntity();
            recipe.Id = recipeVM.Id;
            recipe.PrepDuration = recipeVM.PrepDuration;
            recipe.CookingDuration = recipeVM.CookingDuration;
            recipe.Title = recipeVM.Title;
            recipe.PersCount = recipeVM.PersCount;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            return recipe;
        }
        public List<RecipeEntity> ToModel(List<RecipeListVM> recipeVMs)
        {
            List<RecipeEntity> recipes = new List<RecipeEntity>();
            foreach (RecipeListVM recipeVM in recipeVMs)
            {
                recipes.Add(ToModel(recipeVM));
            }
            return recipes;
        }

        public RecipeListVM ToListViewModel(RecipeEntity recipe)
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

        public List<RecipeListVM> ToListViewModel(List<RecipeEntity> recipes)
        {
            List<RecipeListVM> recipeVMs = new List<RecipeListVM>();
            foreach (RecipeEntity recipe in recipes)
            {
                recipeVMs.Add(ToListViewModel(recipe));
            }
            return recipeVMs;
        }

        public RecipeVM ToViewModel(RecipeEntity recipe)
        {
            RecipeVM recipeVM = new RecipeVM();
            recipeVM.Id = recipe.Id;
            recipeVM.PrepDuration = recipe.PrepDuration;
            recipeVM.CookingDuration = recipe.CookingDuration;
            recipeVM.Title = recipe.Title;
            recipeVM.PersCount = recipe.PersCount;
            recipeVM.DifficultyLevel = recipe.DifficultyLevel;
            return recipeVM;
        }

        public List<RecipeVM> ToViewModel(List<RecipeEntity> recipes)
        {
            List<RecipeVM> recipeVMs = new List<RecipeVM>();
            foreach (RecipeEntity recipe in recipes)
            {
                recipeVMs.Add(ToViewModel(recipe));
            }
            return recipeVMs;
        }
    }
}
