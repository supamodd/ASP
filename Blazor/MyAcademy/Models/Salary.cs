using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	public class Salary
	{
		[Key]
		// в БД колонка не IDENTITY - значение вводится вручную
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long payment_id { get; set; }

		[Column(TypeName = "SMALLINT")]
		[ForeignKey(nameof(Teacher))]
		public int teacher { get; set; }

		[Column(TypeName = "smallmoney")]
		public decimal accrued { get; set; }

		public bool received { get; set; }

		public Teacher? Teacher { get; set; }

		public override string ToString() => $"{payment_id}";
	}
}
