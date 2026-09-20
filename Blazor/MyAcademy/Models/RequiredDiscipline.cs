using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(discipline), nameof(required_discipline))]
	public class RequiredDiscipline
	{
		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Required))]
		public int required_discipline { get; set; }

		public Discipline? Discipline { get; set; }

		public Discipline? Required { get; set; }

		public override string ToString() => $"{discipline} / {required_discipline}";
	}
}
