using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        // private readonly ILogger<EmployeeController> _logger;

        // public EmployeeController(ILogger<EmployeeController> logger)
        // {
        //     _logger = logger;
        // }

        public ApplicationDbContext db;
        public EmployeeController(ApplicationDbContext context)
        {
            db=context;
        }

        
        public IActionResult Index()
        {
            var employeeList=db.Employees.Include("Departments").ToList();
            return View(employeeList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DeptId=new SelectList(db.Departments,"DepartmentId","DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            var employeeList=db.Employees.Find(employeeId);
            if(employeeList!=null)
            {
                return View(employeeList);
            }
            else{
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(int employeeId,Employee employee)
        {
            var employeeList=db.Employees.Find(employeeId);
            if(employeeList!=null)
            {
                employeeList.FirstName=employee.FirstName;
                employeeList.LastName=employee.LastName;
                employeeList.DepartmentId=employee.DepartmentId;
                db.Update(employee);
                return RedirectToAction("Index");
            }
            else{
                return NotFound();
            }

        }
        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            var employeeList=db.Employees.Find(employeeId);
            if(employeeList!=null)
            {
                return View();
            }
            else{
                return NotFound();
            }
        } 
        [HttpPost]
        public IActionResult Delete(int employeeId,Employee employee)
        {
            var employeeList=db.Employees.Find(employeeId);
            if(employeeList!=null)
            {
                db.Employees.Remove(employeeList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult DeleteConfirmed(int employeeId)
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