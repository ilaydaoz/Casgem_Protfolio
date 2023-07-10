using Casgem_Protfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class ProjectController : Controller
    {
        casgemPorfolioEntities db = new casgemPorfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddProject(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}