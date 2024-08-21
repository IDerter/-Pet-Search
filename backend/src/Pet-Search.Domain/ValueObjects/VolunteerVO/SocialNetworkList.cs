namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record SocialNetworkList
{
	public SocialNetworkList()
	{

	}
	public SocialNetworkList(List<SocialNetwork> networks)
	{
		Networks = networks;
	}

	public List<SocialNetwork> Networks { get; } = [];
}
