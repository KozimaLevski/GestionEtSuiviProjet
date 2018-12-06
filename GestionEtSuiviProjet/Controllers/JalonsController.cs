using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionEtSuiviProjet.Controllers
{
    public class JalonsController : Controller
    {
        public ActionResult ListeJalons()
        {
            return View("ListeJalons");
        }
        

    }
}