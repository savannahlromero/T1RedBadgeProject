using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.ReviewModels
{
    public class ReviewEdit
    {
        public int ReviewID { get; set; }
        public int VenueID { get; set;}
        public int VenueName { get; set; }
        public int VenueRating { get; set; }
        public string Comments { get; set; }
    }
}
