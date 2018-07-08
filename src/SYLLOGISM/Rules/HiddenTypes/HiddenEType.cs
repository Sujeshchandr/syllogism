using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.HiddenTypes
{
  public  class HiddenEType
  {

      //All negative propositions beginning with 'no one','none','not a single'

      #region PRIVATECONSTANTS
      private const string NO_ONE = "NO ONE";
      private const string NONE = "NONE";
      private const string NOT_A_SINGLE = "NOT A SINGLE";
      private const string Template1 = "NO ONE <<STATEMENT>> ARE NOT <<PREDICATE>>";
      private const string Template2 = "NONE <<STATEMENT>> ARE NOT <<PREDICATE>>";
      private const string Template3 = "NOT A SINGLE <<STATEMENT>> ARE NOT <<PREDICATE>>";
      #endregion

      public static string GetPropositionType()
      {
          return "E";
      }
    }
}
