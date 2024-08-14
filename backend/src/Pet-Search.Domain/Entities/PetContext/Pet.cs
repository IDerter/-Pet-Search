using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.PetVO;

namespace Pet_Search.Domain.Entities.PetContext;

public class Pet : Entity<PetId>
{
    // Ef Core
    private Pet(PetId id) : base(id)
    {
    }

    public Pet(PetId id, string name, string type, string description, string breed, string color, string healthInfo,
        string address, double weight, double height, string phoneNumber, bool isCastrated, DateOnly dateOfBirth,
        bool isVacinated, Status status, DateTime createdDate) : base(id)
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
        IsCastrated = isCastrated;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVacinated;
        Status = status;
        CreatedDate = createdDate;
    }

    public string Name { get; private set; } = string.Empty;
    public string Type { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Breed { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public string HealthInfo { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string PhoneNumber { get; private set; } = string.Empty;
    public bool IsCastrated { get; private set; } = false;
    public DateOnly DateOfBirth { get; private set; } = DateOnly.MinValue;
    public bool IsVaccinated { get; private set; } = false;
    public Status Status { get; private set; } = new Status();
    public RequisiteList? RequisiteList { get; private set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public List<PetPhoto> PetPhotos { get; private set; } = [];
}
