using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore2.Models;

namespace MvcMusicStore2.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}