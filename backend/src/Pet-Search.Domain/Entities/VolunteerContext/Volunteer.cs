﻿using Pet_Search.Domain.Entities.PetContext;
using Pet_Search.Domain.Shared;
using Pet_Search.Domain.ValueObjects.VolunteerVO;

namespace Pet_Search.Domain.Entities.VolunteerContext;

public class Volunteer : Entity<VolunteerId>
{
    // Ef Core
    private Volunteer(VolunteerId id) : base(id)
    {
    }

    private Volunteer(VolunteerId id, FullName fullName, string description, int ageExperience, int petsFoundHomeQuantity,
        int numberOfPetsLookingForHome, int numberOfPetsTreated, string phoneNumber) : base(id)
    {
        FullName = fullName;
        Description = description;
        AgeExperience = ageExperience;
        PetsFoundHomeQuantity = petsFoundHomeQuantity;
        NumberOfPetsLookingForHome = numberOfPetsLookingForHome;
        NumberOfPetsTreated = numberOfPetsTreated;
        PhoneNumber = phoneNumber;
    }

    public FullName FullName { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int AgeExperience { get; private set; }
    public int PetsFoundHomeQuantity { get; private set; }  // кол-во домашних животных, к-ые нашли дом
    public int NumberOfPetsLookingForHome { get; private set; } // кол-во домашних животных, к-ые ищут дом в данный момент
    public int NumberOfPetsTreated { get; private set; } // кол-во домашних животных, к-ые сейчас находятся на лечении
    public string PhoneNumber { get; private set; } = string.Empty;
    public List<SocialNetwork> SocialNetworks { get; private set; } = [];
	public RequisiteList? RequisiteList { get; private set; }
	public List<Pet> PetsOwnedVolunteer { get; private set; } = [];
}