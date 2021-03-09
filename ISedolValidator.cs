using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedol
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }

}
