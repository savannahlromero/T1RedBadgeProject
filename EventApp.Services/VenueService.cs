using EventApp.Data;
using EventApp.Models;
using EventApp.Models.VenueModels;
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
        private readonly Guid _userID;

        public VenueService()
        {

        }

        public VenueService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateVenue(VenueCreate model)
        {
            var entity =
                new Venue()
                {
                    VenueName = model.VenueName,
                    VenueDescription = model.VenueDescription,
                    VenueLocation = model.VenueLocation,
                    VenueCapacity = model.VenueCapacity,
                    VenueCost = model.VenueCost,
                    VenueAvailability = true
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

                                 VenueID = e.VenueID,
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

        public VenueDetail GetVenueById(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueID == venueId);
                return
                    new VenueDetail
                    {
                        VenueID = entity.VenueID,
                        VenueName = entity.VenueName,
                        VenueDescription = entity.VenueDescription,
                        VenueLocation = entity.VenueLocation,
                        VenueCapacity = entity.VenueCapacity,
                        VenueCost = entity.VenueCost
                    };
            }

        }

        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                //var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                //var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                //var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                //bool isAdmin = admins.Where(a => a.UserId == _userID.ToString()).Count() != 0;
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueID == model.VenueID);

                entity.VenueName = model.VenueName;
                entity.VenueDescription = model.VenueDescription;
                entity.VenueAvailability = model.VenueAvailability;
                entity.VenueCapacity = model.VenueCapacity;
                entity.VenueCost = model.VenueCost;
                entity.VenueLocation = model.VenueLocation;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                //var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                //var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                //bool isAdmin = admins.Where(a => a.UserId == _userID.ToString()).Count() != 0;
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueID == venueId);

                ctx.Venues.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}