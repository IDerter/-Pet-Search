namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record FullName
{
	public string Name { get; } = string.Empty;
	public string Surname { get; } = string.Empty;
	public string Patronymic { get; } = string.Empty;
}
