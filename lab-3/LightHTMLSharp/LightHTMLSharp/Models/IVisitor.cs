using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHTMLSharp.Models
{
    public interface IVisitor
    {
        void Visit(LightElementNode element);
        void Visit(LightTextNode text);
    }
}
