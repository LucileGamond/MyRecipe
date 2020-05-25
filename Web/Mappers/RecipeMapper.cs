using Data;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Mappers
{
    public class RecipeMapper : IMapper<RecipeEntity, RecipeVM>
    {
        public RecipeEntity ToModel(RecipeVM recipeVM)
        {
            RecipeEntity recipe = new RecipeEntity();
            recipe.Id = recipeVM.Id;
            recipe.PrepDuration = recipeVM.PrepDuration;
            recipe.CookingDuration = recipeVM.CookingDuration;
            recipe.CoolingDuration = recipeVM.CoolingDuration;
            recipe.WaitingDuration = recipeVM.WaitingDuration;
            recipe.Title = recipeVM.Title;
            recipe.PersCount = recipeVM.PersCount;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            recipe.RecommendedAssociation = recipeVM.RecommendedAssociation;
            return recipe;
        }

        public List<RecipeEntity> ToModel(List<RecipeVM> recipeVMs)
        {
            List<RecipeEntity> recipes = new List<RecipeEntity>();
            foreach (RecipeVM recipeVM in recipeVMs)
            {
                recipes.Add(ToModel(recipeVM));
            }
            return recipes;
        }

        public RecipeVM ToViewModel(RecipeEntity recipe)
        {
            RecipeVM recipeVM = new RecipeVM();
            recipeVM.Id = recipe.Id;
            recipeVM.PrepDuration = recipe.PrepDuration;
            recipeVM.CookingDuration = recipe.CookingDuration;
            recipeVM.CoolingDuration = recipe.CoolingDuration;
            recipeVM.WaitingDuration = recipe.WaitingDuration;
            recipeVM.Title = recipe.Title;
            recipeVM.PersCount = recipe.PersCount;
            recipeVM.DifficultyLevel = recipe.DifficultyLevel;
            recipeVM.RecommendedAssociation = recipe.RecommendedAssociation;
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
