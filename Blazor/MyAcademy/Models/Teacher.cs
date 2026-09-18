using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	// Преподаватель
	public class Teacher : Human
	{
		[Key]
		[Column(TypeName = "smallint")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int teacher_id { get; set; }

		[DataType(DataType.Date)]
		public DateOnly? work_since { get; set; }

		[Column(TypeName = "smallmoney")]
		public decimal? rate { get; set; }

		// Navigation properties:
		public ICollection<TeacherDisciplineRelation> DisciplinesRelations { get; set; } = new List<TeacherDisciplineRelation>();

		public override string ToString() => $"{last_name} {first_name}";
	}
}
