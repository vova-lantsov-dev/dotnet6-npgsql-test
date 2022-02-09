using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkingSolution.Data;
using WorkingSolution.Data.Models;

namespace WorkingSolution.Services;

public sealed class StartupService : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public StartupService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await using AsyncServiceScope scope = _serviceProvider.CreateAsyncScope();

		var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		context.IncomingRequestHttp.Add(new IncomingRequestHttp(
			0,
			"Tag",
			"POST",
			"http://localhost",
			"{}",
			null,
			null,
			DateTime.Now));
		await context.SaveChangesAsync(cancellationToken);
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}