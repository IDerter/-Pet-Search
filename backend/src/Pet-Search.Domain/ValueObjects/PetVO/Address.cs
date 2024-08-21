using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;

namespace Pet_Search.Domain.ValueObjects.PetVO;

public record Address
{
	public const int MAX_LENGTH = 200;

    public Address(string city, string country, string postCode)
    {
        City = city;
		Country = country;
		PostCode = postCode;
    }

    public string City { get; } = string.Empty;
	public string Country { get; } = string.Empty;
	public string PostCode { get; } = string.Empty;

	public static Result<Address, Error> Create(string city, string country, string postCode)
	{
		if (string.IsNullOrWhiteSpace(city) || city.Length > MAX_LENGTH)
		{
			return Errors.General.ValueIsInvalid(nameof(City));
		}
		if (string.IsNullOrWhiteSpace(country) || country.Length > MAX_LENGTH)
		{
			return Errors.General.ValueIsInvalid(nameof(Country));
		}
		if (string.IsNullOrWhiteSpace(postCode) || postCode.Length > MAX_LENGTH)
		{
			return Errors.General.ValueIsInvalid(nameof(PostCode));
		}

		return new Address(city, country, postCode);
	}
}
