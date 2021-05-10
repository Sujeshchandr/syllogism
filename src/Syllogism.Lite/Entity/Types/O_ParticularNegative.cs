using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllogism.Lite.Entity.Types
{
    public struct ParticularNegativeType
    {
        public static string GetRepresentationLetter() => "O";

        public static bool IsEquals(string statement)
        {
            //ToDo --> Implement logic to find the given statement is of this type
            return true;
        }
    }
}
