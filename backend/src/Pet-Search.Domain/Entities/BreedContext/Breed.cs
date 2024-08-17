using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.BreedVO;

namespace Pet_Search.Domain.Entities.BreedContext;

public class Breed : Entity<BreedId>
{
	private Breed(BreedId id) : base(id)
	{
	}

	public Breed(BreedId id, string name, string description) : base(id)
	{
		Name = name;
		Description = description;
	}

	public string Name { get; private set; }
	public string Description { get; private set; }

}
