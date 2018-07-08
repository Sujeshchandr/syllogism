﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Rules.Types
{
    public static class IType
    {
        #region PRIVATECONSTANTS

        private const string SOME = "SOME";
        private const string NOT = "NOT";
        private const string Template = "SOME <<STATEMENT>> ARE <<PREDICATE>>";
        private const string STATEMENTVARIABLE = "<<STATEMENT>>";
        private const string PREDICATETVARIABLE = "<<PREDICATE>>";
        #endregion

        #region PUBLICMETHODS

        public static string GetPropositionType()
        {
            return "I";
        }
        public static string GetStatementTemplate()
        {
            return Template;
        }
        public static bool IsTrue(string statement)
        {
            //if (!String.IsNullOrEmpty(statement.Trim()))
            //{
            //    return statement.Split(' ')[0].ToUpper() == SOME && !statement.ToUpper().Contains(NOT);
            //}
            if (!String.IsNullOrEmpty(statement.Trim()))
            {
                if (statement.Split(' ')[0].ToUpper() == SOME)
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
        public static string ImplicateStatement(string statement)
        {
            if (IsTrue(statement))
            {
                //Array statementArray = statement.Split(' ').ToArray();
                //int arrayLength = statementArray.Length;
                //var subject = statementArray.GetValue(1);
                //var predicate = statementArray.GetValue(arrayLength - 1);
                //statementArray.SetValue(NOT, arrayLength - 1);//replace predicate with subject               
                //statement = string.Empty;
                //foreach (var item in statementArray)
                //{
                //    statement += item + " ";
                //}
                //statement = statement.Trim();
                //statement += " " + predicate;
                //if (OType.IsTrue(statement))
                //    return statement.ToUpper();  
               return "Cannot be implicated";//I is implicated to O

            }
            return string.Empty;
        }

        public static string ConvertStatement(string statement)
        {
            if (IsTrue(statement))
            {
                Array statementArray = statement.Split(' ').ToArray();
                int arrayLength = statementArray.Length;
                var subject = statementArray.GetValue(1);
                var predicate = statementArray.GetValue(arrayLength - 1);
                statementArray.SetValue(predicate, 1);//replace predicate with subject
                statementArray.SetValue(subject, arrayLength - 1);//replace subject with predicate
                statement = statementArray.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + " "));
                if (IType.IsTrue(statement.Trim()))
                    return statement.Trim().ToUpper();
            }
            return string.Empty;
        }
        public static string GetSubjectByStatement(string statement)
        {
            Array statementArray = statement.Split(' ').ToArray();
            int arrayLength = statementArray.Length;
            var subject = statementArray.GetValue(1);
            //var predicate = statementArray.GetValue(arrayLength - 1);
            return subject.ToString();
        }
        public static string GetPredicateByStatement(string statement)
        {

            Array statementArray = statement.Split(' ').ToArray();
            int arrayLength = statementArray.Length;
            // var subject = statementArray.GetValue(1);
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
