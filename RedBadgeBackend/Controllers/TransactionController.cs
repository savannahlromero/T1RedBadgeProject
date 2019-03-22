using EventApp.Models.TransactionModels;
using EventApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedBadgeBackend.Controllers
{
    public class TransactionController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TransactionService transactionService = CreateTransactionService();
            var transactions = transactionService.GetTransactions();
            return Ok(transactions);
        }

        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactionById(id);
            return Ok(transaction);
        }

        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.CreateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(userId);
            return transactionService;
        }
    }
}

