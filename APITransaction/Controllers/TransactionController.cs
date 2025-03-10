﻿using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System.Reflection;
using TransactionService.Business.Interface;

namespace APITransaction.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly ITransactionsService _transactionService;
		protected ResponseDto _responseDto;
		protected JsonDataResult _jsonDataResult;

		public TransactionController(ITransactionsService transactionService)
		{
			_transactionService = transactionService;
			this._jsonDataResult = new JsonDataResult();
		}

		[HttpGet("ExecuteBatchClosure")]
		public async Task<IActionResult> ExecuteBatchClosure()
		{
			try
			{
				_logger.Info("Method: {0}", MethodBase.GetCurrentMethod());

				var batchDto = await _transactionService.ExecuteBatchClosure<ResponseDto>();

				if (batchDto.Count() == 0)
				{
					_jsonDataResult.Data = "Sin registros";
					_jsonDataResult.IsSuccess = true;
					_jsonDataResult.Code = 200;
					_jsonDataResult.Message = "successfully";
					return Ok(_jsonDataResult);
				}

				_jsonDataResult.Data = batchDto;
				_jsonDataResult.IsSuccess = true;
				_jsonDataResult.Code = 200;
				_jsonDataResult.Message = "successfully";
				return Ok(_jsonDataResult); ;
			}
			catch (Exception ex)
			{
				_logger.Error("Error: {0} - Detalle: {1} - Metodo: {2}", ex.Message.ToString(), ex.ToString(), ex.TargetSite);
				_jsonDataResult.IsSuccess = false;
				_jsonDataResult.Code = 400;
				_jsonDataResult.Message = ex.ToString();
				return BadRequest(_jsonDataResult);
			}

		}
	}
}
