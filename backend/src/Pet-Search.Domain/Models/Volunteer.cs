using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Search.Domain.Models
{
	public class Volunteer
	{
		public Guid Id { get; }
		public string Name { get; } = string.Empty;
		public string Surname { get; } = string.Empty;
		public string Patronymic { get; } = string.Empty;
		public string Description { get; } = string.Empty;
		public int AgeExperience { get; } = 0;
		public int NumberOfPetsFindHome { get; } = 0; // кол-во домашних животных, к-ые нашли дом
		public int NumberOfPetsLookingForHome { get; } = 0; // кол-во домашних животных, к-ые ищут дом в данный момент
		public int NumberOfPetsTreated { get; } = 0; // кол-во домашних животных, к-ые сейчас находятся на лечении
		public string PhoneNumber { get; } = string.Empty;
		public List<SocialNetwork> SocialNetworks { get; } = new List<SocialNetwork>();
		public List<Requisites> Requisites { get; } = new List<Requisites>();
		public List<Pet> PetsOwnedVolunteer { get; } = new List<Pet>();
	}
}
