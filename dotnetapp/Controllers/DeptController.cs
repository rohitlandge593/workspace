using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Data;

namespace dotnetapp.Controllers
{
    [Route("[controller]")]
    public class DeptController : Controller
    {
        // private readonly ILogger<DeptController> _logger;

        // public DeptController(ILogger<DeptController> logger)
        // {
        //     _logger = logger;
        // }

        public EmployeeDbContext db;
        public DeptController(EmployeeDbContext context)
        {
            db=context;
        }

        public IActionResult Index()
        {
            var deptList=db.Depts;
            return View(deptList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            db.Depts.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int deptId)
        {
            var deptList=db.Depts.Find(deptId);
            if(deptList!=null)
            {
                return View();
            }
            else{
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(int deptId,Dept dept)
        {
            var deptList=db.Depts.Find(deptId);
            if(deptList!=null)
            {
                deptList.DepartmentId=dept.DepartmentId;
                deptList.DepartmentName=dept.DepartmentName;
                db.Update();
                return RedirectToAction("Index");
            }
            else 
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Delete(int deptId)
        {
            var deptList=db.Depts.Find(deptId);
            if(deptList!=null)
            {
                return View();
            }
            else{
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(int deptId,Dept dept)
        {
            var deptList=db.Depts.Find(deptId);
            if(deptList!=null)
            {
                db.Depts.Remove(deptList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}