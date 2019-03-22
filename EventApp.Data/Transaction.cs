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
    public class Transaction
    {
        [Key]
        [DisplayName("Transaction #")]
        public int TransactionID { get; set; }

        [Required]
        public Guid ApplicationUserID { get; set; }
        public virtual ApplicationUser user { get; set; }

        [Required]
        [DisplayName("Venue #")]
        public int VenueID { get; set; }
        public virtual Venue Venue { get; set; }

        [Required]
        [DisplayName("Days Renting")]
        public int DaysRenting { get; set; }

        [DisplayName("Cost")]
        public decimal TransactionCost { get; set; }
    }
}
