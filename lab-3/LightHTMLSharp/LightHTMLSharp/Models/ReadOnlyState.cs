using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class ReadOnlyState : IState
    {
        public void Render(LightElementNode element)
        {
            // Додаємо CSS клас або атрибут для режиму тільки для читання
            if (!element.CssClasses.Contains("read-only"))
            {
                element.CssClasses.Add("read-only");
            }
        }
    }
}
