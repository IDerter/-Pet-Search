namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record SocialNetwork
{
	public string Link { get; private set; } = string.Empty;
	public string Name { get; private set; } = string.Empty;
}

