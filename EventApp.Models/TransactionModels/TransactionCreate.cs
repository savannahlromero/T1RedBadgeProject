using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models.TransactionModels
{
    public class TransactionCreate
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public int DaysRenting { get; set; }
        public decimal TransactionCost { get; set; }

    }
}
