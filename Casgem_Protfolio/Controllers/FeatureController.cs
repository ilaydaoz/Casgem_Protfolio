using Casgem_Protfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class FeatureController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var value = db.TblFeature.Find(p.FeatureID);
            value.FeatureID = p.FeatureID;
            value.FeatureDescription = p.FeatureDescription;
            value.FeatureImageURL = p.FeatureImageURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}