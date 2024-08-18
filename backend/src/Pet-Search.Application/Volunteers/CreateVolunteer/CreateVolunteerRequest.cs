using Pet_Search.Domain.ValueObjects;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(string Name, string Surname, string Patronymic, 
	string Description, int AgeExperience, string CountryCode, string AreaCode, int PetsFoundHomeQuantity,
	int NumberOfPetsLookingForHome, int NumberOfPetsTreated, SocialNetworkList? NetworkList = default, RequisiteList? RequisiteList = default);

