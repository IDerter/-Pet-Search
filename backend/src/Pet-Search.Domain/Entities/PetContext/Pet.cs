using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects;
using Pet_Search.Domain.ValueObjects.PetVO;

namespace Pet_Search.Domain.Entities.PetContext;

public class Pet : Shared.Entity<PetId>
{
	private readonly List<PetPhoto> _petPhotos = [];
	// Ef Core
	private Pet(PetId id) : base(id)
	{
	}

	public Pet(PetId id, string name, string type, string description, string color, HealthInfo healthInfo,
		Address address, double weight, double height, PhoneNumber phoneNumber, DateOnly dateOfBirth,
		Status status, DateTime createdDate) : base(id)
	{
		Name = name;
		Type = type;
		Description = description;
		Color = color;
		HealthInfo = healthInfo;
		Address = address;
		Weight = weight;
		Height = height;
		PhoneNumber = phoneNumber;
		DateOfBirth = dateOfBirth;
		Status = status;
		CreatedDate = createdDate;
	}

	public SpeciesBreedId SpeciesBreedId { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public string Type { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public string Color { get; private set; } = string.Empty;
	public HealthInfo HealthInfo { get; private set; }
	public Address Address { get; private set; }
	public double Weight { get; private set; }
	public double Height { get; private set; }
	public PhoneNumber PhoneNumber { get; private set; }
	public DateOnly DateOfBirth { get; private set; } = DateOnly.MinValue;
	public Status Status { get; private set; } = new Status();
	public RequisiteList? RequisiteList { get; private set; }
	public DateTime CreatedDate { get; private set; } = DateTime.Now;
	public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos;

	public UnitResult<Error> AddPetPhoto(PetPhoto photo)
	{
		_petPhotos.Add(photo);

		return Result.Success<Error>();
	}
}
