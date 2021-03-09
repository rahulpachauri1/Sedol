using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedol 
{
    public class SedolBL : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string inputVal)
        {            
            var sedol = new SedolCommon(inputVal);

            var result = new SedolResult
            {
                InputString = inputVal,
                IsUserDefined = false,
                IsValidSedol = false,
                ValidationDetails = null
            };

            if (!sedol.CheckLength)
            {
                result.ValidationDetails = "Input string was not 7-characters long";
                return result;
            }

            if (!sedol.CheckValidCharacter)
            {
                result.ValidationDetails = "SEDOL contains invalid characters";
                return result;
            }            

            if (sedol.CheckUserDefined)
            {
                result.IsUserDefined = true;
            }                       

            if (sedol.CheckSEDOL)
            {
                result.IsValidSedol = true;
                return result;
            }

            if (!sedol.CheckSEDOL)
            {
                result.ValidationDetails = "Checksum digit does not agree with the rest of the input";
                return result;
            }

            return result;
        }
    }
}
