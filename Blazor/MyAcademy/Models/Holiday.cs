using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models
{
	public class Holiday
	{
		[Key]
		[Column(TypeName = "TINYINT")]
		// в БД колонка не IDENTITY - значение вводится вручную
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int holiday_id { get; set; }

		public string holiday_name { get; set; } = string.Empty;

		[Column(TypeName = "TINYINT")]
		public int duration { get; set; }

		[Column(TypeName = "TINYINT")]
		public int? month { get; set; }

		[Column(TypeName = "TINYINT")]
		public int? day { get; set; }

		public override string ToString() => holiday_name;
	}
}
