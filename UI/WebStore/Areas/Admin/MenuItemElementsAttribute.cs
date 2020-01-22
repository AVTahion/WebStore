using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Areas.Admin
{
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MenuItemElementsAttribute : Attribute
    {
        public string Title { get; }
        public string Ico { get; }

        public MenuItemElementsAttribute(string title) => Title = title;

        public MenuItemElementsAttribute(string title, string ico)
        {
            Title = title;
            Ico = ico;
        }
    }
}
