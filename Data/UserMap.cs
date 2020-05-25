using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data
{
     public class UserMap
    {
        public UserMap(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.HasOne(t => t.UserProfile).WithOne(u => u.UserEntity).HasForeignKey<UserProfileEntity>(x => x.Id);
        }
    }


    
}
