using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
	public class Album
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//[ForeignKey("ArtistId")]
		public int ArtistId { get; set; }
	}
}
