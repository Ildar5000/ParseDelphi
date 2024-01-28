using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode.ModelParse
{
    public static class MultiOperationFactory
    {

        public static string QuestionEndValue(IKeyToken keyToken)
        {
            Type myType = keyToken.GetType();
            if (myType.Name == "TypeTokenOperation")
            {
                return KeyWords.EndValue;
            }

            return KeyWords.EndOperator;
        }

        public static void AddValue(IKeyToken keyToken,string[] value)
        {
            if (keyToken == null)
                throw new ArgumentNullException(nameof(keyToken));

            Type myType = keyToken.GetType();

            if (myType.Name== "UsesTokenOperation")
            {
                UsesTokenOperation usesTokenOperation = (UsesTokenOperation)keyToken;
                usesTokenOperation.Add(value);

            }

            if (myType.Name== "TypeTokenOperation")
            {
                TypeTokenOperation usesTokenOperation = (TypeTokenOperation)keyToken;
                usesTokenOperation.Add(value);
            }


        }

        internal static void AddValueAndEnd(IKeyToken keyToken, string[] value)
        {
            if (keyToken == null)
                throw new ArgumentNullException(nameof(keyToken));

            Type myType = keyToken.GetType();
            if (myType.Name == "UsesTokenOperation")
            {
                UsesTokenOperation usesTokenOperation = (UsesTokenOperation)keyToken;
                usesTokenOperation.Add(value);

            }

        }
    }
}
