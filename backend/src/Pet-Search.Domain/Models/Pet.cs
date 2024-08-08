namespace Pet_Search.Domain.Models
{
    public class Pet
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Type { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string Breed { get; } = string.Empty;
        public string Color { get; } = string.Empty;
        public string HealthInfo { get; } = string.Empty;
        public string Address { get; } = string.Empty;
        public double Weight { get; } = 0;
        public double Height { get; } = 0;
        public string PhoneNumber { get; } = string.Empty;
        public bool IsCastrated { get; } = false;
        public DateOnly DateOfBirth { get; } = DateOnly.MinValue;
        public bool IsVaccinated { get; } = false;
        public Status Status { get; } = new Status();
        public List<Requisites> Requisites { get; } = [];
        public DateTime CreatedDate { get; } = DateTime.Now;

    }
}
