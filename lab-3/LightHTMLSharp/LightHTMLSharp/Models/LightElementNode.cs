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
    }
}
