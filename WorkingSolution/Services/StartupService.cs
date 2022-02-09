using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkingSolution.Data;

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
		_ = context.IncomingRequestHttp.First();
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}