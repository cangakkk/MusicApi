using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gander { get; set; }
		public ICollection<Song>? Songs  { get; set;}
	}
}
