using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Helpers;
using MusicApi.Models;

namespace MusicApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AlbumsController : ControllerBase
	{
		private ApiDbContext _dbContext;
		public AlbumsController(ApiDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromForm] Album album)
		{
			//artist.ImageUrl = artist.ImageUrl;
			await _dbContext.Albums.AddAsync(album);
			await _dbContext.SaveChangesAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet]
		public async Task<IActionResult> GetAlbums()
		{
			var artists = await (from album in _dbContext.Albums
								 select new
								 {
									 Id = album.Id,
									 Name = album.Name
								 }).ToListAsync();
			return Ok(artists);
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> AlbumDetails(int albumId)
		{
			var albumsDetails = await _dbContext.Albums.Where(b => b.Id == albumId).ToListAsync();
			return Ok(albumsDetails);
		}
	}
}
