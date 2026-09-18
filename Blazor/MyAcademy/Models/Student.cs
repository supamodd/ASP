using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	// Студент
	public class Student : Human
	{
		// stud_id - IDENTITY: значение присваивает сама БД
		[Key]
		public int stud_id { get; set; }

		[ForeignKey(nameof(Group))]
		public int? group { get; set; }

		// Navigation properties:
		public Group? Group { get; set; }

		public override string ToString() => $"{last_name} {first_name}";
	}
}
