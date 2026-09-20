using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(student), nameof(lesson))]
	public class Grade
	{
		[ForeignKey(nameof(Student))]
		public int student { get; set; }

		[ForeignKey(nameof(Lesson))]
		public long lesson { get; set; }

		[Column(TypeName = "TINYINT")]
		public int? grade_1 { get; set; }

		[Column(TypeName = "TINYINT")]
		public int? grade_2 { get; set; }

		public Student? Student { get; set; }

		public Schedule? Lesson { get; set; }

		public override string ToString() => $"{student} / {lesson}";
	}
}
