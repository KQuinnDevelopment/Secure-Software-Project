using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Organizer.Models
{
    public class Food
    {
        // mandatory
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required, DataType(DataType.Text), MaxLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Range(0, 20000), Display(Name = "Calories")]
        public int Calories { get; set; }

        // optional
        [DataType(DataType.MultilineText), MaxLength(500), Display(Name = "Description")]
        public string Description { get; set; }

        [Range(0, 100), Display(Name = "Carbohydates")]
        public float MacroCarbohydrates { get; set; }

        [Range(0, 100), Display(Name = "Fats")]
        public float MacroFats { get; set; }

        [Range(0, 100), Display(Name = "Protein")]
        public float MacroProteins { get; set; }
    }
}