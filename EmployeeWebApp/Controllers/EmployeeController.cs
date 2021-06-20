using EmployeeWebApp.Common;
using EmployeeWebApp.DAL;
using EmployeeWebApp.Models;
using EmployeeWebApp.VM;
using System.Web.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL _employeeDAL = new EmployeeDAL();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult GetAll()
        {
            return PartialView("_EmployeeTable", _employeeDAL.GetAll());
        }
        [HttpGet]
        public PartialViewResult Add()
        {
            ViewBag.FormName = FormName.Add.ToString();
            return PartialView("_EmployeeForm");
        }
        [HttpPost]
        public JsonResult Add(EmployeeVM empVM)
        {
            var obj = new Employee()
            {
                Id = empVM.Id,
                FirstName = empVM.FirstName,
                LastName = empVM.LastName,
                PhoneNumber = empVM.PhoneNumber,
                age = empVM.age
            };
            (bool done, string message) = _employeeDAL.Add(obj);
            return Json(new { done, message }, 
                JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            ViewBag.FormName = FormName.Edit.ToString();
            var emp = _employeeDAL.GetOne(id);
            var empVM = new EmployeeVM(){
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                age = emp.age,
                PhoneNumber = emp.PhoneNumber
            };
            return PartialView("_EmployeeForm", empVM);
        }
        [HttpPost]
        public JsonResult Edit(EmployeeVM empVM)
        {
            var obj = new Employee()
            {
                Id = empVM.Id,
                FirstName = empVM.FirstName,
                LastName = empVM.LastName,
                PhoneNumber = empVM.PhoneNumber,
                age = empVM.age
            };
            (bool done, string message) = _employeeDAL.Edit(obj);
            return Json(new { done, message }, 
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            (bool done, string message) = _employeeDAL.Delete(id);
            return Json(new { done, message },
                JsonRequestBehavior.AllowGet);
        }
    }
}