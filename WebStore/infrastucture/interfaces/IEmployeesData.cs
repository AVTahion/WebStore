using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.infrastucture.interfaces
{
    /// <summary>
    /// Сервис сотрудников
    /// </summary>
    interface IEmployeesData
    {
        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        /// <returns>Перечисление всех сотрудников, известных сервису</returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>
        /// Получение сотрудника по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором, либо null</returns>
        EmployeeView GetById(int id);

        /// <summary>
        /// Добавление нового сотрудника в сервис
        /// </summary>
        /// <param name="Employee">Модель с данными, добавляемового сотрудника</param>
        void Add(EmployeeView Employee);

        /// <summary>
        /// Редактирование данных сотрудника по указанному идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="Employee">Модель с данными сотрудника, которые нужно внести в сервис</param>
        void Edit(int id, EmployeeView Employee);

        /// <summary>
        /// Удаление сотрудника по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого сотрудника</param>
        /// <returns>true - удален</returns>
        bool Delete(int id);

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void SaveChanges();
    }
}
