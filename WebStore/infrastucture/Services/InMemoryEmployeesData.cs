using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.infrastucture.interfaces;
using WebStore.ViewModels;

namespace WebStore.infrastucture.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeView> _Employes = new List<EmployeeView>
        {
            new EmployeeView { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 35, TelNumber = "001-01-1" },
            new EmployeeView { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 25, TelNumber = "002-02-2" },
            new EmployeeView { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 45, TelNumber = "003-03-3" },
        };

        public void Add(EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            Employee.Id = _Employes.Count == 0 ? 1 : _Employes.Max(e => e.Id) + 1;
            _Employes.Add(Employee);
        }
     
        public bool Delete(int id)
        {
            var db_employee = GetById(id);
            if (db_employee is null) return false;
            return _Employes.Remove(db_employee);
        }

        public void Edit(int id, EmployeeView Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            var db_employee = GetById(id);
            if (db_employee is null) return;

            db_employee.FirstName = Employee.FirstName;
            db_employee.LastName = Employee.LastName;
            db_employee.Patronymic = Employee.Patronymic;
            db_employee.Age = Employee.Age;
            db_employee.TelNumber = Employee.TelNumber;
        }

        public IEnumerable<EmployeeView> GetAll() => _Employes;

        public EmployeeView GetById(int id) => _Employes.FirstOrDefault(e => e.Id == id);

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
