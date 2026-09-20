using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(student), nameof(lesson))]
	public class Attendance
	{
		[ForeignKey(nameof(Student))]
		public int student { get; set; }

		[ForeignKey(nameof(Lesson))]
		public long lesson { get; set; }

		public bool present { get; set; }

		public Student? Student { get; set; }

		public Schedule? Lesson { get; set; }

		public override string ToString() => $"{student} / {lesson}";
	}
}
