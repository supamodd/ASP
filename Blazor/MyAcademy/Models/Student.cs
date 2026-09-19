using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	public class Student : Human
	{
		[Key]
		public int stud_id { get; set; }

		[ForeignKey(nameof(Group))]
		public int? group { get; set; }

		public Group? Group { get; set; }

		public override string ToString() => $"{last_name} {first_name}";
	}
}
