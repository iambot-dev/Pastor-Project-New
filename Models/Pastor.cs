using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Pastor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PastorDescription { get; set; }

        public int? Duration { get; set; }
        [JsonIgnore]
        public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();
        [JsonIgnore]
        public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();
        [JsonIgnore]
        public virtual ICollection<Favouritepastor> Favouritepastors { get; set; } = new List<Favouritepastor>();
        [JsonIgnore]
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        [JsonIgnore]
        public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
    }
}