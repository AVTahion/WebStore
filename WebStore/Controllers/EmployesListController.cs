using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployesListController : Controller
    {
        private static readonly List<EmployeeView> __Employes = new List<EmployeeView>
        {
            new EmployeeView { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 35, TelNumber = "001-01-1" },
            new EmployeeView { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 25, TelNumber = "002-02-2" },
            new EmployeeView { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 45, TelNumber = "003-03-3" },
        };
        public IActionResult Index()
        {
            return View(__Employes);
        }

        public IActionResult Details(int id)
        {
            return View(__Employes.Find( i => i.Id == id));
        }
    }
}