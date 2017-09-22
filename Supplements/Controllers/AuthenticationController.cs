using Supplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supplements.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserAnthentication(UserAccount userAccount)
        {
            Facade.Facade facade = new Facade.Facade();
            ModelResponse modelReponse = facade.Read(userAccount);
            var Person = (Person)modelReponse.Domain.FirstOrDefault();
            if (Person == null )
                return RedirectToAction("Index", "Authentication");
            Session["userAuthenticationName"] = Person.Nome;
            Session["userAuthenticationId"] = Person.Id;
            return RedirectToAction("Index", "Showcase");
        }
	}
}