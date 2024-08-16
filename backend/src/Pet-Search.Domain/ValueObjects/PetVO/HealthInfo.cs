namespace Pet_Search.Domain.ValueObjects.PetVO;

public record HealthInfo
{
	public bool IsCastrated { get; private set; } = false;
	public bool IsVaccinated { get; private set; } = false;
}
