using Casgem_Protfolio.Models.Entities;
using System.Linq;
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
            return PartialView(values);
    
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x =>
            x.MessageSubject == "Teşekkür").Count();
            ViewBag.happyCustomer = 12;
            return PartialView();
        }
        public FileResult DownloadCV(string file)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Templates/file/" + file + ""));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }
    }
}
