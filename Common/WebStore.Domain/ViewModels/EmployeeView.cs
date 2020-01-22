using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Domain.ViewModels
{
    public class EmployeeView
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите имя сотрудника")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длинна имени должна быть от 2 до 30 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите фамилию сотрудника")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длинна фамилии должна быть от 2 до 30 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Укажите возраст сотрудника")]
        public int Age { get; set; }

        [Display(Name = "Номер телефона")]
        public string TelNumber { get; set; }
    }
}
