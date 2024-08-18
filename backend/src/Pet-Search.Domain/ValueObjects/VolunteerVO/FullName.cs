using CSharpFunctionalExtensions;
using Pet_Search.Domain.Shared;

namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record FullName
{
	private FullName(string name, string surname, string patronymic)
	{
		Name = name;
		Surname = surname;
		Patronymic = patronymic;
	}

	public string Name { get; } = string.Empty;
	public string Surname { get; } = string.Empty;
	public string Patronymic { get; } = string.Empty;


	public static Result<FullName, Error> Create(string name, string surname, string patronymic)
	{
		if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(Name));

		if (string.IsNullOrWhiteSpace(surname) || surname.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(Surname));

		if (string.IsNullOrWhiteSpace(patronymic) || patronymic.Length > Constants.MAX_LOW_LENGTH)
			return Errors.General.ValueIsInvalid(nameof(Patronymic));

		return new FullName(name, surname, patronymic);
	}
}
