using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	// Студент
	public class Student : Human
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int stud_id { get; set; }

		[Required]
		[ForeignKey(nameof(Group))]
		public int group { get; set; }

		// Navigation properties:
		public Group? Group { get; set; }

		public override string ToString() => $"{last_name} {first_name}";
	}
}
