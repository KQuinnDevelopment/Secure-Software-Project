using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Organizer.Models
{
    public class Exercise : UserEvent
    {
        // mandatory
        [Required, DataType(DataType.Text), MaxLength(100), Display(Name = "Exercise")]
        public override string Name { get; set; }

        [Required, Range(0, 20000), Display(Name = "Calories Burned")]
        public int Calories { get; set; }

        // optional
        [Range(1, 20000), Display(Name = "Sets")]
        public int Sets { get; set; }

        [Range(1, 20000), Display(Name = "Repetitions / 'Reps'")]
        public int Repetitions { get; set; }
    }
}