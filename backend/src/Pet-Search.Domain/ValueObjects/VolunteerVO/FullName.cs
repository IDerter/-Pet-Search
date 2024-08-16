namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record FullName
{
	public string Name { get; private set; } = string.Empty;
	public string Surname { get; private set; } = string.Empty;
	public string Patronymic { get; private set; } = string.Empty;
}
