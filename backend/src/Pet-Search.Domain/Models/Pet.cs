namespace Pet_Search.Domain.Models;

public class Pet
{
    public Guid Id { get; private set; }
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
    public List<Requisites> Requisites { get; private set; } = [];
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public List<PetPhoto> PetPhotos { get; private set; } = [];
}

