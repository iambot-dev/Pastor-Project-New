using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Counselee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? SurveyAttempted { get; set; }

        public string SubscriptionType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();

        public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();

        public virtual ICollection<Favouritepastor> Favouritepastors { get; set; } = new List<Favouritepastor>();

        public virtual ICollection<Paymentdetail> Paymentdetails { get; set; } = new List<Paymentdetail>();

        public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();
    }

}