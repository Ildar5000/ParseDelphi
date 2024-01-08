using ParseDelphiCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiParse
{
    public class ReadSingleFile
    {
        ProcessCode processCode =new ProcessCode();

        public void ReadFile(string path)
        {
            using (StreamReader fileStream = new StreamReader(path))
            {
                string line=fileStream.ReadToEnd();
                processCode.DeleteComment(line);
                WriteFile(@"outputwithouttxt.pas");


            }


        }

        public void WriteFile(string path)
        {
            using (StreamWriter fileStream = new StreamWriter(path))
            {
                foreach (var line in processCode.without_comment)
                {
                    fileStream.WriteLine(line);
                }
            }
        }


    }
}
