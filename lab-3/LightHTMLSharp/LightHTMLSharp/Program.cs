using LightHTMLSharp.Models;

namespace LightHTMLSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new LightElementNode("table", "block", "dual", new List<string>(), new List<LightNode>
            {
                new LightElementNode("tr", "block", "dual", new List<string>(), new List<LightNode>
                {
                    new LightElementNode("td", "inline", "dual", new List<string>(), new List<LightNode>
                    {
                        new LightTextNode("Row 1, Cell 1")
                    }),
                    new LightElementNode("td", "inline", "dual", new List<string>(), new List<LightNode>
                    {
                        new LightTextNode("Row 1, Cell 2")
                    })
                }),
                new LightElementNode("tr", "block", "dual", new List<string>(), new List<LightNode>
                {
                    new LightElementNode("td", "inline", "dual", new List<string>(), new List<LightNode>
                    {
                        new LightTextNode("Row 2, Cell 1")
                    }),
                    new LightElementNode("td", "inline", "dual", new List<string>(), new List<LightNode>
                    {
                        new LightTextNode("Row 2, Cell 2")
                    })
                })
            });

            // Використання відвідувача для валідації
            IVisitor validator = new ValidationVisitor();
            table.Accept(validator);

            Console.WriteLine("HTML Output:");
            Console.WriteLine(table.OuterHTML);
        }
    }
}
