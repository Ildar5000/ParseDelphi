using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode
{
    public class ProcessCode
    {
        public List<string> without_comment {  get; set; }

        private Stack<string> comment;

        public ProcessCode()
        {
            without_comment = new List<string>();
            comment = new Stack<string>();

        }




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




    }
}
