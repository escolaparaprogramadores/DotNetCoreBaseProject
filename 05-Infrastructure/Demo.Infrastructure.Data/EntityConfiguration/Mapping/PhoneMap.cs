using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastucture.Data.Mapping
{
    public class PhoneMap : BaseMap<Phone>
    {
        public override void Configure(EntityTypeBuilder<Phone> builder)
        {
            base.Configure(builder);
            builder.ToTable("Phone");
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        }
        
    }
}