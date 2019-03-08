using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.ReviewModels
{
    public class ReviewListItem
    {
        public int ReviewID { get; set; }
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public int VenueRating { get; set; }
        public string Comments { get; set; }
        public string UserName { get; set; }

        public override string ToString() => $"[{VenueID}] {VenueName}";
    }
}
