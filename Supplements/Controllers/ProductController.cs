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
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Read(new Product());
            return View(modelReponse.Domain);
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Create(product);
            return RedirectToAction("Index");
        }

        public ActionResult Vizualize(int id)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Read(new Product() {id = id});
            return View(modelReponse.Domain);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Update(product);
            return RedirectToAction("Index");
        }
    }
}