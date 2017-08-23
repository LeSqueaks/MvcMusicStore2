using System.Linq;
using System.Web.Mvc;
using MvcMusicStore2.Models;
using MvcMusicStore2.ViewModels;

namespace MvcMusicStore2.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            //The "helper" method in ShoppingCart.cs model
            //Why can't we do this in the general public class ShoppingCartController class?  Instead of having it in multiple methods?
            //??

            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                //Sets the "get" data in viewmodel
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view with both variables
            return View(viewModel);
        }

        
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {

            // Retrieve the album from the database
            var addedAlbum = storeDB.Albums
                .Single(album => album.AlbumId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        
        // AJAX: /ShoppingCart/RemoveFromCart/5
        //??

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Get the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = storeDB.Carts
                .Single(item => item.RecordId == id).Album.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            //??
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}