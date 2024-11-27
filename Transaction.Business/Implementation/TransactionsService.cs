using Common;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transaction.Business.DTOs.ResponseDTO;
using TransactionService.Business.Interface;
using TransactionService.Data;

namespace TransactionService.Business.Implementation
{
	public class TransactionsService : ITransactionsService
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly TransactionDbContext _db;

		public TransactionsService(TransactionDbContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<TransactionResponseDTO>> ExecuteBatchClosure<T>()
		{
			_logger.Info("Method: {0}", MethodBase.GetCurrentMethod());

			var loteClosure1 = await _db.TransaccionesTcs.ToListAsync();

			var loteClosure = _db.TransaccionesTcs.ToList();

			return loteClosure.MapTo<List<TransactionResponseDTO>>();

		}
	}
}
