using Pet_Search.Domain.ValueObjects.BreedVO;
using Pet_Search.Domain.ValueObjects.SpeciesVO;

namespace Pet_Search.Domain.ValueObjects.PetVO;

public record SpeciesBreedId
{
	public SpeciesId SpeciesId { get; }
	public BreedId BreedId { get; }
}
