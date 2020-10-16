using System.Collections.Generic;

namespace Life_Organizer.Models
{
    public class UserHistoryViewModel
    {
        public IEnumerable<UserEvent> Events { get; set; }

        public IEnumerable<Food> Foods { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}