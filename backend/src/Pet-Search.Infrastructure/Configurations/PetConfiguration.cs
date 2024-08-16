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

		builder.ComplexProperty(v => v.HealthInfo, hb =>
		{
			hb.Property(hb => hb.IsCastrated)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);
			hb.Property(hb => hb.IsVaccinated)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);
		});

		builder.ComplexProperty(v => v.Address, vb =>
		{
			vb.Property(p => p.PostCode)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);

			vb.Property(p => p.City)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);

			vb.Property(p => p.Country)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);
		});

		builder.Property(v => v.Weight)
			.IsRequired();

		builder.Property(v => v.Height)
			.IsRequired();

		builder.ComplexProperty(v => v.PhoneNumber, vb =>
		{
			vb.Property(vb => vb.CountryCode)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);

			vb.Property(vb => vb.AreaCode)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);
		});

		builder.Property(v => v.DateOfBirth)
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
