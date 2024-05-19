using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public interface IIterator
    {
        LightNode First();
        LightNode Next();
        bool IsDone();
        LightNode CurrentItem();
    }
}
