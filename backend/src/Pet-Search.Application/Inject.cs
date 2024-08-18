using Microsoft.Extensions.DependencyInjection;
using Pet_Search.Application.Volunteers.CreateVolunteer;

namespace Pet_Search.Application;

public static class Inject
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<CreateVolunteerHandler>();

		return services;
	}
}
