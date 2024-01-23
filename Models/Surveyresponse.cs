using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Surveyresponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CounseleeId { get; set; }

        public int? QuestionId { get; set; }

        public string Response { get; set; }

        public int? CounselingType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Counselee Counselee { get; set; }

        public virtual Counsellingtype CounselingTypeNavigation { get; set; }

        public virtual Survey Question { get; set; }
    }
}
