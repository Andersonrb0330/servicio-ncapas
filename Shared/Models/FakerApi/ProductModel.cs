namespace Shared.Models.FakerApi
{
    public class ProductModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ean { get; set; }
        public string Upc { get; set; }
        public string Image { get; set; }
        public List<ProductImageModel> Images { get; set; }
        public decimal NetPrice { get; set; }
        public int Taxes { get; set; }
        public decimal Price { get; set; }
        public List<int> Categories { get; set; }
        public List<string> Tags { get; set; }


        public ProductModel()
		{
		}
	}
}

