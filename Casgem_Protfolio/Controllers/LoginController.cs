using Casgem_Protfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Protfolio.Controllers
{
    public class LoginController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var values = db.TblAdmin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["usertravel"] = values.Username.ToString();
                return RedirectToAction("Index", "WhoAmI");
            }
            else
            {
                return View();
            }
        }
    }
}