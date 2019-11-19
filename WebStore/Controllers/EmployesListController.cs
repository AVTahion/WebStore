﻿using System;
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
    }
}