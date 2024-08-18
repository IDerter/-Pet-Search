namespace Pet_Search.Domain.ValueObjects.BreedVO;

public record BreedId
{
	public BreedId(Guid value)
	{
		Value = value;
	}

	public Guid Value { get; }

	public static BreedId NewBreedId() => new(Guid.NewGuid());

	public static BreedId Empty() => new(Guid.Empty);
	public static BreedId Create(Guid id) => new(id);
}
