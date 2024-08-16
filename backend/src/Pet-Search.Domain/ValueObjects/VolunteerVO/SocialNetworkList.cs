namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record SocialNetworkList
{
	public List<SocialNetwork> Networks { get; private set; } = [];
}
