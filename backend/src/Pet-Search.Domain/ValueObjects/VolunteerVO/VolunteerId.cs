﻿namespace Pet_Search.Domain.ValueObjects.VolunteerVO;

public record VolunteerId
{
	public VolunteerId(Guid value)
	{
		Value = value;
	}

	public Guid Value { get; }

	public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());

	public static VolunteerId Empty() => new(Guid.Empty);
	public static VolunteerId Create(Guid id) => new(id);
}
