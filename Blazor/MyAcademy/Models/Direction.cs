using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	// Направление обучения
	[Index(nameof(direction_name), IsUnique = true)]
	public class Direction
	{
		[Key]
		[Column(TypeName = "tinyint")]
		// Id вводится вручную: в БД столбец не IDENTITY.
		// Если в вашей БД direction_id - IDENTITY, удалите следующую строку:
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int direction_id { get; set; }

		[Required]
		public string direction_name { get; set; } = string.Empty;

		// Navigation properties:
		public ICollection<Group> Groups { get; set; } = new List<Group>();

		public override string ToString() => direction_name;
	}
}
