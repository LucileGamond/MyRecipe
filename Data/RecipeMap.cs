using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class RecipeMap
    {
        public RecipeMap(EntityTypeBuilder<Recipe> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);          
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.PersCount);
            entityBuilder.Property(t => t.PrepDuration);
            entityBuilder.Property(t => t.CookingDuration);
            entityBuilder.Property(t => t.CoolingDuration);
            entityBuilder.Property(t => t.WaitingDuration);
            entityBuilder.Property(t => t.RecommendedAssociation);
            entityBuilder.Property(t => t.DifficultyLevel);
            entityBuilder.HasMany(t => t.Steps)
                         .WithOne(r => r.Recipe);
        }
    }
}

