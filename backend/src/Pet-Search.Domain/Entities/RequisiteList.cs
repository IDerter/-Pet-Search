namespace Pet_Search.Domain.Entities;

public record RequisiteList
{
	public List<Requisites> Requisites { get; private set; } = [];
}