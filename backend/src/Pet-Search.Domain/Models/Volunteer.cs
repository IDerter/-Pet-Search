using Pet_Search.Domain.ValueObjects;

namespace Pet_Search.Domain.Models;

public class Volunteer
{
	public Guid Id { get; private set; }
	public FullName FullName { get; private set; } = new FullName();
	public string Description { get; private set; } = string.Empty;
	public int AgeExperience { get; private set; } 
	public int PetsFoundHomeQuantity { get; private set; }  // кол-во домашних животных, к-ые нашли дом
	public int NumberOfPetsLookingForHome { get; private set; } // кол-во домашних животных, к-ые ищут дом в данный момент
	public int NumberOfPetsTreated { get; private set; } // кол-во домашних животных, к-ые сейчас находятся на лечении
	public string PhoneNumber { get; private set; } = string.Empty;
	public List<SocialNetwork> SocialNetworks { get; private set; } = [];
	public List<Requisites> Requisites { get; private set; } = [];
	public List<Pet> PetsOwnedVolunteer { get; private set; } = [];
}
