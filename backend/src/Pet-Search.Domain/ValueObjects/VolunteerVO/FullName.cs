namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record FullName
{
    private FullName() { }

    private FullName(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public string Name { get; } = string.Empty;
    public string Surname { get; } = string.Empty;
    public string Patronymic { get; } = string.Empty;
}
