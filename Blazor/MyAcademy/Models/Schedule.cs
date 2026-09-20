using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	public class Schedule
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long lesson_id { get; set; }

		[ForeignKey(nameof(Group))]
		public int group { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Teacher))]
		public int teacher { get; set; }

		public DateOnly? date { get; set; }

		public TimeOnly? time { get; set; }

		public bool spent { get; set; }

		public Group? Group { get; set; }

		public Discipline? Discipline { get; set; }

		public Teacher? Teacher { get; set; }

		public override string ToString() => $"{lesson_id}";
	}
}
