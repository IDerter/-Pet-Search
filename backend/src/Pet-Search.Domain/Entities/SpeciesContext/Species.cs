using CSharpFunctionalExtensions;
using Pet_Search.Domain.Entities.BreedContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.SpeciesVO;

namespace Pet_Search.Domain.Entities.SpeciesContext;

public class Species : Shared.Entity<SpeciesId>
{
	private readonly List<Breed> _listBreeds = [];

	private Species(SpeciesId id) : base(id)
	{
	}

	public Species(SpeciesId id, string name, string description) : base(id)
	{
		Name = name;
		Description = description;
	}

	public IReadOnlyList<Breed> ListBreeds => _listBreeds;
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;

	public UnitResult<Error> AddBreeds(Breed breed)
	{
		_listBreeds.Add(breed);

		return Result.Success<Error>();
	}

}
