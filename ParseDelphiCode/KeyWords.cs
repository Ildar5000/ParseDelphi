using ParseDelphiCode.ModelParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode
{
    public static class KeyWords
    {

        public static string EndOperator = ";";

        public static string SingleComment = "//";

        public static string MultiCommentStart = "{";

        public static string MultiCommentEnd = "}";

        public static string UnitValue = "unit";

        public static string EnumeratorValue = ",";
        
        public static string UsesValue = "uses";

        public static string TypesValue = "type";

        public static string ClassValue = "class";
        public static string PublicValue = "public ";
        public static string PrivateValue = "private ";

        public static string DoublePoint = ":";

        public static string EndValue = "end";
        public static string EqualsValue = "=";

        public static int MultiOperation(string symbold)
        {
            if (symbold.Equals(EndOperator))
            {
                return 2;
            }
            return 1;
        }

        public static int EnumeratorOperator(string sumbol)
        {
            if (!sumbol.Equals(EndOperator))
            {
                return 1;
            }
            return 0;
        }
    }
}
