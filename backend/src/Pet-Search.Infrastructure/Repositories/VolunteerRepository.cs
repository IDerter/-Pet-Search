using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Pet_Search.Application.Volunteers;
using Pet_Search.Domain.Entities.VolunteerContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Infrastructure.Repositories;

public class VolunteerRepository : IVolunteerRepository
{
	private readonly ApplicationDbContext _context;

	public VolunteerRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
	{
		await _context.Volunteers.AddAsync(volunteer, cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);

		return volunteer.Id.Value;
	}

	public async Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId)
	{
		var volunteer = await _context.Volunteers.FindAsync(volunteerId);

		if (volunteer == null)
		{
			return Errors.General.NotFound(volunteerId.Value);
		}

		return volunteer;
	}

	public async Task<Result<Volunteer, Error>> GetByFullName(FullName fullName)
	{
		var volunteer = await _context.Volunteers.FirstOrDefaultAsync(v => v.FullName == fullName);

		if (volunteer == null)
		{
			return Errors.General.NotFound();
		}

		return volunteer;
	}

}
