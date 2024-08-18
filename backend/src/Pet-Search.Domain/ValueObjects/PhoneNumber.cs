using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.VolunteerVO;
using System.Xml.Linq;

namespace Pet_Search.Domain.ValueObjects;

public record PhoneNumber
{
	private PhoneNumber(string countryCode, string areaCode)
	{
		CountryCode = countryCode;
		AreaCode = areaCode;
	}

	public string CountryCode { get; } = string.Empty;
	public string AreaCode { get; } = string.Empty;

	public static Result<PhoneNumber, Error> Create(string countryCode, string areaCode)
	{
		if (string.IsNullOrWhiteSpace(countryCode) || countryCode.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(CountryCode));

		if (string.IsNullOrWhiteSpace(areaCode) || areaCode.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(AreaCode));

		return new PhoneNumber(countryCode, areaCode);
	}
}
