using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastucture.Data.Mapping
{
    public class UserClaimsMap : BaseMap<UserClaims>
    {
        public override void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            base.Configure(builder);
            builder.ToTable("UserClaims");
            builder.Property(x => x.ClaimType).HasColumnName("ClaimType").HasMaxLength(50);
            builder.Property(x => x.ClaimValue).HasColumnName("ClaimValue").HasMaxLength(50);
        }
    }
}