using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.infrastucture.interfaces;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployesListController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployesListController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }
        
        public IActionResult Index()
        {
            return View(_EmployeesData.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeeView()); //Для создания нового сотрудника 
            
            if (id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int) id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentOutOfRangeException(nameof(Employee));

            if (Employee.Age < 18)
                ModelState.AddModelError(nameof(EmployeeView.Age), "Возраст сотрудника не может быть меньше 18 лет");

            if (Employee.FirstName == "Владимир" && Employee.Patronymic == "Владимирович" && Employee.LastName == "Путин")
                ModelState.AddModelError("", "Не может быть! Не верю!");

            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(Employee);
            else
                _EmployeesData.Edit(id, Employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult Create() => View(new EmployeeView());

        //[HttpPost]
        //public IActionResult Create(EmployeeView Model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(Model);

        //    _EmployeesData.Add(Model);
        //    _EmployeesData.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}