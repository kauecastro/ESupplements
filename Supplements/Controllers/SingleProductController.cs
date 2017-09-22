using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supplements.Models;
using Supplements.Facade;
namespace Supplements.Controllers
{
    public class SingleProductController : Controller
    {
        //
        // GET: /SingleProduct/

        public ActionResult Index(string sku)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Read(new Product() { SKU = sku} );
            return View(modelReponse.Domain);
        }

        public ActionResult Buy(string sku)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Read(new Product() { SKU = sku });
            var product = (Product)modelReponse.Domain.FirstOrDefault() ?? new Product();
            var OrderCart = ((Order)Session["OrderCart"]) ?? new Order() { product = new List<Product>()};
            OrderCart.product.Add(product);
            OrderCart.totalPrice += Convert.ToDouble(product.Price);
            Session["OrderCart"] = OrderCart;
            return RedirectToAction("Index","Checkout");
        }
	}
}