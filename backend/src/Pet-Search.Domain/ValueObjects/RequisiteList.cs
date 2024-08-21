namespace Pet_Search.Domain.ValueObjects;

public record RequisiteList
{
	public RequisiteList()
	{

	}
	public RequisiteList(List<Requisite> requisites)
	{
		Requisites = requisites;
	}

	public List<Requisite> Requisites { get; } = [];
}