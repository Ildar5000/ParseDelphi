using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode.ModelParse
{
    public class UsesTokenOperation:MultiValueOperation
    {
        public List<string> UsesUnit { get; set; }

        public UsesTokenOperation(List<string> usesUnit)
        {
            this.UsesUnit = usesUnit;
        }

        private void AddWithoutUses(string[] uses)
        {
            foreach (string use in uses)
            {
                if (!uses.Equals(KeyWords.UsesValue)&&(!string.IsNullOrEmpty(use)))
                {
                    UsesUnit.Add(use.Trim());
                }

            }
        }

        public UsesTokenOperation(string[] uses)
        {
            this.UsesUnit = new List<string>();
            AddWithoutUses(uses);

        }

        public UsesTokenOperation()
        {
            this.UsesUnit = new List<string>();
        }

        public new void Add(string[] uses)
        {
            AddWithoutUses(uses);
        }

    }
}
