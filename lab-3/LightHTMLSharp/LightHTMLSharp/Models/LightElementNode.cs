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
        public IState State { get; private set; }

        public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses, List<LightNode> childNodes)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosingType = closingType;
            CssClasses = cssClasses;
            ChildNodes = childNodes;
            State = new ReadOnlyState(); // Встановлюємо початковий стан
        }

        public void SetState(IState state)
        {
            State = state;
            State.Render(this);
        }

        public override string OuterHTML
        {
            get
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append($"<{TagName}");

                // Додавання класів CSS
                if (CssClasses != null && CssClasses.Count > 0)
                {
                    htmlBuilder.Append(" class=\"");
                    htmlBuilder.Append(string.Join(" ", CssClasses));
                    htmlBuilder.Append("\"");
                }

                htmlBuilder.Append(">");

                // Додавання внутрішніх елементів
                foreach (var childNode in ChildNodes)
                {
                    htmlBuilder.Append(childNode.OuterHTML);
                }

                // Закриваючий тег
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
