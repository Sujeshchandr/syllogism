using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllogism.Lite.Entity.Types
{
    /// <summary>
    /// It implies that it refers to that kind of statements, which are universal and giving a negative impression. 
    /// These types of statements begin with No, None of the, Not a single etc
    /// </summary>
    public struct UniversalNegativeType
    {
        public static string GetRepresentationLetter() => "E";

        public static bool IsEquals(string statement)
        {
            //ToDo --> Implement logic to find the given statement is of this type
            return true;
        }
    }
}
