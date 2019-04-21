using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DailyIntake
    {
        public DateTime Date { get; set; }
        public List<Food2> FoodItems { get; set; }
    }

}
