using EventApp.Data;
using EventApp.Models.TransactionModels;
using RedBadgeBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    TransactionID = model.TransactionID,
                    UserID = model.UserID,
                    VenueID = model.VenueID,
                    VenueCost = model.VenueCost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                     .Transactions
                     .Select(
                         e =>
                             new TransactionListItem
                             {
                                 TransactionID = e.TransactionID,
                                 UserID = e.UserID,
                                 VenueID = e.VenueID,
                                 VenueCost = e.VenueCost
                             }
                     );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == transactionId);
                return
                    new TransactionDetail
                    {
                        TransactionID = entity.TransactionID,
                        UserID = entity.UserID,
                        VenueID = entity.VenueID,
                        VenueCost = entity.VenueCost
                    };
            }
        }
    }
}
