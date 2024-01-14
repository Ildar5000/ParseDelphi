using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode
{
    /// <summary>
    /// Класс для Определения ключевого слова
    /// </summary>
    public class TokenOperation
    {
        /// <summary>
        /// Название
        /// </summary>
        public string KeyValue {  get; set; }
        /// <summary>
        /// Тип Операции 2-многострочное 1-однострочное
        /// </summary>
        public int TypeOperation { get; set; }
        /// <summary>
        /// Закрытое
        /// </summary>
        public Stack<String> StringStack { get; set; }

        public string value {  get; set; }

        public TokenOperation(string KeyValue,int TypeOperation) 
        {
            this.KeyValue = KeyValue;
            this.TypeOperation = TypeOperation;
        }

        public TokenOperation(string KeyValue, int TypeOperation,string value)
        {
            this.KeyValue = KeyValue;
            this.TypeOperation = TypeOperation;
            this.value = value;
        }
    }
}
