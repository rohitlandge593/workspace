using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private ApplicationDbContext _context;
        private DepartmentController _controller;

        [SetUp]
        public void Setup()
        {
            // Create an in-memory database for testing
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("InMemoryDatabase")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new ApplicationDbContext(options);

            // Seed the in-memory database with sample data
            _context.Departments.Add(new Department { DepartmentId = 1, Name = "Department 1" });
            _context.SaveChanges();

            _controller = new DepartmentController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the in-memory database after each test
            _context.Dispose();
        }

        [Test]
        public void Index_ReturnsViewWithDepartments()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Department>;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count);
        }

       [Test]
public void Create_GET_ReturnsView()
{
    // Act
    var result = _controller.Create() as ViewResult;

    // Assert
    Assert.IsNotNull(result);
}

[Test]
public void Create_POST_ValidModel_RedirectsToIndex()
{
    // Arrange
    var department = new Department
    {
        Name = "New Department"
    };

    // Act
    var result = _controller.Create(department) as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ActionName);
}

[Test]
public void Delete_GET_ValidId_ReturnsViewWithDepartment()
{
    // Act
    var result = _controller.Delete(1) as ViewResult;

    // Assert
    Assert.IsNotNull(result);
    var model = result.Model as Department;
    Assert.IsNotNull(model);
}

[Test]
public void Delete_POST_ValidId_RedirectsToIndex()
{
    // Act
    var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ActionName);
}

[Test]
public void Delete_POST_InvalidId_ReturnsNotFound()
{
    // Act
    var result = _controller.DeleteConfirmed(2);

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<NotFoundResult>(result);
}

    }
}
