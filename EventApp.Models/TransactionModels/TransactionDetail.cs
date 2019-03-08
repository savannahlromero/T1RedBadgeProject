using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.TransactionModels
{
    public class TransactionDetail
    {
        [Key]
        [DisplayName("Transaction #")]
        public int TransactionID { get; set; }

        [Required]
        [DisplayName("User #")]
        public int UserID { get; set; }

        [Required]
        [DisplayName("Venue #")]
        public int VenueID { get; set; }

        [Required]
        [DisplayName("Cost")]
        public decimal VenueCost { get; set; }

        //[Required]
        //[DisplayName("Date")]

    }
}
