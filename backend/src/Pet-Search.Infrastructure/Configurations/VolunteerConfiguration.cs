using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet_Search.Domain.Entities.VolunteerContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
	public void Configure(EntityTypeBuilder<Volunteer> builder)
	{
		builder.ToTable("volunteers");

		builder.HasKey(v => v.Id);
		builder.Property(v => v.Id)
			.HasConversion(
				id => id.Value,
				value => VolunteerId.Create(value));  // запиши в бд GUID, а когда будешь возвращать значения из БД, то верни VolunteerId

		builder.OwnsOne(v => v.FullName, fb =>
		{
			fb.Property(fb => fb.Name)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

			fb.Property(fb => fb.Surname)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);

			fb.Property(fb => fb.Patronymic)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);
		});

		builder.Property(v => v.Description)
			.IsRequired()
			.HasMaxLength(Constants.MAX_HIGH_LENGTH);

		builder.Property(v => v.AgeExperience)
			.IsRequired();

		builder.Property(v => v.PetsFoundHomeQuantity)
			.IsRequired();

		builder.Property(v => v.NumberOfPetsTreated)
			.IsRequired();

		builder.Property(v => v.NumberOfPetsLookingForHome)
			.IsRequired();

		builder.HasMany(v => v.PetsOwnedVolunteer)
			.WithOne()
			.HasForeignKey("volunteer_id");

		builder.ComplexProperty(v => v.PhoneNumber, vb =>
		{
			vb.Property(vb => vb.CountryCode)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);

			vb.Property(vb => vb.AreaCode)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);
		});

		builder.OwnsOne(v => v.SocialNetworksList, vb =>
		{
			vb.ToJson();
			vb.OwnsMany(sn => sn.Networks, nb =>
			{
				nb.Property(nb => nb.Name)
				.IsRequired()
				.HasMaxLength(Constants.MAX_LOW_LENGTH);

				nb.Property(nb => nb.Link)
			.IsRequired()
			.HasMaxLength(Constants.MAX_LOW_LENGTH);
			});
		});

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
