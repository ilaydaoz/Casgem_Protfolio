using Casgem_Protfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.phone = db.TblContact.Select(x => x.Phone).FirstOrDefault();
            ViewBag.mail = db.TblContact.Select(x => x.Mail).FirstOrDefault();
            ViewBag.adrress = db.TblContact.Select(x => x.Address).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }
        [HttpGet]
        public ActionResult Get()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var values = db.TblContact.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact p)
        {
            var value = db.TblContact.Find(p.ContactID);
            value.NameSurname = p.NameSurname;
            value.Address = p.Address;
            value.Age = p.Age;
            value.City = p.City;
            value.Phone = p.Phone;
            value.Mail = p.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}