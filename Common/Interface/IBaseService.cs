using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
	public interface IBaseService
	{
		public interface IBaseService : IDisposable
		{
			ResponseDto responseModel { get; set; }

			Task<T> SendAsync<T>(ApiRequest apiResquest);
		}
	}
}
