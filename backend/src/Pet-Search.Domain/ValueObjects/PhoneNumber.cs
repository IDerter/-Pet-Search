using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Search.Domain.ValueObjects;

[ComplexType]
public record PhoneNumber
{
	public string CountryCode { get; private set; } = string.Empty;
	public string AreaCode { get; private set; } = string.Empty;
}
