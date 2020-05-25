using System;


namespace Web.Models
{
    public class RecipeVM : IViewModel
    {
        public Guid Id { get; set; }
        public int PersCount { get; set; }
        public string Title { get; set; }
        public int PrepDuration { get; set; }
        public int CookingDuration { get; set; }
        public int CoolingDuration { get; set; }
        public int WaitingDuration { get; set; }
        public int DifficultyLevel { get; set; }
        public string RecommendedAssociation { get; set; }
    }
}
