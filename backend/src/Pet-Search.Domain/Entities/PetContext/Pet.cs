using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects;
using Pet_Search.Domain.ValueObjects.PetVO;

namespace Pet_Search.Domain.Entities.PetContext;

public class Pet : Entity<PetId>
{
	// Ef Core
	private Pet(PetId id) : base(id)
	{
	}

	public Pet(string name, string type, string description, string breed, string color, HealthInfo healthInfo,
		Address address, double weight, double height, PhoneNumber phoneNumber, DateOnly dateOfBirth,
		Status status, DateTime createdDate) : base(id)
	{
		Name = name;
		Type = type;
		Description = description;
		Breed = breed;
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

	public string Name { get; private set; } = string.Empty;
	public string Type { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public string Breed { get; private set; } = string.Empty;
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
	public List<PetPhoto> PetPhotos { get; private set; } = [];
}
