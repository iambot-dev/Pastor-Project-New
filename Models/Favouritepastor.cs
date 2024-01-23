using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Favouritepastor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CounseleeId { get; set; }

        public int? PastorId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Counselee Counselee { get; set; }

        public virtual Pastor Pastor { get; set; }
    }
}
