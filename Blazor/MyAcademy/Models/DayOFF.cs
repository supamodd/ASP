using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	[PrimaryKey(nameof(date), nameof(holiday))]
	public class DayOFF
	{
		public DateOnly date { get; set; }

		[Column(TypeName = "TINYINT")]
		[ForeignKey(nameof(Holiday))]
		public int holiday { get; set; }

		public Holiday? Holiday { get; set; }

		public override string ToString() => $"{date} / {holiday}";
	}
}
