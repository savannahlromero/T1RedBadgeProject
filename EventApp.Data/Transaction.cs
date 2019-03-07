using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
    }
}
