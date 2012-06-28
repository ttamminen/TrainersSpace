using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainersSpace.Models;

namespace TrainersSpace.Controllers
{
    public class HomeController : RavenController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var myClient = new Client { Age = 10, Name = "Uusi asiakas" };

            Session.Store(myClient);

            return View();
        }
    }
}
