using Casgem_Protfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class ServiceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblService.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var values = db.TblService.Find(p.ServiceID);
            values.ServiceTitle = p.ServiceTitle;
            values.ServiceNumber = p.ServiceNumber;
            values.ServiceContent = p.ServiceContent;
            values.ServiceIcon = p.ServiceIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
