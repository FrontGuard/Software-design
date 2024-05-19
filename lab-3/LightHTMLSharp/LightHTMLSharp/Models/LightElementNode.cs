using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public string DisplayType { get; }
        public string ClosingType { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> ChildNodes { get; }

        public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses, List<LightNode> childNodes)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosingType = closingType;
            CssClasses = cssClasses;
            ChildNodes = childNodes;

            // Виклик хука OnCreated
            OnCreated();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var childNode in ChildNodes)
            {
                childNode.Accept(visitor);
            }
        }

        public override string OuterHTML
        {
            get
            {
                OnStylesApplied();
                OnClassListApplied();

                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append($"<{TagName}");

                if (CssClasses != null && CssClasses.Count > 0)
                {
                    htmlBuilder.Append(" class=\"");
                    htmlBuilder.Append(string.Join(" ", CssClasses));
                    htmlBuilder.Append("\"");
                }

                htmlBuilder.Append(">");

                foreach (var childNode in ChildNodes)
                {
                    htmlBuilder.Append(childNode.OuterHTML);
                }

                if (ClosingType == "dual")
                {
                    htmlBuilder.Append($"</{TagName}>");
                }
                else if (ClosingType == "single")
                {
                    htmlBuilder.Append(" /");
                }

                OnTextRendered();
                return htmlBuilder.ToString();
            }
        }

        public override string InnerHTML
        {
            get
            {
                StringBuilder htmlBuilder = new StringBuilder();
                foreach (var childNode in ChildNodes)
                {
                    htmlBuilder.Append(childNode.OuterHTML);
                }
                return htmlBuilder.ToString();
            }
        }

        // Реалізація хуків життєвого циклу
        public override void OnCreated()
        {
            // Логіка, яка виконується при створенні елемента
            System.Console.WriteLine($"{TagName} element created.");
        }

        public override void OnInserted()
        {
            // Логіка, яка виконується при вставці елемента
            System.Console.WriteLine($"{TagName} element inserted.");
        }

        public override void OnRemoved()
        {
            // Логіка, яка виконується при видаленні елемента
            System.Console.WriteLine($"{TagName} element removed.");
        }

        public override void OnStylesApplied()
        {
            // Логіка, яка виконується при застосуванні стилів
            System.Console.WriteLine($"Styles applied to {TagName} element.");
        }

        public override void OnClassListApplied()
        {
            // Логіка, яка виконується при застосуванні класів
            System.Console.WriteLine($"Class list applied to {TagName} element.");
        }

        public override void OnTextRendered()
        {
            // Логіка, яка виконується при відображенні тексту
            System.Console.WriteLine($"Text rendered in {TagName} element.");
        }
    }
}
