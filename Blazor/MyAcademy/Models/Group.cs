using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	// Учебная группа
	public class Group
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int group_id { get; set; }

		[Required]
		public string group_name { get; set; } = string.Empty;

		[Required]
		[Column(TypeName = "tinyint")]
		[ForeignKey(nameof(Direction))]
		public int direction { get; set; }

		// Дни занятий хранятся битовой маской: 1-Пн, 2-Вт, 4-Ср, 8-Чт, 16-Пт, 32-Сб, 64-Вс
		[Column(TypeName = "tinyint")]
		public int learning_days { get; set; }

		public TimeOnly start_time { get; set; }

		// Navigation properties:
		public Direction? Direction { get; set; }

		public ICollection<Student> Students { get; set; } = new List<Student>();

		public override string ToString() => group_name;
	}
}
