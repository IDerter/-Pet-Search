namespace Pet_Search.Domain.ValueObjects.PetVO;

public record PetId
{
	public PetId(Guid value)
	{
		Value = value;
	}

	public Guid Value { get; private set; }

	public static PetId NewPetId() => new(Guid.NewGuid());

	public static PetId Empty() => new(Guid.Empty);
	public static PetId Create(Guid id) => new(id);
}
