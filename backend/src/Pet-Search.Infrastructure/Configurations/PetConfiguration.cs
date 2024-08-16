using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet_Search.Domain.Entities.PetContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.PetVO;

namespace Pet_Search.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
	public void Configure(EntityTypeBuilder<Pet> builder)
	{
		builder.ToTable("pets");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			.HasConversion(
				id => id.Value,
				value => PetId.Create(value));  // запиши в бд GUID, а когда будешь возвращать значения из БД, то верни PetId

		builder.Property(v => v.Description)
			.IsRequired()
			.HasMaxLength(Constants.MAX_HIGH_LENGTH);

		builder.Property(v => v.Name)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.Type)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.Breed)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.Color)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.HealthInfo)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.Address)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.Weight)
			.IsRequired();

		builder.Property(v => v.Height)
			.IsRequired();

		builder.Property(v => v.PhoneNumber)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

		builder.Property(v => v.IsCastrated)
			.IsRequired();

		builder.Property(v => v.DateOfBirth)
			.IsRequired();

		builder.Property(v => v.IsVaccinated)
			.IsRequired();


		builder.OwnsOne(v => v.RequisiteList, vb =>
		{
			vb.ToJson();
			vb.OwnsMany(l => l.Requisites, rb =>
			{
				rb.Property(r => r.Name)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);
				rb.Property(r => r.Description)
				.IsRequired()
				.HasMaxLength(Constants.MAX_HIGH_LENGTH);

			});
		});

	}
}
