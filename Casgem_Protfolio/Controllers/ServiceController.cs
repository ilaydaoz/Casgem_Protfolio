using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Casgem_Protfolio.Models.Entities;

namespace Casgem_Protfolio.Controllers
{
    public class ServiceController : Controller
    {
        casgemPorfolioEntities3 db = new casgemPorfolioEntities3();

        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Service()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("İndex");
        }
    }
}
