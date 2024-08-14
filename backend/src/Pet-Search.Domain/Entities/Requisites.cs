namespace Pet_Search.Domain.Entities;

public record Requisites
{
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
}

