using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class RecipeEntity : BaseEntity
    {
        public int PersCount { get; set; }
        public string Title { get; set; }
        public int PrepDuration { get; set; }
        public int CookingDuration { get; set; }
        public int CoolingDuration { get; set; }
        public int WaitingDuration { get; set; }
        public string RecommendedAssociation { get; set; }

        public int DifficultyLevel { get; set; }
    }


}
