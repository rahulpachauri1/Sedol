using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sedol
{
    public class SedolCommon
    {
        private readonly string inputVal;
        public SedolCommon(string val)
        {
            inputVal = val;
        }

        public bool CheckValidCharacter
        {
            get { return Regex.IsMatch(inputVal, "^[a-zA-Z0-9]*$"); }
        }

        public bool CheckLength
        {
            get { return !String.IsNullOrEmpty(inputVal) && inputVal.Length == 7; }
        }

        public bool CheckUserDefined
        {
            get { return inputVal[0] == '9'; }
        }

        private readonly List<int> weightList = new List<int> { 1, 3, 1, 7, 3, 9 };

        public bool CheckSEDOL
        {
            get
            {
                bool result = false;
                if (CheckLength)
                {
                    char[] chars = inputVal.ToCharArray();
                    int sum = 0;
                    for (int i = 0; i < chars.Length; i++)
                    {
                        int asciiVal = ASCIICode(chars[i]);
                        int weight = 0;
                        if (i < 6)
                        {
                            weight = asciiVal * weightList[i];
                        }
                        sum += weight;
                    }
                    if(inputVal[6] == Convert.ToChar(((10 - (sum % 10)) % 10).ToString()))
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        public static int ASCIICode(char input)
        {
            if (Char.IsLetter(input))
                return Char.ToUpper(input) - 55;
            return input - 48;
        }
    }
}
