using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Paymentdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? EventId { get; set; }

        public int? CounseleeId { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? TransactionDate { get; set; }

        public string PaymentMethod { get; set; }

        public virtual Counselee Counselee { get; set; }

        public virtual Bookingevent Event { get; set; }
    }

}