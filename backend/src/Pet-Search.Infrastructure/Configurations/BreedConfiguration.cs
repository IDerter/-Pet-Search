using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet_Search.Domain.Entities.BreedContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.BreedVO;

namespace Pet_Search.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
	public void Configure(EntityTypeBuilder<Breed> builder)
	{
		builder.ToTable("breeds");

		builder.HasKey(x => x.Id);
		builder.Property(b => b.Id)
			.HasConversion(
				id => id.Value,
				value => BreedId.Create(value));  // запиши в бд GUID, а когда будешь возвращать значения из БД, то верни BreedId

		builder.Property(b => b.Name)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(b => b.Description)
			.IsRequired()
			.HasMaxLength(Constants.MAX_HIGH_LENGTH);
	}
}
