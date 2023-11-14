using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        // private readonly ILogger<DeptController> _logger;

        // public DeptController(ILogger<DeptController> logger)
        // {
        //     _logger = logger;
        // }

        public ApplicationDbContext db;
        public DepartmentController(ApplicationDbContext context)
        {
            db=context;
        }

        public IActionResult Index()
        {
            var deptList=db.Departments;
            return View(deptList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int deptId)
        {
            var deptList=db.Departments.Find(deptId);
            if(deptList!=null)
            {
                return View();
            }
            else{
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(int deptId,Department dept)
        {
            var deptList=db.Departments.Find(deptId);
            if(deptList!=null)
            {
                deptList.DepartmentId=dept.DepartmentId;
                deptList.Name=dept.Name;
                db.SaveChanges();
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
            var deptList=db.Departments.Find(deptId);
            if(deptList!=null)
            {
                return View();
            }
            else{
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(int deptId,Department dept)
        {
            var deptList=db.Departments.Find(deptId);
            if(deptList!=null)
            {
                db.Departments.Remove(deptList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return NotFound();
            }
        }
        public IActionResult DeleteConfirmed(int departmentId)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}