namespace Pet_Search.Domain.ValueObjects;

public record PhoneNumber
{
	public string CountryCode { get; } = string.Empty;
	public string AreaCode { get; } = string.Empty;
}
