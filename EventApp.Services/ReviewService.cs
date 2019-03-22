using EventApp.Data;
using EventApp.Models;
using EventApp.Models.ReviewModels;
using RedBadgeBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Services
{
    public class ReviewService
    {
        private readonly Guid _userID;

        public ReviewService()
        {

        }

        public ReviewService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    VenueID = model.VenueID,
                    VenueRating = model.VenueRating,
                    Comments = model.Comments,
                    ApplicationUserID = _userID,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews(/*bool isTotesAdmin*/)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                //var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                //var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                //bool isAdmin = admins.Where(a => a.UserId == _userID.ToString()).Count() != 0;
                var query =
                    ctx
                        .Reviews
                        .Where(vote => vote.ApplicationUserID == _userID /*|| isAdmin*/)
                        .Select(
                        e =>
                            new ReviewListItem
                            {
                                ReviewID = e.ReviewID,
                                VenueID = e.VenueID,
                                VenueName = e.Venue.VenueName,
                                VenueRating = e.VenueRating,
                                Comments = e.Comments,
                            });
                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == reviewID);
                return
                    new ReviewDetail
                    {
                        ReviewID = entity.ReviewID,
                        VenueID = entity.VenueID,
                        VenueName = entity.Venue.VenueName,
                        VenueDescription = entity.Venue.VenueDescription,
                        VenueRating = entity.VenueRating,
                        Comments = entity.Comments
                    };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == model.ReviewID);

                entity.VenueID = model.VenueID;
                entity.VenueRating = model.VenueRating;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == reviewID);

                ctx.Reviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}