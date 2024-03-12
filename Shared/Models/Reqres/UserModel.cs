using System;
namespace Shared.Models.Reqres
{
	public class UserModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Job  { get; set; }
		public DateTime CreatedAt { get; set; }

		public UserModel()
		{
		}
	}
}

