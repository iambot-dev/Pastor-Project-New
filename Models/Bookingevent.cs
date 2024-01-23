using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Bookingevent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CounseleeId { get; set; }

        public bool? SurveyAttempted { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? PastorId { get; set; }

        public int? BookingStatusId { get; set; }

        public int? SubscriptionId { get; set; }

        public bool? IsPaymentSuccessful { get; set; }

        public bool? IsBooked { get; set; }

        public int? SlotId { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

        public virtual Bookingstatus BookingStatus { get; set; }

        public virtual Counselee Counselee { get; set; }

        public virtual Pastor Pastor { get; set; }

        public virtual ICollection<Paymentdetail> Paymentdetails { get; set; } = new List<Paymentdetail>();

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        public virtual Slot Slot { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
