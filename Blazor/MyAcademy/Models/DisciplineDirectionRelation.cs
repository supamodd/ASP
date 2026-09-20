using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(direction), nameof(discipline))]
	public class DisciplineDirectionRelation
	{
		[Column(TypeName = "TINYINT")]
		[ForeignKey(nameof(Direction))]
		public int direction { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		public Direction? Direction { get; set; }

		public Discipline? Discipline { get; set; }

		public override string ToString() => $"{direction} / {discipline}";
	}
}
