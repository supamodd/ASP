using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
	// Общие поля для Student и Teacher (наследники складываются в свои таблицы).
	public class Human
	{
		[Required]
		public string last_name { get; set; } = string.Empty;

		[Required]
		public string first_name { get; set; } = string.Empty;

		public string? middle_name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateOnly birth_date { get; set; }

		[EmailAddress]
		public string? email { get; set; }

		[Phone]
		public string? phone { get; set; }

		// Фото хранится в БД в столбце photo (varbinary(max))
		public byte[]? photo { get; set; }
	}
}
