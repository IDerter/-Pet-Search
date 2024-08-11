namespace Pet_Search.Domain.ValueObjects;

public class FullName : ValueObject
{
	public string Name { get; private set; } = string.Empty;
	public string Surname { get; private set; } = string.Empty;
	public string Patronymic { get; private set; } = string.Empty;

	protected override IEnumerable<object> GetAtomicValues()
	{
		yield return Name;
		yield return Surname;
		yield return Patronymic;
	}
}
