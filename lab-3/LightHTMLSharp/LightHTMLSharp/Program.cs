using LightHTMLSharp.Models;

namespace LightHTMLSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення таблиці за допомогою мови розмітки LightHTML
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

            // Встановлення різних станів
            table.SetState(new EditableState());
            Console.WriteLine("Editable State:");
            Console.WriteLine(table.OuterHTML);

            table.SetState(new ReadOnlyState());
            Console.WriteLine("Read-Only State:");
            Console.WriteLine(table.OuterHTML);

            table.SetState(new HoverState());
            Console.WriteLine("Hover State:");
            Console.WriteLine(table.OuterHTML);
        }
    }
}
