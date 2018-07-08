using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SYLLOGISM.Models;
using SYLLOGISM.Rules;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM
{
    public static class HelperClass
    {        

        #region PUBLICMETHODS

        public static bool IsComplementaryPair(Conclusion c1, Conclusion c2)
        {
           var Type1 = c1.PropositionType;
           var Type2 = c2.PropositionType ;

            //==> 3 Complementarypairs are A-O,I-O and I-E also 
         
            if (Type1 == "A" && Type2 == "O" )
            {
                //==>Check given pair is complematary pair || check complematary pair by converting A type(O cannot be converted)
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair(new Conclusion(c1.ConvertedConclusion), c2));               

            }
            if (Type1 == "I" && Type2 == "O"  )
            {

                //==>Check given pair is complematary pair || check complematary pair by converting I type(O cannot be converted)
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair(new Conclusion(c1.ConvertedConclusion), c2));   
                
            }
            if (Type1 == "I" && Type2 == "E" )
            {
                //==>Check given pair is complematary pair || check complematary pair by converting I type || converting by E type
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair(new Conclusion(c1.ConvertedConclusion), c2) 
                    || CheckIsComplemetaryPair(c1,new Conclusion(c2.ConvertedConclusion))); 
            }

           // check reverse pair also
           if ( Type1 == "O" && Type2 == "A")
            {
                //==>Check given pair is complematary pair || check complematary pair by converting A type(O cannot be converted)
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair( c1,new Conclusion(c2.ConvertedConclusion)));               

            }
            if ( Type1 == "O" && Type2 == "I" )
            {

                //==>Check given pair is complematary pair || check complematary pair by converting I type(O cannot be converted)
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair(c1, new Conclusion(c2.ConvertedConclusion)));   
                
            }
            if (Type1 == "E" && Type2 ==  "I" )
            {
                //==>Check given pair is complematary pair || check complematary pair by converting I type || converting by E type
                return (CheckIsComplemetaryPair(c1, c2) 
                    || CheckIsComplemetaryPair(new Conclusion(c1.ConvertedConclusion), c2) 
                    || CheckIsComplemetaryPair(c1,new Conclusion(c2.ConvertedConclusion))); 
            }
          
            return false;
        }

        #endregion

        #region PRIVATEMETHODS

        private static bool CheckIsComplemetaryPair(Conclusion c1, Conclusion c2)
        {
            return (c1.Subject == c2.Subject && c1.Predicate == c2.Predicate);

        }

      
        #endregion

    }
}
