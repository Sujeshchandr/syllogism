using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.HiddenTypes
{
    public class HiddenAtype
    {
        #region PRIVATECONSTANTS
        //All positive propositions begining with   EACH,EVERY,ANY	A-TYPE

        private const string EACH = "EACH";
        private const string EVERY = "EVERY";
        private const string ANY = "ANY";
        private const string NOT = "NOT";
        private const string Template1 = "EACH <<STATEMENT>> ARE <<PREDICATE>>";
        private const string Template2 = "EVERY <<STATEMENT>> ARE <<PREDICATE>>";
        private const string Template3 = "ANY <<STATEMENT>> ARE <<PREDICATE>>";
        //private const string STATEMENTVARIABLE = "<<STATEMENT>>";
        // private const string PREDICATETVARIABLE = "<<PREDICATE>>";

        #endregion

        public static string GetPropositionType()
        {
            return "A";
        }

        public static string GetStatementTemplate1()
        {
            return Template1;
        }

        public static string GetStatementTemplate2()
        {
            return Template2;
        }

        public static string GetStatementTemplate3()
        {
            return Template3;
        }

        public static bool IsTrue(string statement)
        {


            if (!String.IsNullOrEmpty(statement.Trim()))
            {
                if (statement.Split(' ')[0].ToUpper() == EACH || statement.Split(' ')[0].ToUpper() == EVERY || statement.Split(' ')[0].ToUpper() == ANY)
                {
                    foreach (var s in statement.Split(' '))
                    {
                        if (s.Trim().ToUpper() == NOT)
                            return false;
                    }
                    return true;
                }

            }
            return false;

        }
    }
}
