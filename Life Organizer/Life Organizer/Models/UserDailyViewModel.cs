using System.Collections.Generic;

namespace Life_Organizer.Models
{
    public class UserDailyViewModel
    {
        public IEnumerable<Food> Foods { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}