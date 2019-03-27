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
        private readonly Guid _userID;

        public TransactionService()
        {

        }

        public TransactionService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                   
                    VenueID = model.VenueID,
                    DaysRenting = model.DaysRenting,
                    TransactionCost = model.TransactionCost,
                    ApplicationUserID = _userID
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
                //var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                //var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                //var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                //bool isAdmin = admins.Where(a => a.UserId == _userID.ToString()).Count() != 0;
                var query =
                   ctx
                     .Transactions
                     .Where(e => e.ApplicationUserID == _userID /*|| isAdmin*/)
                     .Select(
                         e =>
                             new TransactionListItem
                             {
                                 TransactionID = e.TransactionID,
                                 VenueID = e.VenueID,
                                 VenueName = e.Venue.VenueName,
                                 DaysRenting = e.DaysRenting,
                                 TransactionCost = e.TransactionCost
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
                        VenueID = entity.VenueID,
                        VenueName = entity.Venue.VenueName,
                        DaysRenting = entity.DaysRenting,
                        TransactionCost = entity.TransactionCost
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == model.TransactionID);

                entity.VenueID = model.VenueID;
                entity.DaysRenting = model.DaysRenting;
                entity.TransactionCost = model.TransactionCost;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}