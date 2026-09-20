using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(group), nameof(discipline))]
	public class CompleteDiscipline
	{
		[ForeignKey(nameof(Group))]
		public int group { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		public Group? Group { get; set; }

		public Discipline? Discipline { get; set; }

		public override string ToString() => $"{group} / {discipline}";
	}
}
