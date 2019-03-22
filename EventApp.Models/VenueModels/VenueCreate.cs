using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models
{
    public class VenueCreate
    {
        [Required]
        [DisplayName("Venue Name")]
        [MinLength(2, ErrorMessage = "That name is too short!")]
        public string VenueName { get; set; }
        [Required]
        [DisplayName("Description")]
        [MinLength(2, ErrorMessage = "That description is too short!")]
        public string VenueDescription { get; set; }
        [Required]
        [DisplayName("Location")]
        [MinLength(2, ErrorMessage = "That Address is too short!")]
        public string VenueLocation { get; set; }
        [Required]
        [DisplayName("Capacity")]
        [Range(1, 200000)]
        public int VenueCapacity { get; set; }
        [Required]
        [DisplayName("Cost")]
        [Range(1, 1000000000)]
        public decimal VenueCost { get; set; }
        [DisplayName("Availability")]
        public bool VenueAvailability { get; set; }

        //public override string ToString() => VenueName + VenueDescription;
    }
}
