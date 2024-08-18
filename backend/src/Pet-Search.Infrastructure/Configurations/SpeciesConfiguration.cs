using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet_Search.Domain.Entities.SpeciesContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.PetVO;
using Pet_Search.Domain.ValueObjects.SpeciesVO;

namespace Pet_Search.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
	public void Configure(EntityTypeBuilder<Species> builder)
	{
		builder.ToTable("species");

		builder.HasKey(s => s.Id);
		builder.Property(s => s.Id)
			.HasConversion(
				id => id.Value,
				value => SpeciesId.Create(value));  // запиши в бд GUID, а когда будешь возвращать значения из БД, то верни SpeciesId

		builder.HasMany(s => s.ListBreeds)
			.WithOne()
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(b => b.Name)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(b => b.Description)
			.IsRequired()
			.HasMaxLength(Constants.MAX_HIGH_LENGTH);

	}
}
