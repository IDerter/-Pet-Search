using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;

namespace Pet_Search.Domain.ValueObjects;

public record Requisite
{
	public Requisite(string name, string description)
	{
		Name = name;
		Description = description;
	}

	public string Name { get; } = string.Empty;
	public string Description { get; } = string.Empty;

	public static Result<Requisite, Error> Create(string name, string description)
	{
		if (string.IsNullOrWhiteSpace(name))
			return Errors.General.ValueIsRequired("name");

		if (string.IsNullOrWhiteSpace(description))
			return Errors.General.ValueIsRequired("description");

		return new Requisite(name, description);
	}
}


