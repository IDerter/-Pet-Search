using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Search.Domain.ValueObjects.PetVO;

[ComplexType]
public record Address
{
	public string City { get; private set; } = string.Empty;
	public string Country { get; private set; } = string.Empty;
	public string PostCode { get; private set; } = string.Empty;
}
