using EventApp.Data;
using EventApp.Models;
using RedBadgeBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Services
{
    public class VenueService
    {
        public bool CreateVenue(VenueCreate model)
        {
            var entity =
                new Venue()
                {
                    VenueName = model.VenueName,
                    VenueDescription = model.VenueDescription,
                    VenueLocation = model.VenueLocation,
                    VenueCapacity = model.VenueCapacity,
                    VenueCost = model.VenueCost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                     .Venues
                     .Select(
                         e =>
                             new VenueListItem
                             {
                                 VenueName = e.VenueName,
                                 VenueDescription = e.VenueDescription,
                                 VenueLocation = e.VenueLocation,
                                 VenueCapacity = e.VenueCapacity,
                                 VenueCost = e.VenueCost
                             }
                     );
                return query.ToArray();
            }
        }

        //public MealDetail GetMealById(int mealId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Meals
        //                .Single(e => e.MealId == mealId);
        //        return
        //            new MealDetail
        //            {
        //                MealId = entity.MealId,
        //                MealName = entity.MealName,
        //                MealDescription = entity.MealDescription,
        //                CreatedUtc = entity.CreatedUtc
        //            };
        //    }

        //}

        //public bool UpdateMeal(MealEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Meals
        //                .Single(e => e.MealId == model.MealId);

        //        entity.MealName = model.MealName;
        //        entity.MealDescription = model.MealDescription;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        //public bool DeleteMeal(int noteId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Meals
        //                .Single(e => e.MealId == noteId);

        //        ctx.Meals.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
