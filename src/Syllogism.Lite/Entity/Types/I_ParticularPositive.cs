using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllogism.Lite.Entity.Types
{
    /// <summary>
    /// These type of statements begins with some, any, a few.
    /// </summary>
    public struct ParticularPositiveType
    {
        public static string GetRepresentationLetter() => "I";

        public static bool IsEquals(string statement)
        {
            //ToDo --> Implement logic to find the given statement is of this type
            return true;
        }
    }
}
