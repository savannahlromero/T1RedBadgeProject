using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class Venue
    {
        [Key]
        [DisplayName("Venue #")]
        public int VenueID { get; set; }

        [Required]
        [DisplayName("Venue Name")]
        public string VenueName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string VenueDescription { get; set; }

        [Required]
        [DisplayName("Location")]
        public string VenueLocation { get; set; }

        [Required]
        [DisplayName ("Capacity")]
        public int VenueCapacity { get; set; }

        [DisplayName("Availability")]
        public bool VenueAvailability { get; set; }

        [DisplayName("Cost")]
        public decimal VenueCost { get; set; }
    }
}
