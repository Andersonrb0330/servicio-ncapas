namespace Shared.Models.FakerApi
{
    public class PersonModel
	{
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }

        public PersonModel()
		{
		}
	}
}

