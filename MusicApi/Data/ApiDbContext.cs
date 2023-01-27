using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Data
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> option): base(option) 
		{
			
		}

		public DbSet<Song> Songs { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Album> Albums { get; set; }
		
	}
}
