using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public class HTMLIterator : IIterator
    {
        private List<LightNode> nodes;
        private int position = 0;

        public HTMLIterator(List<LightNode> nodes)
        {
            this.nodes = nodes;
        }

        public LightNode First()
        {
            if (nodes.Count > 0)
                return nodes[0];
            else
                return null;
        }

        public LightNode Next()
        {
            position++;
            if (position < nodes.Count)
                return nodes[position];
            else
                return null;
        }

        public bool IsDone()
        {
            return position >= nodes.Count;
        }

        public LightNode CurrentItem()
        {
            return nodes[position];
        }
    }
}
