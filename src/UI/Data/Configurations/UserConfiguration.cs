using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Models.Entities;
using UI.Models.Entities.Enums;

namespace UI.Data.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Password).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(12);
            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.CreatedAt).IsRequired();


            builder.HasData(
                new User { Id = 1, Username = "admin1", Password = "admin1", Role = RoleEnum.Admin, CreatedAt = new DateTime(2024, 06, 19, 0, 0, 0) },
                new User { Id = 2, Username = "admin2", Password = "admin2", Role = RoleEnum.Admin, CreatedAt = new DateTime(2024, 06, 29, 0, 0, 0) },
                new User { Id = 3, Username = "emad", Password = "emad", Role = RoleEnum.Customer, CreatedAt = new DateTime(2024, 07, 3, 0, 0, 0) },
                new User { Id = 4, Username = "ali", Password = "ali", Role = RoleEnum.Customer, CreatedAt = new DateTime(2024, 08, 14, 0, 0, 0) }
            );
        }
    }
}
