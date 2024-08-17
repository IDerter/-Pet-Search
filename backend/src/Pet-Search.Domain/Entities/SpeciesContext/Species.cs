using Pet_Search.Domain.Entities.BreedContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.BreedVO;
using Pet_Search.Domain.ValueObjects.SpeciesVO;

namespace Pet_Search.Domain.Entities.SpeciesContext;

public class Species : Entity<SpeciesId>
{
    public Species(SpeciesId id) : base(id)
    {
    }

    public Species(SpeciesId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public List<Breed> ListBreeds { get; private set; } = [];
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

}
