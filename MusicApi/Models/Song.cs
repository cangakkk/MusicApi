using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MusicApi.Models
{
	public class Song
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Duration { get; set; }
		public DateTime? UploadedDate { get; set; }
		public bool? IsFeatured { get; set; }
		//[ForeignKey("ArtistId")]
		public int? ArtistId { get; set; }
		//[ForeignKey("AlbumId")]
		public int? AlbumId { get; set; }
	}
}
