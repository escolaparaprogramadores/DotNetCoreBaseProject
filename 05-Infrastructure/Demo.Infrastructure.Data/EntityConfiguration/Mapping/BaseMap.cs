using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastucture.Data.Mapping
{
    public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().HasColumnName("Id");
        }
    }
}