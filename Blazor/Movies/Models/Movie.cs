using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Впишите название фильма")]
		[StringLength(50, MinimumLength = 2)]
		[DisplayName("Название")]	//В Blazor НЕ работает
		public string Title { get; set; }

		[Range(typeof(DateOnly), "1888-10-14", "2032-12-31")]
		public DateOnly ReleaseDate { get; set; }
		public string Genre { get; set; }
		public string? URL { get; set; }
		public string? Poster { get; set; }
	}
}
