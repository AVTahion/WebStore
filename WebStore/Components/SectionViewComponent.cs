using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.infrastucture.interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class SectionViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;
        public SectionViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke() => View(GetSections());

        //public async Task<IViewComponentResult> InvokeAsync() => View();
        
        private IEnumerable<SectionViewModel> GetSections()
        {
            var sections = _ProductData.GetSections();
            var parent_sections = sections.Where(section => section.ParentId is nuul).ToArray;
        }
    }
}
