using RedBadgeBackend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class Review
    {

        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int VenueID { get; set;}
        public virtual Venue Venue { get; set; }


        [Required]
        public Guid ApplicationUserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DisplayName("Score 1-5")]
        [Range(1,5)]
        public int VenueRating { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }
    }
}
