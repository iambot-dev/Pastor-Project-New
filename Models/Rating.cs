using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PastorId { get; set; }

        public int? Rating1 { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Pastor Pastor { get; set; }
    }
}
