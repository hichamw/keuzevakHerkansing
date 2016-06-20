using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class Supermarkets
    {
        public List<Supermarket> SupermarketList { get; set; }
        public List<Supermarket> SearchedSupermarkets { get; set; }
        public bool JustStarted { get; set; }

    }
}