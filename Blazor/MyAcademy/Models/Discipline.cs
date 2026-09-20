using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Discipline
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int discipline_id { get; set; }

		public string discipline_name { get; set; } = string.Empty;

		[Required]
		[Range(0, 255)]
		[Column(TypeName = "TINYINT")]
		public int number_of_lessons { get; set; }

		public ICollection<TeacherDisciplineRelation> TeachersRelations { get; set; } = new List<TeacherDisciplineRelation>();

		public override string ToString() => discipline_name;
	}
}
