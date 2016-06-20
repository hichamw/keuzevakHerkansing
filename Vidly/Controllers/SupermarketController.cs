using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class SupermarketController : Controller
    {
        // GET: Supermarket
        
        public ActionResult Index(string SearchString)
        {
            bool justStarted = true;
            Supermarkets s = new Supermarkets();
            List<Supermarket> supermarkets;
            List<Supermarket> searchedSupermarkets = new List<Supermarket>();
            using (StreamReader r = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", "values.json")))
            {
                string json = r.ReadToEnd();
                supermarkets = JsonConvert.DeserializeObject<List<Supermarket>>(json);
                            
            }
            if (SearchString != null)
            {
                justStarted = false;
                foreach (Supermarket i in supermarkets)
                {
                    if (i.Address.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        searchedSupermarkets.Add(i);

                    }
                }

            }
            s.SupermarketList = supermarkets;
            s.SearchedSupermarkets = searchedSupermarkets;
            s.JustStarted = justStarted;

            return View(s);
        }
    }
}