using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static Common.StaticDetails;

namespace Common
{
	public class ApiRequest
	{
		public ApiType apiType { get; set; } = ApiType.GET;
		public string url { get; set; }
		public object Data { get; set; }
		public string AccessToken { get; set; }
		public string ApiKey { get; set; }
		public Boolean IsReport { get; set; } = false;
	}
}
