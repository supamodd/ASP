using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	public class Direction
	{
		[Key]
		[Column(TypeName = "TINYINT")]
		// direction_id в БД не IDENTITY - значение вводим вручную
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int direction_id { get; set; }
		public string? direction_name { get; set; }
	}
}
