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
            if (modelReponse != null && modelReponse.Domain.Count > 0)
                Session["userAuthentication"] = modelReponse.Domain;
            var redView = modelReponse.logical ? "Index" : "Index";
            var redRoute = modelReponse.logical ? "Showcase" : "Authentication";
            return RedirectToAction(redView, redRoute);
        }
	}
}