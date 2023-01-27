using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Models;

namespace MusicApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongsController : ControllerBase
	{
		private ApiDbContext _dbContext;
		public SongsController(ApiDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromForm]Song song)
		{
			//artist.ImageUrl = artist.ImageUrl;
			song.UploadedDate = DateTime.Now;
			await _dbContext.Songs.AddAsync(song);
			await _dbContext.SaveChangesAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet]
		public async Task<IActionResult> GetArtists()
		{
			var songs = await (from s in _dbContext.Songs
								 select new
								 {
									 Id = s.Id,
									 Title = s.Title,
									 Duration = s.Duration,
									 ArtistId = s.ArtistId,
									 AlbumId = s.AlbumId
								 }
								 ).ToListAsync();
			return Ok(songs);
		}

	}
}
