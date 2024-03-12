namespace Shared.Models.FakerApi
{
    public class ResponseFakerApi<T>
	{
		public string Status { get; set; }
		public int Code { get; set; }
		public int Total { get; set; }
		public List<T> Data { get; set; }

		public ResponseFakerApi()
		{
		}
	}
}

