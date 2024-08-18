using CSharpFunctionalExtensions;
using Pet_Search.Domain.Entities.VolunteerContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Application.Volunteers;

public interface IVolunteerRepository
{
	Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
	Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId);
	Task<Result<Volunteer, Error>> GetByFullName(PhoneNumber phoneNumber);
}
