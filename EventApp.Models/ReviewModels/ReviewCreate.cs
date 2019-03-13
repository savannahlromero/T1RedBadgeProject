using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.ReviewModels
{
    public class ReviewCreate
    {
        public int ReviewID { get; set; }

        [Required]
        public int VenueID { get; set; }

        [Required]
        [Range(1, 5)]
        public int VenueRating { get; set; }

        public string Comments { get; set; } 
    }
}
