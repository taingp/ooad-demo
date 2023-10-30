using BookLib;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookApi;

public class BookEntityTypeConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Title).IsUnique(true);

        builder.Property(x => x.Id)
            .IsRequired(true)
            .HasColumnType("varchar")
            .HasColumnName(nameof(Book.Id))
            .HasMaxLength(36)
            .IsUnicode(false)
            ;
        builder.Property(x => x.Title)
            .IsRequired(false)
            .HasColumnType("nvarchar")
            .HasColumnName(nameof(Book.Title))
            .HasMaxLength(50)
            .IsUnicode(true)
            ;
        builder.Property(x => x.Pages)
            .IsRequired(true)
            .HasColumnType("int")
            .HasColumnName(nameof(Book.Pages))
            ;
    }
}
