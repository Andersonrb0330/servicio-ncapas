namespace Shared.Models.FakerApi
{
    public class BookModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Image { get; set; }
        public string Published { get; set; }
        public string Publisher { get; set; }

        public BookModel()
		{			
		}
	}
}

