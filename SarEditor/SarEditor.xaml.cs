using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;
using Windows.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SardineFish.UWP.Controls
{
    public sealed partial class SarEditor : UserControl
    {
        public SarEditor()
        {
            this.InitializeComponent();
        }

        
        public Brush SelectionHighlightColor { get; set; }

        public static DependencyProperty SelectionHighlightColorProperty = DependencyProperty.Register("SelectionHighlightColor", typeof(Brush), typeof(SarEditor), new PropertyMetadata(new SolidColorBrush(Windows.UI.Color.FromArgb(128, 0, 150, 255))));

        public CodeText Code = new CodeText();
        public void LoadCode(CodeText codeText)
        {
            Code = codeText;
            text.Inlines.Clear();
            lineNumber.Inlines.Clear();
            for (var i = 0; i < Code.Lines.Count; i++)
            {
                var line = Code.Lines[i];
                foreach (var word in line.Words)
                {
                    Run run = new Run();
                    run.Text = word.Text;
                    if (CodeWord.KeyWords.Contains(run.Text))
                    {
                        run.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 66, 156, 214));
                    }
                    else if (word.WordType == WordType.Comment || word.WordType == WordType.InlineComment)
                    {
                        run.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 96, 139, 78));
                    }
                    else if (word.WordType == WordType.Number)
                    {
                        run.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 181, 206, 168));
                    }
                    else if (word.WordType == WordType.QuotString)
                    {
                        run.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 214, 157, 133));
                    }
                    text.Inlines.Add(run);
                }
                text.Inlines.Add(new LineBreak());
                Run number = new Run();
                number.Text = (i + 1).ToString();
                lineNumber.Inlines.Add(number);
                lineNumber.Inlines.Add(new LineBreak());
            }
        }

    }
}
