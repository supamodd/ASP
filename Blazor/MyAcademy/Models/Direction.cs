using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[Index(nameof(direction_name), IsUnique = true)]
	public class Direction
	{
		[Key]
		[Column(TypeName = "tinyint")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int direction_id { get; set; }

		public string direction_name { get; set; } = string.Empty;

		public ICollection<Group> Groups { get; set; } = new List<Group>();

		public override string ToString() => direction_name;
	}
}
