using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM.Rules
{
    public static class SyllogismRules
    {
        #region PRIVATECONSTANTS

        private const string TYPE = "TYPE";
        private const string INVALIDTYPE = "INVALID TYPE";

        #endregion

        public  enum PropositionType
        {
            X =0,//Invalid Type and the Default One
            A = 1,//All S are P
            E = 2,//No S are P
            I = 3,//Some S are P
            O = 4,//Some S are not P
            H = 5//Hidden Type

        }

        public enum ConclusionValidity
        {
            NotChecked =0,
            Valid =1,
            InValid =2
        }
        #region PUBLICMETHODS

        public static string GetTypeByProposition(string proposition)
        {
            if (AType.IsTrue(proposition))
            {
                return AType.GetPropositionType().ToUpper();
            }
            if (EType.IsTrue(proposition))
            {
                return EType.GetPropositionType().ToUpper();

            }
            if (IType.IsTrue(proposition))
            {
                return IType.GetPropositionType().ToUpper();
            }
            if (OType.IsTrue(proposition))
            {
                return OType.GetPropositionType().ToUpper();
            } //TODo:- Add Hidden & Exclusive  Proportion
            return INVALIDTYPE;
        }

        public static string GetStatementByType(string type)
        {
            if (AType.IsTrue(type))
            {
                return AType.GetStatementTemplate();
            }
            if (EType.IsTrue(type))
            {
                return EType.GetStatementTemplate();

            }
            if (IType.IsTrue(type))
            {
                return IType.GetStatementTemplate();
            }
            if (OType.IsTrue(type))
            {
                return OType.GetStatementTemplate();
            }
            return INVALIDTYPE;
        }

        public static string GetSubjectByProposition(string proposition)
        {
            if (AType.IsTrue(proposition))
            {
                return AType.GetSubjectByProposition(proposition);
            }
            if (EType.IsTrue(proposition))
            {
                return EType.GetSubjectByStatement(proposition);

            }
            if (IType.IsTrue(proposition))
            {
                return IType.GetSubjectByStatement(proposition);
            }
            if (OType.IsTrue(proposition))
            {
                return OType.GetSubjectByStatement(proposition);
            }
            return INVALIDTYPE;
        }

        public static string GetPredicateByProposition(string proposition)
        {
            if (AType.IsTrue(proposition))
            {
                return AType.GetPredicateByProposition(proposition);
            }
            if (EType.IsTrue(proposition))
            {
                return EType.GetPredicateByStatement(proposition);

            }
            if (IType.IsTrue(proposition))
            {
                return IType.GetPredicateByStatement(proposition);
            }
            if (OType.IsTrue(proposition))
            {
                return OType.GetPredicateByStatement(proposition);
            }
            return INVALIDTYPE;
        }

        public static string[] GetPairedStatementsByConclusion(string[] statementAStrings, string conclusion)
        {
            // Step 1:Consider a given conclusion

            // Step 2:Note the subject and predicate of given conclusion

            //Step3:Find which of the given statements has this subject and predicate

            string[] sortedstatemets = new string[] {"","",""};

             var s1 = statementAStrings[0];
             var s2 = statementAStrings[1];
             var s3 = statementAStrings[2];

            if (CheckStatementsByConclusion(s1, s2, conclusion))
            {
                sortedstatemets.SetValue(s1, 1);
                sortedstatemets.SetValue(s2, 2);
            }
            else if (CheckStatementsByConclusion(s1, s3, conclusion))
            {
                sortedstatemets.SetValue(s1, 1);
                sortedstatemets.SetValue(s3, 2);
            }
            else if (CheckStatementsByConclusion(s2, s3, conclusion))
            {
                sortedstatemets.SetValue(s2, 1);
                sortedstatemets.SetValue(s3, 2);
            }
            else
            {
                return statementAStrings;//consider all 3 statements
            }
            return sortedstatemets;
        }

        public static string GetImplicatedProposition(string proposition)
        {
            if (AType.IsTrue(proposition))
            {
                return AType.ImplicateProposition(proposition).ToUpper();
            }
            if (EType.IsTrue(proposition))
            {
                return EType.ImplicateStatement(proposition).ToUpper();

            }
            if (IType.IsTrue(proposition))
            {
                return IType.ImplicateStatement(proposition).ToUpper();
            }
            if (OType.IsTrue(proposition))
            {
                return OType.ImplicateStatement(proposition).ToUpper();
            } //TODo:- Add Hidden & Exclusive  Proportion
            return INVALIDTYPE;
        }

        public static string GetConvertedProposition(string statement)
        {
            if (AType.IsTrue(statement))
            {
                return AType.ConvertProposition(statement).ToUpper();
            }
            if (EType.IsTrue(statement))
            {
                return EType.ConvertStatement(statement).ToUpper();

            }
            if (IType.IsTrue(statement))
            {
                return IType.ConvertStatement(statement).ToUpper();
            }
            if (OType.IsTrue(statement))
            {
                return OType.ConvertStatement(statement).ToUpper();
            } //TODo:- Add Hidden & Exclusive  Proportion
            return INVALIDTYPE;
        }

        #endregion

        #region PRIVATEMETHODS


        private static bool CheckStatementsByConclusion(string s1, string s2, string conclusion)
        {
            // Step 2:Note the subject and predicate of given conclusion
            string conclusionSubject = GetSubjectByProposition(conclusion);
            string conclusionPredicate = GetPredicateByProposition(conclusion);

            string s1Subject = GetSubjectByProposition(s1);
            string s1Predicate = GetPredicateByProposition(s1);

            string s2Subject = GetSubjectByProposition(s2);
            string s2Predicate = GetPredicateByProposition(s2);

         if( string.Equals(s1Subject, conclusionSubject) ||
                   string.Equals(s1Predicate, conclusionSubject) && string.Equals(s2Subject, conclusionPredicate) ||
                   string.Equals(s2Predicate, conclusionPredicate))
            {
                if(TableRules.CheckStatementsCanBeAligned(s1Subject, s1Predicate, s2Subject, s2Predicate))
                {
                    return true;
                }
             
            }
            return false;
        }

        #endregion

    }
}
