using Casgem_Protfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
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

        public PartialViewResult MyResume()
        {
            var values = db.TblResume.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count();
            ViewBag.happyCustomer = 12;
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {

            var textArray = db.TblSkill.Select(x => x.SkillName).ToArray();

            ViewBag.skillArray = textArray;

            return PartialView();
        }

        public PartialViewResult PartialWhoIAm()
        {

            ViewBag.title = db.TblWhoAmI.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = db.TblWhoAmI.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }



        [HttpGet]
        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(this.Server.MapPath("~/Templates/file/ilayda_ozken.pdf"));
            string fileName = "ilayda_ozken.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        
        public PartialViewResult PartialService()
        {

            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialVideo()
        {
            ViewBag.title = db.TblVideo.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = db.TblVideo.Select(x => x.Description).FirstOrDefault();
            ViewBag.video = db.TblVideo.Select(x => x.VideoFrame).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            var values = db.TblSocial.ToList();
            return PartialView(values);
        }

    }
}
