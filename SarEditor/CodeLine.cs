using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardineFish.UWP.Controls
{
    
    public class CodeLine
    {
        List<CodeWord> words = new List<CodeWord>();
        public List<CodeWord> Words
        {
            get { return words; }
            set { words = value; }
        }

        public int IndentCount = 4;

        public string Text
        {
            get
            {
                var text = "";
                foreach (var word in Words )
                {
                    text += word.Text;
                }
                return text;
            }
            set
            {
                
            }
        }

        public CodeLine()
        {
            this.Words = new List<CodeWord>();
        }

        public CodeLine(string line)
        {
            this.Text = line;
        }


        public override string ToString()
        {
            return this.Text;
        }
    }
}
