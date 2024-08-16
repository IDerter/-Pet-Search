namespace Pet_Search.Domain.ValueObjects.PetVO;

public record Address
{
	public string City { get; } = string.Empty;
	public string Country { get; } = string.Empty;
	public string PostCode { get; } = string.Empty;
}
