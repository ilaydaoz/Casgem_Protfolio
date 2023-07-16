using Casgem_Protfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Protfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();

            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(
                y => y.EmployeeName + " " + y.EmployeSurname).FirstOrDefault();


            ViewBag.totalCityCount = db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.countSoftwareDepartment = db.TblEmployee.Where(
                x => x.EmployeeDepartment == db.TblDepartment.Where(
                    z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentID).FirstOrDefault()).Count();

            ViewBag.cityAdanaOrAnkaraTotalSalary = db.TblEmployee.Where(
                x => x.EmployeeCity == "Ankara" || x.EmployeeCity == "Adana").Sum(y => y.EmployeeSalary);

            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployee.Where(
                x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartment.Where(
                    z => z.DepartmentName == "Yazılım").Select(
                    y => y.DepartmentID).FirstOrDefault()).Sum(y => y.EmployeeSalary);

            return View();
        }
    }
}