using FoccoEmFrente.Kanban.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoccoEmFrente.Kanban.Application.Mapping
{
    public class PostitMap : IEntityTypeConfiguration<Postit>
    {
        public void Configure(EntityTypeBuilder<Postit> builder)
        {
            builder.ToTable("Postits");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.User)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(c => c.UserId)
                .IsRequired();
        }
    }
}
