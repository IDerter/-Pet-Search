using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;

namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record SocialNetwork
{
	public SocialNetwork(string link, string name)
	{
		Link = link;
		Name = name;
	}

	public string Link { get; } = string.Empty;
	public string Name { get; } = string.Empty;

	public static Result<SocialNetwork, Error> Create(string link, string name)
	{
		if (string.IsNullOrWhiteSpace(link))
			return Errors.General.ValueIsRequired("link");

		if (string.IsNullOrWhiteSpace(name))
			return Errors.General.ValueIsRequired("name");

		return new SocialNetwork(link, name);
	}
}

