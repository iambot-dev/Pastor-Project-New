using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Counsellingtype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CounsellingType1 { get; set; }

        public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();

        public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
    }

}