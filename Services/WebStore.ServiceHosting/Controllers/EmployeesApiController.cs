using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.infrastucture.interfaces;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/employees")]
    //[Route("api/[controller]")] //Путь "api/EmployeesApi"
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) { _EmployeesData = EmployeesData; }

        [HttpPost, ActionName("Post")]
        public void Add(EmployeeView Employee) => _EmployeesData.Add(Employee);

        [HttpDelete("{id}")]
        public bool Delete(int id) => _EmployeesData.Delete(id);

        [HttpPut("{id}"), ActionName("Put")]
        public EmployeeView Edit(int id, EmployeeView Employee) => _EmployeesData.Edit(id, Employee);

        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeView> GetAll() => _EmployeesData.GetAll();

        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeView GetById(int id) => _EmployeesData.GetById(id);

        [NonAction]
        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}