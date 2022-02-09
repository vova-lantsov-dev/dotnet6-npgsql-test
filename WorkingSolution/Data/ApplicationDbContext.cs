using Microsoft.EntityFrameworkCore;
using WorkingSolution.Data.Models;

namespace WorkingSolution.Data;

public sealed class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<IncomingRequestHttp> IncomingRequestHttp { get; set; } = default!;
}