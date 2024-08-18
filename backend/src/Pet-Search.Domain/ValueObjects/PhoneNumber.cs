using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;
using System.Text.RegularExpressions;

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
		string pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";

		if (string.IsNullOrWhiteSpace(countryCode) || countryCode.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(CountryCode));

		if (string.IsNullOrWhiteSpace(areaCode) || areaCode.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(AreaCode));

		string resultPhone = countryCode + areaCode;
		if (!Regex.IsMatch(resultPhone, pattern))
			return Errors.General.ValueIsInvalid(resultPhone);

		return new PhoneNumber(countryCode, areaCode);
	}
}
