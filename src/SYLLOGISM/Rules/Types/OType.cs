using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.Types
{
    public static class OType
    {
        #region PRIVATECONSTANTS

        private const string SOME = "SOME";
        private const string NOT = "NOT";
        private const string Template = "SOME <<STATEMENT>> ARE NOT <<PREDICATE>>";
        private const string STATEMENTVARIABLE = "<<STATEMENT>>";
        private const string PREDICATETVARIABLE = "<<PREDICATE>>";
        #endregion

        #region PUBLICMETHODS

        public static string GetPropositionType()
        {
            return "O";
        }
        public static string GetStatementTemplate()
        {
            return Template;
        }
        public static bool IsTrue(string statement)
        {
            var s = statement.Split(' ').ToArray();

            if (!String.IsNullOrEmpty(statement.Trim()))
            {
                return (statement.Split(' ')[0].ToUpper() == SOME && statement.Split(' ')[(s.Length - 2)].ToUpper() == NOT);
                //return statement.Split(' ')[0].ToUpper() == SOME && statement.ToUpper().Contains(NOT);
            }
            //if (!String.IsNullOrEmpty(statement.Trim()))
            //{
            //    if (statement.Split(' ')[0].ToUpper() == SOME)
            //    {
            //        foreach (var s in statement.Split(' '))
            //        {
            //            if (s.Trim().ToUpper() == NOT)
            //                return false;
            //        }
            //        return true;
            //    }

            //}            
            return false;
        }

        public static string ImplicateStatement(string statement)
        {
            return IsTrue(statement) ? "Cannot be implicated" : string.Empty;
        }

        public static string ConvertStatement(string statement)
        {
            return IsTrue(statement) ? "Cannot be Converted" : string.Empty;
        }

        public static string GetSubjectByStatement(string statement)
        {
            Array statementArray = statement.Split(' ').ToArray();
            int arrayLength = statementArray.Length;
            var subject = statementArray.GetValue(1);            
            return subject.ToString();
        }
        public static string GetPredicateByStatement(string statement)
        {

            Array statementArray = statement.Split(' ').ToArray();
            int arrayLength = statementArray.Length;            
            var predicate = statementArray.GetValue(arrayLength - 1);
            return predicate.ToString();
        }
        public static string GetStatementBySubjectAndPredicate(string statement, string predicate)
        {
            return GetStatementTemplate().Replace(STATEMENTVARIABLE, statement.ToUpper()).Replace(PREDICATETVARIABLE, predicate.ToUpper());

        }
        #endregion
    }
}
