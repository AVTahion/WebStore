using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;
using WebStore.infrastucture.interfaces;

namespace WebStore.Controllers
{
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

        public IActionResult Edit(int? id)
        {
            if (id is null) 
                return View(new EmployeeView()); //Для создания нового сотрудника 
            if (id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int) id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            if (!ModelState.IsValid)
                View(Model);

            var id = Model.Id;
            if(id == 0)
                _EmployeesData.Add(Model);
            else
                _EmployeesData.Edit(id, Model);

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

        public IActionResult Delete(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}