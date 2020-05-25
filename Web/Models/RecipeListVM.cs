using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class RecipeListVM : IViewModel
    {
        public Guid Id { get; set; }
        public int PersCount { get; set; }
        public string Title { get; set; }
        public int PrepDuration { get; set; }
        public int CookingDuration { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
