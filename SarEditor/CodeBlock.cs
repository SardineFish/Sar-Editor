using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardineFish.UWP.Controls
{
    public class CodeBlock
    {
        List<CodeLine> lines = new List<CodeLine>();
        public List<CodeLine> Linse
        {
            get { return lines; }
            set { lines = value; }
        }
    }
}
