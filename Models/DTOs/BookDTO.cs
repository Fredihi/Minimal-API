using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Minimal_API.Models.DTOs
{
	public class BookDTO
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
