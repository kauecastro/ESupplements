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
	}
}