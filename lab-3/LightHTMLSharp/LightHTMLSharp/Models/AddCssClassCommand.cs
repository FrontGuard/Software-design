using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class AddCssClassCommand : ICommand
    {
        private LightElementNode _element;
        private string _cssClass;

        public AddCssClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public void Execute()
        {
            _element.CssClasses.Add(_cssClass);
        }

        public void Undo()
        {
            _element.CssClasses.Remove(_cssClass);
        }
    }
}
