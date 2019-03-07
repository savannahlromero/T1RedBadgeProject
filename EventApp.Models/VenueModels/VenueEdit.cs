using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.VenueModels
{
    public class VenueEdit
    {
        [DisplayName("Venue #")]
        public int VenueID { get; set; }

        [DisplayName("Venue Name")]
        public string VenueName { get; set; }

        [DisplayName("Description")]
        public string VenueDescription { get; set; }

        [DisplayName("Location")]
        public string VenueLocation { get; set; }

        [DisplayName("Capacity")]
        public int VenueCapacity { get; set; }

        [DisplayName("Availability")]
        public bool VenueAvailability { get; set; }

        [DisplayName("Cost")]
        public decimal VenueCost { get; set; }
    }
}
