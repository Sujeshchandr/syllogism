using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.HiddenTypes
{
    public class HiddenIType
    {

       // All positive propositions begining with most,generally,almost,frequently && Negative Propositions beginning with words such as few,seldom,hardly,scarcely,rarely,little	I-TYPE

      #region PRIVATECONSTANTS

            private const string MOST = "MOST";
            private const string GENERALLY = "GENERALLY";
            private const string ALMOST = "ALMOST";
            private const string FREQUENTLY = "FREQUENTLY";
            private const string FEW= "FEW";
            private const string SELDOM = "SELDOM";
            private const string HARDLY = "HARDLY";
            private const string SCARCELY = "SCARCELY";
            private const string RARELY = "RARELY";
            private const string LITTLE = "LITTLE";

            private const string Template1 = "MOST <<STATEMENT>> ARE <<PREDICATE>>";
            private const string Template2 = "GENERALLY <<STATEMENT>> ARE <<PREDICATE>>";
            private const string Template3 = "ALMOST <<STATEMENT>> ARE <<PREDICATE>>";
            private const string Template4 = "FREQUENTLY <<STATEMENT>> ARE <<PREDICATE>>";

            private const string Template5 = "FEW <<STATEMENT>> ARE NOT <<PREDICATE>>";
            private const string Template6 = "SELDOM <<STATEMENT>> ARE NOT <<PREDICATE>>";
            private const string Template7 = "HARDLY <<STATEMENT>> ARE NOT <<PREDICATE>>";
            private const string Template8 = "SCARCELY <<STATEMENT>> ARE NOT <<PREDICATE>>";
            private const string Template9 = "RARELY <<STATEMENT>> ARE NOT <<PREDICATE>>";
            private const string Template10 = "LITTLE <<STATEMENT>> ARE NOT <<PREDICATE>>";

       #endregion

      public static string GetPropositionType()
      {
          return "I";
      }
    }
}
