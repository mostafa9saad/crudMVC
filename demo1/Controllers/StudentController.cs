using demo1.Models;
using demo1.servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo1.Controllers
{
    public class StudentController : Controller
    {
        StudentServises std = new StudentServises();
        public IActionResult showStd()
        {

            return View(std.getAll());
        }

        public IActionResult createStd()
        {
            DepartmentNameServises deptList = new DepartmentNameServises();
            ViewBag.id = std.getLastId() + 1;
            SelectList deptSelect = new SelectList(deptList.GetAll(), "Id", "Name");
            ViewBag.depts = deptSelect;

            return View();
        }
        [HttpPost]
        public IActionResult createStd(Student s)
        {
            std.AddStd(s);
            return RedirectToAction("showStd");
        }
        public IActionResult delete(int id)
        {
            std.deleteById(id);

            return RedirectToAction("showStd");
        }
        public IActionResult ditails(int id)
        {
            Student s = std.getStdById(id);
            return View(s);
        }
        public IActionResult editstd(int id)
        {
            ViewBag.id = id;
            DepartmentNameServises deptList = new DepartmentNameServises();
            Student s = std.getStdById(id);
            SelectList deptSelect = new SelectList(deptList.GetAll(), "Id", "Name", id);
            ViewBag.depts = deptSelect;
            return View(s);
        }
        [HttpPost]
        public IActionResult editstd(Student dept)
        {
            std.UpdateById(dept);
            return RedirectToAction("showStd");
        }

        public IActionResult CheckEmail(string Email, int Id)
        {
            Student s = std.getAll().FirstOrDefault(x => x.Email == Email && x.Id != Id);
            if (s == null)
            {
                return Json(true);

            }
            else { return Json(false); }
        }
    }
}
