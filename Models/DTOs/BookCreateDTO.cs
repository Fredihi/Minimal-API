namespace Minimal_API.Models.DTOs
{
	public class BookCreateDTO
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
