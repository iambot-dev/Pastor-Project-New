using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PASTORALISPROJECTNEW.Models
{

    public partial class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PastorId { get; set; }

        public DateOnly? SlotDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? IsAvailable { get; set; }

        public bool? IsClosed { get; set; }

        public string AvailabilityTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();
        [JsonIgnore]
        public virtual Pastor Pastor { get; set; }

        
    }

}