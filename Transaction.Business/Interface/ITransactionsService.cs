using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Business.DTOs.ResponseDTO;

namespace TransactionService.Business.Interface
{
	public interface ITransactionsService
	{
		Task<IEnumerable<TransactionResponseDTO>> ExecuteBatchClosure<T>();
	}
}
