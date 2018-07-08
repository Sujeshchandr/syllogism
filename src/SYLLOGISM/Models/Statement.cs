using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SYLLOGISM.Rules;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM.Models
{
    public class Statement : Proposition
   {  
       
       #region CONSTRUCTOR

       public Statement()
       {
           
       }

       public Statement(string statement)
       {
           StatementName = statement;
           PopulateAllProperties();
       }

       #endregion

       #region PRIVATECONSTANTS

       private const string TYPE = "TYPE";
       private const string INVALIDTYPE = "INVALID TYPE";
       private const string CANNOTBEINVERTED=  "Cannot be implicated";
       private const string CANNOTBEIMPICATED = "Cannot be Converted";

       #endregion

       #region PRIVATEPROPERTIES

       public string StatementName { get; set; }

       //private bool IsValidProposition { get; set; }

       //private bool IsHiddenProposition { get; set; }

       //private string StatementType { get; set; }

       public string Subject { get; set; }

       public string Predicate { get; set; }

       public string ImplicatedStatement { get; set; }

       public string ConvertedStatement { get; set; }

       public string ConvertedSubject { get; set; }

       public string ConvertedPredicate { get; set; }
     
       #endregion

       #region PUBLICFUNCTIONS

       private string GetStatementType(string statement)
       {
           PropositionType = SyllogismRules.GetTypeByProposition(statement);
           return PropositionType;

       }
       private string GetValidProposition(string statement)
       {
           //StatementType = SyllogismRules.GetTypeByStatement(statement);
           IsValidProposition = (PropositionType != INVALIDTYPE);// if the statement is not any of the four given type ,then not a valid proportion.
           return PropositionType;

       }
       private string GetSubject(string statement)
       {
           Subject = SyllogismRules.GetSubjectByProposition(statement).ToUpper();
           return Subject;

       }
       private string GetPredicate(string statement)
       {
           Predicate = SyllogismRules.GetPredicateByProposition(statement);
           return Predicate;

       }
       private string GetImpicatedStatement(string statement)
       {
           ImplicatedStatement = SyllogismRules.GetImplicatedProposition(statement);
           return ImplicatedStatement;

       }
       private string GetConvertedStatement(string statement){
           ConvertedStatement = SyllogismRules.GetConvertedProposition(statement);
           ConvertedSubject = SyllogismRules.GetSubjectByProposition(ConvertedStatement);
           ConvertedPredicate = SyllogismRules.GetPredicateByProposition(ConvertedStatement);
           return ConvertedStatement;

       }
      

       #endregion


       #region PRIVATEFUNCTIONS

       private void PopulateAllProperties()
       {
           if (string.IsNullOrEmpty(StatementName))
           {
               IsValidProposition = false;
               IsHiddenProposition = false;
               PropositionType = INVALIDTYPE;
               Subject = string.Empty;
               Predicate = string.Empty;
               ImplicatedStatement = string.Empty;
               ConvertedStatement = string.Empty;
               ConvertedSubject = string.Empty;
               ConvertedPredicate = string.Empty;
           }
           else
           {

               IsHiddenProposition = false;
               GetStatementType(StatementName);
               GetValidProposition(StatementName);
               GetSubject(StatementName);
               GetPredicate(StatementName);
               GetImpicatedStatement(StatementName);
               GetConvertedStatement(StatementName);
           }
       }
       #endregion

   }
}
