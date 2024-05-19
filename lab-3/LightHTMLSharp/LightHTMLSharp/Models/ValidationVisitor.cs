using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class ValidationVisitor : IVisitor
    {
        public void Visit(LightElementNode element)
        {
            if (string.IsNullOrEmpty(element.TagName))
            {
                Console.WriteLine("Element with missing tag name.");
            }

            foreach (var child in element.ChildNodes)
            {
                if (child is LightElementNode elementNode)
                {
                    elementNode.Accept(this);
                }
                else if (child is LightTextNode textNode)
                {
                    textNode.Accept(this);
                }
            }
        }

        public void Visit(LightTextNode text)
        {
            if (string.IsNullOrEmpty(text.Text))
            {
                Console.WriteLine("Text node with empty text.");
            }
        }
    }
}
