using Casgem_Protfolio.Models.Entities;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class ContactController : Controller
    {
        casgemPorfolioEntities db = new casgemPorfolioEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }
    }
}