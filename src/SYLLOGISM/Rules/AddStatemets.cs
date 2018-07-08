using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;
using SYLLOGISM.Rules;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM.Rules
{
   public class AddStatemets
    { 
       
       #region PUBLIC METHODS

        public static Statement Add(Statement statement1, Statement statement2)
        {
            var TYPE1 = statement1.PropositionType;
            var TYPE2 = statement2.PropositionType;
            var STATEMENT1 = statement1.StatementName;
            var STATEMENT2 = statement2.StatementName;
            var result = string.Empty;
            if(!(IAERule.CheckStatementsCanBeAligned(statement1,statement2))) return null;//==>if the statements to be added cannot be aligned then it should retun null [for safety];
            
            if (TYPE1 == "A" && TYPE2 == "A")
            {
                //return "A";

                result =  AType.GetPropositionBySubjectAndPredicate(statement1.Subject,
                  statement2.Predicate);
                return new Statement(result);

            }
            else if (TYPE1 == "A" && TYPE2 == "E")
            {

                //return "E";
                result = EType.GetPropositionBySubjectAndPredicate(statement1.Subject,
                    statement2.Predicate);

                return new Statement(result);

            }
            else if (TYPE1 == "E" && TYPE2 == "A")
            {

                //return "O*";
                result =  OType.GetStatementBySubjectAndPredicate(statement2.Predicate,
                  statement1.Subject);
                return new Statement(result);


            }
            else if (TYPE1 == "E" && TYPE2 == "I")
            {


                //return "O*";
                result = OType.GetStatementBySubjectAndPredicate(statement2.Predicate,
                  statement1.Subject);

                return new Statement(result);

            }
            else if (TYPE1 == "I" && TYPE2 == "A")
            {



                // return "I";                     
                result = IType.GetStatementBySubjectAndPredicate(statement1.Subject,
                  statement2.Predicate);

                return new Statement(result);

            }
            else if (TYPE1 == "I" && TYPE2 == "E")
            {


                // return "O";
                result = OType.GetStatementBySubjectAndPredicate(statement1.Subject,
                  statement2.Predicate);

                return new Statement(result);
            }
            else if (TYPE1 == "A" && TYPE2 == "I")
            {
                return null;
                //Convert "I" + "A";
                // return "I";                     
                //result = IType.GetStatementBySubjectAndPredicate(statement2.Subject,
                 // statement1.Predicate);

              //  return new Statement(result);

                //Had to implement rearranging order
            }

            return null;
        }

        #endregion
    }
}
