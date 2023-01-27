using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Helpers;
using MusicApi.Models;
using System.Linq;

namespace MusicApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistsController : ControllerBase
	{
		private ApiDbContext _dbContext;
		public ArtistsController(ApiDbContext dbContext)
		{
			_dbContext= dbContext;
		}

		[HttpPost]
		public async Task<IActionResult> Post(Artist artist)
		{
			//var imageUrl = await FileHelper.UploadImage(album.Image);
			//album.ImageUrl= album.ImageUrl;
			//Artist dataModel = new Artist();
			//dataModel.Name = artist.Name;
			//dataModel.Gander = artist.Gander;
			await _dbContext.Artists.AddAsync(artist);
			await _dbContext.SaveChangesAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet]
		public async Task<IActionResult> GetArtists()
		{
			var artists = await (from artist in _dbContext.Artists
								 select new
								 {
									 Id = artist.Id,
									 Name = artist.Name,
									 Gender = artist.Gander
								 }
								 ).ToListAsync();
			return Ok(artists);
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> ArtistDetails(int artistId)
		{
			var artistDetails = await _dbContext.Artists.Where(b => b.Id == artistId).Include(a=>a.Songs).ToListAsync();
			return Ok(artistDetails);
		}
	}
}
