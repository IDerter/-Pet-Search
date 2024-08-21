using Microsoft.Extensions.DependencyInjection;
using Pet_Search.Application.Volunteers;
using Pet_Search.Infrastructure.Repositories;

namespace Pet_Search.Infrastructure;

public static class Inject
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped<ApplicationDbContext>();

		services.AddScoped<IVolunteerRepository, VolunteerRepository>();

		return services;
	}
}
