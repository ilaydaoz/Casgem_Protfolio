using Casgem_Protfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class MessageController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblMessage.ToList();
            return View(values);
        }

        public ActionResult MessageDelete(int id)
        {
            var values = db.TblMessage.Find(id);
            db.TblMessage.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MessageDetails(int id)
        {
            var values = db.TblMessage.Find(id);
            return View(values);
        }
    }
}