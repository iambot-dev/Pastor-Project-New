using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PlanType { get; set; }

        public DateTime? Plandate { get; set; }

        public string PlanName { get; set; }

        public string PlanCode { get; set; }

        public decimal? PlanPrice { get; set; }

        public bool? IsActive { get; set; }

        public int? PlanPeriod { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }

}