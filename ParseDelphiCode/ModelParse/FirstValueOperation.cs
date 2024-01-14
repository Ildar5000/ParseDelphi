using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode.ModelParse
{
    /// <summary>
    /// Операции когда ключевое слова в начале
    /// </summary>
    public class FirstValueOperation:IKeyToken
    {
        public string Value { get; set; }
        public string Token { get; set; }

        public FirstValueOperation() 
        {
            
        }

        public FirstValueOperation(string[] value)
        {
            this.Token = value[0];
            this.Value = value[1];
        }

    }
}
