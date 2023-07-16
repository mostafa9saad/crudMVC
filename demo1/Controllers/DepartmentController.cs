using demo1.Models;
using demo1.servises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace demo1.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentServises DS = new DepartmentServises();

        public IActionResult dispalyD()
        {

            return View(DS.getAll());
        }
        public IActionResult addDept()
        {

            DepartmentServises DS = new DepartmentServises();
            ViewBag.id = DS.getLastId() + 1;

            return View();
        }
        [HttpPost]
        public IActionResult addDept(Department dept)
        {
            if (ModelState.IsValid)
            {

                DepartmentNameServises DN = new DepartmentNameServises();
                DS.Add(dept);
                DN.addDept(dept);

                return RedirectToAction("dispalyD");
            }
            return View();
        }
        public IActionResult ditails(int id)
        {
            Department dept = DS.getDeptById(id);
            return View(dept);
        }
        public IActionResult delete(int id)
        {
            DS.deleteById(id);
            return RedirectToAction("dispalyD");
        }
        public IActionResult edit(int id)
        {
            ViewBag.id = id;
            Department d = DS.getDeptById(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult edit(Department dept)
        {
            if (ModelState.IsValid) { 
            DS.UpdateById(dept);
            return RedirectToAction("dispalyD");
            }
            return View();
        }

    }
}
