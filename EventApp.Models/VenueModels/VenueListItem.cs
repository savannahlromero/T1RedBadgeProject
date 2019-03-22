using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models
{
    public class VenueListItem
    {
        [DisplayName("Venue ID")]
        public int VenueID { get; set; }
        [DisplayName("Venue Name")]
        [MinLength(2, ErrorMessage = "That name is too short!")]
        public string VenueName { get; set; }

        [DisplayName("Description")]
        [MinLength(2, ErrorMessage = "That description is too short!")]
        public string VenueDescription { get; set; }

        [DisplayName("Location")]
        [MinLength(2, ErrorMessage = "That Address is too short!")]
        public string VenueLocation { get; set; }
  
        [DisplayName("Capacity")]
        [Range(1, 200000)]
        public int VenueCapacity { get; set; }
  
        [DisplayName("Cost")]
        [Range(1, 1000000000)]
        public decimal VenueCost { get; set; }
    }
}
