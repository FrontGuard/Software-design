using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class HoverState : IState
    {
        public void Render(LightElementNode element)
        {
            // Додаємо CSS клас або атрибут для стану наведення курсору
            if (!element.CssClasses.Contains("hover"))
            {
                element.CssClasses.Add("hover");
            }
        }
    }
}
