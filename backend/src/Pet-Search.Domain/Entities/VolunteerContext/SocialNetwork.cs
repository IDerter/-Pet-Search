namespace Pet_Search.Domain.Entities.VolunteerContext;

public class SocialNetwork
{
	public Guid Id { get; private set; }
	public string Link { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
}

