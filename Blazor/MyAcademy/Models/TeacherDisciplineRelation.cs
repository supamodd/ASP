using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(teacher), nameof(discipline))]
	public class TeacherDisciplineRelation
	{
		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Teacher))]
		public int teacher { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		public Teacher? Teacher { get; set; }

		public Discipline? Discipline { get; set; }
	}
}
