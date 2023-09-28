using System.ComponentModel.DataAnnotations;

namespace Minimal_API.Models.DTOs
{
	public class BookUpdateDTO
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
        public string Description { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime ReleaseYear { get; set; }
	}
}
