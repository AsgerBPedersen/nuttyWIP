using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Nutrients
    {
        public double ENERC_KCAL { get; set; }
        public double PROCNT { get; set; }
        public double FAT { get; set; }
        public double CHOCDF { get; set; }
    }

    public class Food
    {
        public int Amount { get; set; }
        public string foodId { get; set; }
        public string label { get; set; }
        public Nutrients nutrients { get; set; }
        public string category { get; set; }
        public string categoryLabel { get; set; }
    }

    public class Parsed
    {
        public Food food { get; set; }
    }

    public class Nutrients2
    {
        public double ENERC_KCAL { get; set; }
        public double PROCNT { get; set; }
        public double FAT { get; set; }
        public double CHOCDF { get; set; }
        public double? FIBTG { get; set; }
    }

    public class Food2
    {
        public int amount { get; set; }
        public string foodId { get; set; }
        public string label { get; set; }
        public Nutrients2 nutrients { get; set; }
        public string category { get; set; }
        public string categoryLabel { get; set; }
        public string foodContentsLabel { get; set; }
        public string brand { get; set; }
        public string image { get; set; }
    }

    public class Measure
    {
        public string uri { get; set; }
        public string label { get; set; }
        public List<List<Measure2>> qualified { get; set; }
    }

    public class Measure2
    {
        public string uri { get; set; }
        public string label { get; set; }
        
    }

    public class Hint
    {
        public Food2 food { get; set; }
        public List<Measure> measures { get; set; }
    }

    public class Next
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class Links
    {
        public Next next { get; set; }
    }

    public class FoodInfo
    {
        public string text { get; set; }
        public List<Parsed> parsed { get; set; }
        public List<Hint> hints { get; set; }
        public Links _links { get; set; }
    }
}
