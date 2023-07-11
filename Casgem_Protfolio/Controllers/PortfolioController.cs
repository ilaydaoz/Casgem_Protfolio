using Casgem_Protfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class PortfolioController : Controller
    {
        casgemPorfolioEntities db = new casgemPorfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle = db.TblFeature.Select(x =>
                 x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription = db.TblFeature.Select(x => 
            x.FeatureDescription).FirstOrDefault(); 
            ViewBag.featureImageURL = db.TblFeature.Select(x => 
            x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult MyResume ()
        {
            var values = db.TblResume.ToList();
            return PartialView();
    
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalService = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x =>
            x.MessageSubject == "Teşekürler").Count();
            return PartialView();
        }
    }
}
