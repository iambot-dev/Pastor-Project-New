using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Question { get; set; }

        public string Options { get; set; }

        public bool? IsActive { get; set; }

        public int? CounselingType { get; set; }

        public int? DisplayOrder { get; set; }

        public virtual Counsellingtype CounselingTypeNavigation { get; set; }

        public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();
    }
}
