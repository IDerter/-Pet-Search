using CSharpFunctionalExtensions;
using Pet_Search.Domain.Entities.VolunteerContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
	private readonly IVolunteerRepository _volunteerRepository;

	public CreateVolunteerHandler(IVolunteerRepository volunteerRepository)
	{
		_volunteerRepository = volunteerRepository;
	}

	public async Task<Result<Guid, Error>> HandleAsync(CreateVolunteerRequest request, CancellationToken token = default)
	{
		var volunteerId = VolunteerId.NewVolunteerId();
		var fullName = FullName.Create(request.Name, request.Surname, request.Patronymic);

		if (fullName.IsFailure)
		{
			return fullName.Error;
		}

		var phoneNumber = PhoneNumber.Create(request.CountryCode, request.AreaCode);
		if (phoneNumber.IsFailure)
		{
			return phoneNumber.Error;
		}

		var volunteerExist = await _volunteerRepository.GetByPhoneNumber(phoneNumber.Value);
		if (volunteerExist.IsSuccess)
		{
			return Errors.Volunteer.AlreadyExist();
		}

		var requisitesResult = request.RequisitesDto?.Select(r => Requisite.Create(r.Name, r.Description)).ToList();

		if (requisitesResult != null && requisitesResult.Any(r => r.IsFailure))
		{
			return Errors.General.ValueIsRequired("Name or Descriptions");
		}
		var requisites = new RequisiteList(requisitesResult?.Select(r => r.Value).ToList());

		var socialNetworksResult = request.SocialNetworksDto?.Select(s => SocialNetwork.Create(s.Link, s.Name)).ToList();
		if (socialNetworksResult != null && socialNetworksResult.Any(r => r.IsFailure))
		{
			return Errors.General.ValueIsRequired("Link or Name");
		}
		var socialNetworks = new SocialNetworkList(socialNetworksResult?.Select(s => s.Value).ToList());

		var volunteerResult = Volunteer.Create(
			volunteerId,
			fullName.Value,
			request.Description,
			request.AgeExperience,
			request.PetsFoundHomeQuantity,
			request.NumberOfPetsLookingForHome,
			request.NumberOfPetsTreated,
			phoneNumber.Value,
			socialNetworks,
			requisites);

		if (volunteerResult.IsFailure)
		{
			return volunteerResult.Error;
		}

		await _volunteerRepository.Add(volunteerResult.Value, token);

		return volunteerId.Value;
	}
}
