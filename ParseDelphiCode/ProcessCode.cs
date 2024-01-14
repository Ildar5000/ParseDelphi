using ParseDelphiCode.ModelParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode
{
    public class ProcessCode
    {
        public List<string> without_comment { get; set; }

        private Stack<string> comment;
        
        private Stack<IKeyToken> object_com;


        public string UnitName { get; set; }

        public List<IKeyToken> tokenOperations { get; set; }

        public ProcessCode()
        {
            without_comment = new List<string>();
            comment = new Stack<string>();
            tokenOperations = new List<IKeyToken>();
            object_com=new Stack<IKeyToken>();
        }



        #region delete comment
        public void DeleteComment(string text)
        {
            //delete stroke
            string[] stroke = text.Split(new[] { '\r', '\n' });

            foreach (var str in stroke)
            {
                if (String.IsNullOrEmpty(str))
                {
                    continue;
                }

                if (str.Contains(KeyWords.SingleComment))
                {
                    string[] st = str.Split(KeyWords.SingleComment);

                    if (String.IsNullOrEmpty(st[0]))
                    {
                        continue;
                    }
                    else
                    {
                        without_comment.Add(st[0]);
                    }

                    continue;
                }

                if ((comment.Count > 0)|| (str.Contains(KeyWords.MultiCommentStart)))
                {

                    if (str.Contains(KeyWords.MultiCommentStart))
                    {
                        comment.Push(str);
                    }

                    if (str.Contains(KeyWords.MultiCommentEnd))
                    {
                        comment.Pop();
                    }
                    continue;
                }

                without_comment.Add(str);

            }
        }



        #endregion
        
        
        
        /// <summary>
        /// определяем какой символ есть
        /// </summary>
        /// <param name="line"></param>
        private string ContainsWhoSumbol(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                if (line.Contains(KeyWords.EndOperator))
                {
                    return KeyWords.EndOperator;
                }

                if (line.Contains(KeyWords.EnumeratorValue))
                {
                    return KeyWords.EnumeratorValue;
                }

                if (line.Contains(" "))
                {
                    return " ";
                }
                return "";
            }
            return "";
        }

        private void ProcessSingleOperation(string[] line)
        {
            IKeyToken keyToken = null;
            foreach (var w in line)
            {
                switch (w.ToLower())
                {
                    case "unit":
                        keyToken = new FirstValueOperation(line);
                        break;
                    case "interface":
                        keyToken = new SingleOperation(line[0]);
                        break;
                    case "uses":
                        keyToken = new UsesTokenOperation(line);
                        object_com.Push(keyToken);
                        comment.Push("uses");
                        break;
                    }

                }

                tokenOperations.Add(keyToken);
        }


        private void SyntaxWords(string line,string symbol)
        {
            string[] operation = line.Split(symbol);
            if (object_com.Count==0)
            {
                if (KeyWords.MultiOperation(symbol) == 2)
                {
                    foreach (string op in operation)
                    {
                        if (!string.IsNullOrEmpty(op))
                        {
                            string sub_symbol = ContainsWhoSumbol(op);
                            string[] oper = op.Split(sub_symbol);
                            ProcessSingleOperation(oper);

                        }
                    }
                }
                else
                {
                    ProcessSingleOperation(operation);
                }
            }
            else
            {
                IKeyToken token= (IKeyToken)object_com.Peek();

                if (KeyWords.MultiOperation(symbol) == 2)
                {
                    foreach (string op in operation)
                    {
                        string sub_symbol = ContainsWhoSumbol(op);
                        string[] oper = op.Split(sub_symbol);
                        //ProcessSingleOperation(oper);
                        MultiOperationFactory.AddValueAndEnd(token, oper);
                    }
                    object_com.Pop();
                }
                
                if (KeyWords.EnumeratorOperator(symbol)==1)
                {
                    MultiOperationFactory.AddValue(token, operation);
                }

            }
            

        }


        public void ProcessMainComponents()
        {
            foreach (var stroka in without_comment)
            {
                string symbol = ContainsWhoSumbol(stroka);
                SyntaxWords(stroka, symbol);
            }
        }


    }
}
