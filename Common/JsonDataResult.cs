using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class JsonDataResult
	{
		public bool IsSuccess { get; set; } = true;
		public int Code { get; set; }
		public string Message { get; set; } = "";
		public string Token { get; set; }
		public object Data { get; set; }
	}
}
