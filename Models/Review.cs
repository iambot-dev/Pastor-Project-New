using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ReviewedBy { get; set; }

        public string ReviewComment { get; set; }

        public int? PastorId { get; set; }

        public int? Rating { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Pastor Pastor { get; set; }

        public virtual User ReviewedByNavigation { get; set; }
    }
}
