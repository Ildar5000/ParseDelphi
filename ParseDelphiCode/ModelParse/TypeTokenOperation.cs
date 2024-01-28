using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDelphiCode.ModelParse
{
    /// <summary>
    /// type
    /// </summary>
    public class TypeTokenOperation:MultiValueOperation
    {
        public string Name {  get; set; }
        public string Parent { get; set; }

        private string TypeGettersNow="private";

        public string Unity
        {
            get
            {
                return Name + "=" + "class(" + Parent + ")";
            }
        }
        public List<Varriors> Varrors { get; set; }
        public List<Varriors> PublicVarrors;
        public List<Varriors> PrivateVarrors;

        public TypeTokenOperation(string[] str) : base(str)
        {
            Varrors = new List<Varriors>();

            if (str.Length > 1)
            {
                if (str[1].Contains("="))
                {
                    string[] s = str[1].Split('=');
                    Name = s[0];
                    Parent = s[1].Replace("class(","").Replace(")","");
                    
                }

                /*
                if (str.Length>3)
                {
                    TokenSeparate(str);
                }
                */
            }

        }

        public void Add(string[] str)
        {
            foreach (string s in str)
            {
                if (!string.IsNullOrEmpty(s))
                {

                    if (s.Contains(KeyWords.PublicValue))
                    {
                        TypeGettersNow = KeyWords.PublicValue;
                        string ss=s.Replace(TypeGettersNow, "");

                        AddValueVarriors(ss);
                    }
                    else
                    {
                        AddValueVarriors(s);
                    }


                }
            }

        }

        private void AddValueVarriors(string s)
        {
            if (s.Contains(KeyWords.DoublePoint))
            {
                string[] dob=s.Split(KeyWords.DoublePoint);
                Varriors varriors = new Varriors(dob, TypeGettersNow);
                Varrors.Add(varriors);
            }
        }
    }

    /// <summary>
    /// Переменные
    /// </summary>
    public class Varriors
    {
        public Varriors(string[] dob,string TypeGettersNow)
        {
            TypeGetters = TypeGettersNow;
            Name = dob[0].Trim();
            TypeVarrioirs = dob[1].Trim();
        }

        public string TypeVarrioirs { get; set; }
        public string Name { get; set; }
        public string TypeGetters {  get; set; }
    }
}
