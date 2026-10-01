using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Group
	{
		[Key]
		public int group_id { get; set; }

		[Required]
		[Column(TypeName = "NCHAR(10)")]
		public string group_name { get; set; }

		[Required]
		[Column("direction", TypeName = "TINYINT")]
		[ForeignKey(nameof(Direction))]
		public int direction { get; set; }

		[Column("weekdays", TypeName = "TINYINT")]
		public int? learning_days { get; set; }

		[Column("start_time", TypeName = "TIME(0)")]
		public TimeOnly? start_time { get; set; }
		[Column("start_date", TypeName = "DATE")]
		public DateOnly? start_date { get; set; }

		//Navigation properties:
		public Direction Direction { get; set; }
	}
}
