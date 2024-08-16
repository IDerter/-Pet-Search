namespace Pet_Search.Domain.ValueObjects.PetVO;

public record HealthInfo
{
	public bool IsCastrated { get; } = false;
	public bool IsVaccinated { get; } = false;
}
