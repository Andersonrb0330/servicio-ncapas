﻿namespace Shared.Models.Reqres
{
    public class ResponseReqres<T>
	{
		public int Page { get; set; }
		public int PerPage { get; set; }
		public int Total { get; set; }
		public int TotalPages { get; set; }
		public List<T> Data { get; set; }


		public ResponseReqres()
		{
		}
	}
}

