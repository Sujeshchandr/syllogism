using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllogism.Lite.Entity.Types
{
    /// <summary>
    /// Universal positive type means something postive applied to all the items in that category
    /// These statements begin with words "ALL", "Every" and "Even"
    /// </summary>
    public struct UniversalPositiveType
    {
        public static string GetRepresentationLetter() => "A";

        public static bool IsEquals(string statement)
        {
            //ToDo --> Implement logic to find the given statement is of this type
            return true;
        }
    }
}
