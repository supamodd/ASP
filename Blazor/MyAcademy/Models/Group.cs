using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
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

		[Column(TypeName = "tinyint")]
		public int? weekdays { get; set; }

		public TimeOnly? start_time { get; set; }

		public DateOnly? start_date { get; set; }

		public Direction? Direction { get; set; }

		public ICollection<Student> Students { get; set; } = new List<Student>();

		public override string ToString() => group_name;
	}
}
