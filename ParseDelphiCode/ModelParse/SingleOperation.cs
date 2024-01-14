using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode.ModelParse
{
    /// <summary>
    /// Операции которые не хранят в себе даннные, но необходимы для парсера
    /// </summary>
    public class SingleOperation : IKeyToken
    {
        public string token;
        public SingleOperation() 
        {
            
        }

        public SingleOperation(string tk)
        {
            this.token = tk;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
