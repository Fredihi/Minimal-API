namespace Minimal_API.Models.DTOs
{
	public class BookUpdateDTO
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
	}
}
