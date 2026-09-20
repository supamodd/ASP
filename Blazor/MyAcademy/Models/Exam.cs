using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(student), nameof(discipline))]
	public class Exam
	{
		[ForeignKey(nameof(Student))]
		public int student { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		public DateOnly? date { get; set; }

		[Column(TypeName = "TINYINT")]
		public int? grade { get; set; }

		public Student? Student { get; set; }

		public Discipline? Discipline { get; set; }

		public override string ToString() => $"{student} / {discipline}";
	}
}
