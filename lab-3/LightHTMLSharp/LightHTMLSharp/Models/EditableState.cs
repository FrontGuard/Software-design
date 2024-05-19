using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class EditableState : IState
    {
        public void Render(LightElementNode element)
        {
            // Додаємо CSS клас або атрибут для редагування
            if (!element.CssClasses.Contains("editable"))
            {
                element.CssClasses.Add("editable");
            }
        }
    }
}
