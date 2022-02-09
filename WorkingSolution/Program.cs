// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkingSolution.Data;
using WorkingSolution.Services;

var host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		services.AddDbContext<ApplicationDbContext>(builder => builder
			.UseNpgsql(context.Configuration.GetConnectionString("Default"))
		);

		services.AddHostedService<StartupService>();
	})
	.Build();

await host.RunAsync();