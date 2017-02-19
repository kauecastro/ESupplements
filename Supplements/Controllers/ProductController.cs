using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supplements.Models;
using Supplements.Facade;
namespace Supplements.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            Facade.Facade facade = new Facade.Facade();
            facade.Create(product);
            return RedirectToAction("Index");
        }
	}
}