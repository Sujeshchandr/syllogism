using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.HiddenTypes
{
    public class HiddenOType
    { 
        //All negative propositions begining with  EACH ,EVERY,ANY  and  ALL	O-TYPE
        #region PRIVATECONSTANTS

        private const string EACH = "EACH";
        private const string EVERY = "EVERY";
        private const string ANY = "ANY";
        private const string ALL = "ALL";

        private const string Template1 = "EACH <<STATEMENT>> ARE NOT <<PREDICATE>>";
        private const string Template2 = "EVERY <<STATEMENT>> ARE NOT <<PREDICATE>>";
        private const string Template3 = "ANY <<STATEMENT>> ARE NOT <<PREDICATE>>";
        private const string Template4 = "ALL <<STATEMENT>> ARE NOT <<PREDICATE>>";

        #endregion

        public static string GetPropositionType()
        {
            return "O";
        }
    }
}
