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
                var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                bool isAdmin = admins.Where(a => a.UserId == _userId.ToString()).Count() != 0;
                var query =
                   ctx
                     .Transactions
                     .Where(vote => vote.ApplicationUserId == _userID || isAdmin)
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