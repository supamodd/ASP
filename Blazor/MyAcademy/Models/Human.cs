using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
	// Общие поля для Student и Teacher (наследники складываются в свои таблицы).
	public class Human
	{
		// В БД SPU_411_Import эти поля могут быть NULL (см. Teachers) - Required не ставим
		public string last_name { get; set; } = string.Empty;

		public string first_name { get; set; } = string.Empty;

		public string? middle_name { get; set; }

		[DataType(DataType.Date)]
		public DateOnly? birth_date { get; set; }

		[EmailAddress]
		public string? email { get; set; }

		[Phone]
		public string? phone { get; set; }

		// Фото: в БД Students/Teachers столбец photo имеет тип image (читается в byte[]?)
		public byte[]? photo { get; set; }
	}
}
