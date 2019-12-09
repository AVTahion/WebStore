using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона для связи")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан адрес доставки")]
        public string Address { get; set; }
    }
}
