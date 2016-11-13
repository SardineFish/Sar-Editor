using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardineFish.UWP.Controls
{
    public enum WordType
    {
        WhiteSpace,
        Indent,
        Text,
        Symbol,
        Comment,
        InlineComment,
        QuotString,
        Number,
        KeyWord,
    }
    public class CodeWord
    {
        public static char[] Symbols = new char[] { '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '`', '-', '=', '{', '}', ':', '"', '|', '<', '>', '?', '[', ']', ';', '\'', '\\', ',', '.', '/', };
        public static string[] KeyWords = new string[] {"abstract",
                                                        "arguments",
                                                        "boolean",
                                                        "break",
                                                        "byte",
                                                        "case",
                                                        "catch",
                                                        "char",
                                                        "class*",
                                                        "const",
                                                        "continue",
                                                        "debugger",
                                                        "default",
                                                        "delete",
                                                        "do",
                                                        "double",
                                                        "else",
                                                        "enum*",
                                                        "eval",
                                                        "export*",
                                                        "extends*",
                                                        "false",
                                                        "final",
                                                        "finally",
                                                        "float",
                                                        "for",
                                                        "function",
                                                        "goto",
                                                        "if",
                                                        "implements",
                                                        "import*",
                                                        "in",
                                                        "instanceof",
                                                        "int",
                                                        "interface",
                                                        "let",
                                                        "long",
                                                        "native",
                                                        "new",
                                                        "null",
                                                        "package",
                                                        "private",
                                                        "protected",
                                                        "public",
                                                        "return",
                                                        "short",
                                                        "static",
                                                        "super*",
                                                        "switch",
                                                        "synchronized",
                                                        "this",
                                                        "throw",
                                                        "throws",
                                                        "transient",
                                                        "true",
                                                        "try",
                                                        "typeof",
                                                        "var",
                                                        "void",
                                                        "volatile",
                                                        "while",
                                                        "with",
                                                        "yield",};
        public static string[] KeyWordsCSharp = new string[] {"abstract",
                                                        "event",
                                                        "new",
                                                        "struct",
                                                        "as",
                                                        "explicit",
                                                        "null",
                                                        "switch",
                                                        "base",
                                                        "extern",
                                                        "object",
                                                        "this",
                                                        "bool",
                                                        "false",
                                                        "operator",
                                                        "throw",
                                                        "break",
                                                        "finally",
                                                        "out",
                                                        "true",
                                                        "byte",
                                                        "fixed",
                                                        "override",
                                                        "try",
                                                        "case",
                                                        "float",
                                                        "params",
                                                        "typeof",
                                                        "catch",
                                                        "for",
                                                        "private",
                                                        "uint",
                                                        "char",
                                                        "foreach",
                                                        "protected",
                                                        "ulong",
                                                        "checked",
                                                        "goto",
                                                        "public",
                                                        "unchecked",
                                                        "class",
                                                        "if",
                                                        "readonly",
                                                        "unsafe",
                                                        "const",
                                                        "implicit",
                                                        "ref",
                                                        "ushort",
                                                        "continue",
                                                        "in",
                                                        "return",
                                                        "using",
                                                        "decimal",
                                                        "int",
                                                        "sbyte",
                                                        "virtual",
                                                        "default",
                                                        "interface",
                                                        "sealed",
                                                        "volatile",
                                                        "delegate",
                                                        "internal",
                                                        "short",
                                                        "void",
                                                        "do",
                                                        "is",
                                                        "sizeof",
                                                        "while",
                                                        "double",
                                                        "lock",
                                                        "stackalloc",
                                                        "else",
                                                        "long",
                                                        "static",
                                                        "enum",
                                                        "namespace",
                                                        "string",
        };
        public string Text { get; set; }
        

        WordType wordType = WordType.Text;
        public WordType WordType
        {
            get { return wordType; }
            set { wordType = value; }
        }

        public CodeWord (string word)
        {
            this.Text = word;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
