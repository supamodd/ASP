using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
	public class Human
	{
		public string last_name { get; set; } = string.Empty;

		public string first_name { get; set; } = string.Empty;

		public string? middle_name { get; set; }

		[DataType(DataType.Date)]
		public DateOnly? birth_date { get; set; }

		[EmailAddress]
		public string? email { get; set; }

		[Phone]
		public string? phone { get; set; }

		public byte[]? photo { get; set; }
	}
}
