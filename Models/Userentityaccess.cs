using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PASTORALISPROJECTNEW.Models
{
    public partial class Userentityaccess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? EntityId { get; set; }

        public int? EntityType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Entitytype EntityTypeNavigation { get; set; }

        public virtual User User { get; set; }
    }
}
