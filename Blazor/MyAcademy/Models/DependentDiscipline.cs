using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(discipline), nameof(dependent_discipline))]
	public class DependentDiscipline
	{
		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Dependent))]
		public int dependent_discipline { get; set; }

		public Discipline? Discipline { get; set; }

		public Discipline? Dependent { get; set; }

		public override string ToString() => $"{discipline} / {dependent_discipline}";
	}
}
