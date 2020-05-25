using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfileEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
        }
    }
}
