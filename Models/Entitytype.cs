using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Entitytype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EntityType { get; set; }

        public virtual ICollection<Userentityaccess> Userentityaccesses { get; set; } = new List<Userentityaccess>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }

}