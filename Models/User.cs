using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Password { get; set; }

        public int? EntityType { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }

        public int? LoginAttempt { get; set; }

        public bool? TermsAndConditionsAccepted { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

        public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();

        public virtual Entitytype EntityTypeNavigation { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Userentityaccess> Userentityaccesses { get; set; } = new List<Userentityaccess>();

        public virtual ICollection<Userimage> Userimages { get; set; } = new List<Userimage>();
    }
}
