using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty]
        public FoodInfo FoodInfo { get; set; }
        [BindProperty]
        public string FoodName { get; set; }
        public const string SessionKeyName = "_Name";
        
        const string SessionKeyTime = "_Time";
        
        public DailyIntake DailyIntake { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }
        public void OnGet()
        {
            if (HttpContext.Session.Keys.Contains(SessionKeyName))
            {
                DailyIntake = JsonConvert.DeserializeObject<DailyIntake>(HttpContext.Session.GetString(SessionKeyName));
            }

            if (!string.IsNullOrEmpty(SearchString))
           {

               string res;
               using (WebClient client = new WebClient())
               {
                   res = client.DownloadString($"https://api.edamam.com/api/food-database/parser?ingr={SearchString.Trim().Replace(" ", "%20")}&app_id=7c8f1f85&app_key=27cad3304ee09e389a780542d5f2a308");
               }
                TempData["food"] = res;
                FoodInfo = JsonConvert.DeserializeObject<FoodInfo>(res);
             
           }
           
        }
        public void OnPost(int amount)
    {
            FoodInfo = JsonConvert.DeserializeObject<FoodInfo>(TempData.Peek("food") as string);

            if (HttpContext.Session.Keys.Contains(SessionKeyName))
            {
                DailyIntake = JsonConvert.DeserializeObject<DailyIntake>(HttpContext.Session.GetString(SessionKeyName));
            }
            else
            {
                DailyIntake = new DailyIntake {
                    FoodItems = new List<Food2>()
                };
            }
            Food2 newFood = FoodInfo.hints.Find(f => f.food.label == FoodName).food;
            newFood.amount = amount;
            DailyIntake.FoodItems.Add(newFood);
            HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(DailyIntake));      
    }
    }
}
