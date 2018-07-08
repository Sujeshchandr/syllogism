using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SYLLOGISM.Rules.Types
{
    public static class AType
    {
        #region PRIVATECONSTANTS
        private const string ALL = "ALL";
        private const string NOT = "NOT";
        private const string SOME = "SOME";
        private const string Template = "ALL <<STATEMENT>> ARE <<PREDICATE>>";
        private const string STATEMENTVARIABLE = "<<STATEMENT>>";
        private const string PREDICATETVARIABLE = "<<PREDICATE>>";
        #endregion

        #region PUBLICMETHODS

        public  static string GetPropositionType()
        {
            return "A";
        }

        public  static string GetStatementTemplate()
        {
            return Template;
        }

        public static bool IsTrue(string statement)
        {         
             
          
            if (!String.IsNullOrEmpty(statement.Trim()))
            {
                if (statement.Split(' ')[0].ToUpper() == ALL)
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

        public static string ImplicateProposition(string proposition)
        {
            if (IsTrue(proposition))
            {              
                proposition = proposition.ToUpper().Replace(ALL, SOME);
                return proposition;

            }
            return string.Empty;
        }

        public static string ConvertProposition(string proposition)
        {
            if (IsTrue(proposition))
            {
                proposition = ImplicateProposition(proposition);
                Array statementArray = proposition.Split(' ').ToArray();
                int arrayLength = statementArray.Length;
                var subject = statementArray.GetValue(1);
                var predicate = statementArray.GetValue(arrayLength - 1);
                statementArray.SetValue(predicate, 1);//replace predicate with subject
                statementArray.SetValue(subject, arrayLength - 1);//replace subject with predicate

                proposition= statementArray.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + " "));
                //foreach (var item in statementArray)
                //{
                //    statement += item + " ";
                //}

                if (IType.IsTrue(proposition.Trim()))
                    return proposition.Trim();
            }
            return string.Empty;
        }

        public static string GetSubjectByProposition(string proposition)
        {
            Array statementArray = proposition.Split(' ').ToArray();
            //int arrayLength = statementArray.Length;
            var subject = statementArray.GetValue(1);
            //var predicate = statementArray.GetValue(arrayLength - 1);
            return subject.ToString();
        }

        public static string GetPredicateByProposition(string proposition)
        {

            Array statementArray = proposition.Split(' ').ToArray();
            int arrayLength = statementArray.Length;
           // var subject = statementArray.GetValue(1);
            var predicate = statementArray.GetValue(arrayLength - 1);
            return predicate.ToString();
        }

        public static string GetPropositionBySubjectAndPredicate(string statement, string predicate)
        {
            return GetStatementTemplate().Replace(STATEMENTVARIABLE, statement.ToUpper()).Replace(PREDICATETVARIABLE, predicate.ToUpper());
            
        }

        #endregion
    }
}
