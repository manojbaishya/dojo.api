using Microsoft.EntityFrameworkCore;

namespace Dojo.Api;

public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) { }
