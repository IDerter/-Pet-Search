namespace Pet_Search.Domain.ValueObjects;

public class FullName : ValueObject
{
	public string Name { get; } = string.Empty;
	public string Surname { get; } = string.Empty;
	public string Patronymic { get; } = string.Empty;

	private FullName(string name, string surname, string patronymic)
	{
		Name = name;
		Surname = surname;
		Patronymic = patronymic;
	}

	protected override IEnumerable<object> GetAtomicValues()
	{
		yield return Name;
		yield return Surname;
		yield return Patronymic;
	}
}
