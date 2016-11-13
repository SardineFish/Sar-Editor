using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardineFish.UWP.Controls
{
    public class CodeText
    {
        List<CodeLine> lines = new List<CodeLine>();
        public List<CodeLine> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public string Text
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.lines == null)
                {
                    return "";
                }
                foreach (var line in Lines)
                {
                    sb.AppendLine(line.Text);
                }
                return sb.ToString();
            }
            set
            {
                var lineList = value.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                Lines = new List<CodeLine>();
                var multiLineComment = false;
                for (var l =0;l<lineList.Length; l++)
                {
                    var lineText = lineList[l];
                    var line = new CodeLine();
                    line.Words = new List<CodeWord>();
                    var word = "";
                    for (var i = 0; i < lineText.Length; i++)
                    {
                    CheckNext:
                        if (i >= lineText.Length)
                            break;
                        #region multi line comment
                        if (multiLineComment)
                        {
                            var endComment = false;
                            for (; i < lineText.Length; i++)
                            {
                                if(i+1<lineText.Length && lineText [i]=='*' && lineText[i + 1] == '/')
                                {
                                    word += lineText[i];
                                    word += lineText[i + 1];
                                    i += 2;
                                    multiLineComment = false;
                                    endComment = true;
                                    break;
                                }
                                word += lineText[i];
                            }
                            CodeWord codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.InlineComment;
                            line.Words.Add(codeWord);
                            word = "";
                            if (!endComment)
                                break;
                            goto CheckNext;
                        }
                        #endregion
                        //check quot

                        if (lineText[i] == '"' || lineText[i] == '\'')
                        {
                            if(word .Length >0)
                            {
                                line.Words.Add(new CodeWord(word));
                                word = "";
                            }
                            var quot = lineText[i];
                            word += lineText[i];
                            for (i += 1; i < lineText.Length; i++)
                            {
                                word += lineText[i];
                                if (lineText [i]==quot && lineText[i - 1] != '\\')
                                {
                                    i += 1;
                                    break;
                                }
                            }
                            CodeWord codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.QuotString;
                            line.Words.Add(codeWord);
                            word = "";
                            goto CheckNext;
                        }
                        //Check comment
                        #region check comment
                        if (lineText[i] == '/' && i + 1 < lineText.Length && lineText[i + 1] == '/')
                        {
                            if (word.Length > 0)
                            {
                                line.Words.Add(new CodeWord(word));
                                word = "";
                            }
                            for (; i < lineText.Length; i++)
                            {
                                word += lineText[i];
                            }
                            var codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.Comment;
                            line.Words.Add(codeWord);
                            word = "";
                            break;

                        }
                        //check inline comment
                        if (lineText[i] == '/' && i + 1 < lineText.Length && lineText[i + 1] == '*')
                        {
                            if (word.Length > 0)
                            {
                                line.Words.Add(new CodeWord(word));
                                word = "";
                            }
                            var endComment = false;
                            for (; i < lineText.Length; i++)
                            {
                                if (lineText[i] == '*' && i + 1 < lineText.Length && lineText[i + 1] == '/')
                                {
                                    word += lineText[i];
                                    word += lineText[i + 1];
                                    endComment = true;
                                    break;
                                }
                                word += lineText[i];
                            }
                            var codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.InlineComment;
                            line.Words.Add(codeWord);
                            word = "";
                            if (i >= lineText.Length)
                            {
                                if (!endComment)
                                    multiLineComment = true;
                                break;
                            }
                            goto CheckNext;
                        }
                        #endregion
                        //check symbols
                        #region check symbols
                        if (CodeWord.Symbols.Contains(lineText[i]))
                        {
                            if (word.Length > 0)
                            {
                                line.Words.Add(new CodeWord(word));
                                word = "";
                            }
                            //check multi symbols
                            for (; i < lineText.Length && CodeWord.Symbols.Contains(lineText[i]); i++)
                            {
                                //check quot
                                if (lineText[i] == '"' || lineText[i] == '\'')
                                {
                                    if(word .Length > 0)
                                    {
                                        var code_word = new CodeWord(word);
                                        code_word.WordType = WordType.Symbol;
                                        line.Words.Add(code_word);
                                        word = "";
                                    }
                                    goto CheckNext;
                                }
                                //check comment
                                if (lineText[i] == '/' && i + 1 < lineText.Length && lineText[i + 1] == '/')
                                {
                                    if (word.Length > 0)
                                    {
                                        var code_word = new CodeWord(word);
                                        code_word.WordType = WordType.Symbol;
                                        line.Words.Add(code_word);
                                        word = "";
                                    }
                                    for (; i < lineText.Length; i++)
                                    {
                                        word += lineText[i];
                                    }
                                    var codeword = new CodeWord(word);
                                    codeword.WordType = WordType.Comment;
                                    line.Words.Add(codeword);
                                    word = "";
                                    break;
                                }
                                //check inline comment
                                if (lineText[i] == '/' && i + 1 < lineText.Length && lineText[i + 1] == '*')
                                {
                                    if (word.Length > 0)
                                    {
                                        var code_word = new CodeWord(word);
                                        code_word.WordType = WordType.Symbol;
                                        line.Words.Add(code_word);
                                        word = "";
                                    }
                                    var endComment = false;
                                    for (; i < lineText.Length; i++)
                                    {
                                        if (lineText[i] == '*' && i + 1 < lineText.Length && lineText[i + 1] == '/')
                                        {
                                            word += lineText[i];
                                            word += lineText[i + 1];
                                            i = i + 2;
                                            endComment = true;
                                            break;
                                        }
                                        word += lineText[i];
                                    }
                                    var codeword = new CodeWord(word);
                                    codeword.WordType = WordType.InlineComment;
                                    line.Words.Add(codeword);
                                    word = "";
                                    if (i >= lineText.Length)
                                    {
                                        if (!endComment)
                                            multiLineComment = true;
                                        break;
                                    }
                                    goto CheckNext;
                                }
                                //check range
                                if (i > lineText.Length)
                                {
                                    if (word.Length > 0)
                                    {
                                        var codeword = new CodeWord(word);
                                        codeword.WordType = WordType.Symbol;
                                        line.Words.Add(codeword);
                                        word = "";
                                    }
                                    break;
                                }
                                //add symbol to temp
                                word += lineText[i];
                            }
                            var codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.Symbol;
                            line.Words.Add(codeWord);
                            word = "";
                            goto CheckNext;
                        }
                        #endregion
                        //check white space
                        #region check white space
                        else if (lineText[i] == ' ')
                        {
                            if (word.Length > 0)
                            {
                                line.Words.Add(new CodeWord(word));
                                word = "";
                            }
                            //Indent
                            if (line.Words.Count <= 0)
                            {
                                for (; i < lineText.Length && lineText[i] == ' ';)
                                {
                                    for (var j = 0; j < 4 && i < lineText.Length && lineText[i] == ' '; j++, i++)
                                    {
                                        word += lineText[i];
                                    }
                                    var codeWord = new CodeWord(word);
                                    codeWord.WordType = WordType.Indent;
                                    line.Words.Add(codeWord);
                                    word = "";
                                }
                                goto CheckNext;
                            }
                            //check multi white space
                            else
                            {
                                for (; i < lineText.Length && lineText[i] == ' '; i++)
                                {
                                    word += lineText[i];
                                }
                                var codeWord = new CodeWord(word);
                                codeWord.WordType = WordType.WhiteSpace;
                                line.Words.Add(codeWord);
                                word = "";
                                goto CheckNext;
                            }
                        }
                        #endregion
                        //check number
                        #region check number
                        if (word.Length <= 0 && 48 <= (int)lineText[i] && lineText[i] <= 57)
                        {
                            if (i + 1 < lineText.Length && lineText[i] == '0' && (lineText[i + 1] == 'x' || lineText[i + 1] == 'X'))
                            {
                                word += lineText[i];
                                word += lineText[i + 1];
                                i += 2;
                            }
                            for (; i < lineText.Length && lineText[i] != ' ' && !CodeWord.Symbols.Contains(lineText[i]); i++)
                            {
                                word += lineText[i];
                            }
                            var codeWord = new CodeWord(word);
                            codeWord.WordType = WordType.Number;
                            line.Words.Add(codeWord);
                            word = "";
                            goto CheckNext;
                        }
                        #endregion

                        //nomal words
                        if (i < lineText.Length)
                            word += lineText[i];
                    }
                    if (word.Length > 0)
                    {
                        line.Words.Add(new CodeWord(word));
                        word = "";
                    }
                    Lines.Add(line);
                }
            }
        }
    }
}
