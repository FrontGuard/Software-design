using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            Text = text;

            // Виклик хука OnCreated
            OnCreated();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string OuterHTML
        {
            get
            {
                OnTextRendered();
                return Text;
            }
        }

        public override string InnerHTML => Text;

        // Реалізація хуків життєвого циклу
        public override void OnCreated()
        {
            // Логіка, яка виконується при створенні текстового вузла
            System.Console.WriteLine("Text node created.");
        }

        public override void OnInserted()
        {
            // Логіка, яка виконується при вставці текстового вузла
            System.Console.WriteLine("Text node inserted.");
        }

        public override void OnRemoved()
        {
            // Логіка, яка виконується при видаленні текстового вузла
            System.Console.WriteLine("Text node removed.");
        }

        public override void OnTextRendered()
        {
            // Логіка, яка виконується при відображенні тексту
            System.Console.WriteLine("Text rendered.");
        }
    }
}
