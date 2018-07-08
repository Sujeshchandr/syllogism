using System.Windows.Forms;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM.Rules
{
    public static class ComplementaryPair
    {
        #region PRIVATECONSTANTS

        private static string Type1 { get; set; }
        private static string Type2 { get; set; }

        private static string Conlusion1Subject { get; set; }
        public static string Conlusion2Subject { get; set; }
        public static string Conlusion3Subject { get; set; }
        public static string Conlusion1Predicate { get; set; }
        public static string Conlusion2Predicate { get; set; }
        public static string Conlusion3Predicate { get; set; }

        #endregion

        #region PUBLICMETHODS

        public static bool IsComplementaryPair(string c1, string c2)
        {
            Type1 = SyllogismRules.GetTypeByProposition(c1);
            Type2 = SyllogismRules.GetTypeByProposition(c2);
            Conlusion1Subject = SyllogismRules.GetStatementByType(Type1);


            if (Type1 == "A" && Type2 == "O")
            {
                //return
                if (CheckAOPair(c1, c2)) return true;
                c1 = AType.ConvertProposition(c1);
                if (CheckIOPair(c1, c2)) return true;
                
            }
            if (Type1 == "I" && Type2 == "O")
            {
                //return
                if (CheckIOPair(c1, c2)) return true;
                c1 = IType.ConvertStatement(c1);
                if (CheckIOPair(c1, c2)) return true;
            }
            if (Type1 == "I" && Type2 == "E")
            {
                if (CheckIEPair(c1, c2)) return true;
                c1 = IType.ConvertStatement(c1);
                if (CheckIEPair(c1, c2)) return true;               
                c1 = IType.ConvertStatement(c1);
                c2 = EType.ConvertStatement(c2);
                return CheckIEPair(c1, c2);
            }
            return false;
        }

        private static bool CheckIEPair(string c1, string c2)
        {
            if (IType.GetSubjectByStatement(c1) == EType.GetSubjectByStatement(c2) &&
                IType.GetPredicateByStatement(c1) == EType.GetPredicateByStatement(c2))
            {
                return true;
            }
            return false;
        }

        private static bool CheckIOPair(string c1, string c2)
        {
            if (IType.GetSubjectByStatement(c1) == OType.GetSubjectByStatement(c2) &&
                IType.GetPredicateByStatement(c1) == OType.GetPredicateByStatement(c2))
            {
                return true;
            }
            return false;
        }

        private static bool CheckAOPair(string c1, string c2)
        {
            if (AType.GetSubjectByProposition(c1) == OType.GetSubjectByStatement(c2) &&
                AType.GetPredicateByProposition(c1) == OType.GetPredicateByStatement(c2))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region PRIVATEMETHODS
        
        private static bool CheckComplemantaryPairAfterConvertion(string c1, string c2)
        {
            return IsComplementaryPair(c1, c2);
        }

        #endregion
    }
}
