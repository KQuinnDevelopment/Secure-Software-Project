using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Organizer.Models
{
    public class UserEvent
    {
        // mandatory
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required, DataType(DataType.Text), MaxLength(100), Display(Name = "Title")]
        public virtual string Name { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Date")]
        public virtual DateTime Date { get; set; }

        // optional
        [DataType(DataType.MultilineText), MaxLength(1000), Display(Name = "Description")]
        public virtual string Description { get; set; }

        [DataType(DataType.Duration), Display(Name = "Duration")]
        public virtual float Duration { get; set; }
    }
}