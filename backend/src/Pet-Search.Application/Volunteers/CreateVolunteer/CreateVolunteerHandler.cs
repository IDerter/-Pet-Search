using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
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


		var volunteerResult = Volunteer.Create(volunteerId, fullName.Value, request.Description, request.AgeExperience,
			request.PetsFoundHomeQuantity, request.NumberOfPetsLookingForHome, request.NumberOfPetsTreated, phoneNumber.Value);
		if (volunteerResult.IsFailure)
		{
			return Errors.General.NotFound(volunteerId.Value);
		}

		var volunteerExist = await _volunteerRepository.GetByFullName(phoneNumber.Value);
		if (volunteerExist.IsSuccess)
		{
			return Errors.Volunteer.AlreadyExist();
		}

		await _volunteerRepository.Add(volunteerResult.Value, token);

		return volunteerId.Value;
		//валидация
		//создание доменной модели
		//сохранение в бд
	}
}
