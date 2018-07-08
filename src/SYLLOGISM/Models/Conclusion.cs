using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Rules;

namespace SYLLOGISM.Models
{
    public class Conclusion : Proposition
    {
          #region CONSTRUCTOR

       public Conclusion()
       {
           
       }

       public Conclusion(string conclusion)
       {
           ConclusionName = conclusion;
           PopulateAllProperties();
       }
       public Conclusion(string conclusion, IList<Statement> statementList)//=>return conclusion validity by using this constructor
       {
           this.ConclusionName = conclusion;
           PopulateAllProperties();
           IList<Statement> sList = new List<Statement>();
           this.CorrespondingAlignedStatements = CorrespondingPair.GetCorrespondingAlignedStatementsByConclusion(this, statementList, out  sList);
           this.sortedStatementList = sList;

           this.ConclusionValidity = GetConclusionValidity();
       }
       #endregion

       #region PRIVATECONSTANTS

       private const string TYPE = "TYPE";
       private const string INVALIDTYPE = "INVALID TYPE";
       private const string CANNOTBEINVERTED=  "Cannot be implicated";
       private const string CANNOTBEIMPICATED = "Cannot be Converted";

       #endregion

       #region PUBLICPROPERTIES

       public string ConclusionName { get; set; }

       //private bool IsValidProposition { get; set; }

       //private bool IsHiddenProposition { get; set; }

       //private string PropositionType { get; set; }

       public string Subject { get; set; }

       public string Predicate { get; set; }

       public string ImplicatedConclusion { get; set; }

       public string ConvertedConclusion { get; set; }

       public string ConvertedSubject { get; set; }

       public string ConvertedPredicate { get; set; }

       public SyllogismRules.ConclusionValidity ConclusionValidity { get; set; }

       public  IList<Statement> CorrespondingAlignedStatements { get; set; }

       public IList<Statement> sortedStatementList { get; set; }

       public  Statement ResultStatement { get; set; }

     
       #endregion

       #region PUBLICFUNCTIONS

       private string GetConclusionType(string conclusion)
       {
           PropositionType = SyllogismRules.GetTypeByProposition(conclusion);
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
       private string GetImpicatedConclusion(string conclusion)
       {
           ImplicatedConclusion = SyllogismRules.GetImplicatedProposition(conclusion);
           return ImplicatedConclusion;

       }
       private string GetConvertedStatement(string statement){
           ConvertedConclusion = SyllogismRules.GetConvertedProposition(statement);
           ConvertedSubject = SyllogismRules.GetSubjectByProposition(ConvertedConclusion);
           ConvertedPredicate = SyllogismRules.GetPredicateByProposition(ConvertedConclusion);
           return ConvertedConclusion;

       }

       #endregion


       #region PRIVATEFUNCTIONS

       private void PopulateAllProperties()
       {
           if (string.IsNullOrEmpty(ConclusionName))
           {
               IsValidProposition = false;
               IsHiddenProposition = false;
               PropositionType = INVALIDTYPE;
               Subject = string.Empty;
               Predicate = string.Empty;
               ImplicatedConclusion = string.Empty;
               ConvertedConclusion = string.Empty;
               ConvertedSubject = string.Empty;
               ConvertedPredicate = string.Empty;
               ConclusionValidity = SyllogismRules.ConclusionValidity.NotChecked;
           }
           else
           {

               IsHiddenProposition = false;
               GetConclusionType(ConclusionName);
               GetValidProposition(ConclusionName);
               GetSubject(ConclusionName);
               GetPredicate(ConclusionName);
               GetImpicatedConclusion(ConclusionName);
               GetConvertedStatement(ConclusionName);
           }
       }

       private SyllogismRules.ConclusionValidity GetConclusionValidity()
       {
           if (this.CorrespondingAlignedStatements == null || this.CorrespondingAlignedStatements.Count == 0)
           {
             return SyllogismRules.ConclusionValidity.InValid;             

           }
           else if (this.CorrespondingAlignedStatements.Count == 1)
           {
               Statement result = this.CorrespondingAlignedStatements[0];
               this.ResultStatement = result;
               if (result == null)
               {
                   return SyllogismRules.ConclusionValidity.InValid;                   
               }
               if (result.StatementName.ToUpper() == this.ConclusionName.ToUpper())
               {
                  return SyllogismRules.ConclusionValidity.Valid;
               }
               else if (result.ImplicatedStatement.ToUpper() == this.ConclusionName.ToUpper())
               {
                   return SyllogismRules.ConclusionValidity.Valid;
               }
               else if (result.ConvertedStatement.ToUpper() == this.ConclusionName.ToUpper())
               {
                   return SyllogismRules.ConclusionValidity.Valid;
               }
               else
               {
                   return SyllogismRules.ConclusionValidity.InValid;
               }

           }
           else if (this.CorrespondingAlignedStatements.Count == 2)
           {
               Statement result = AddStatemets.Add(this.CorrespondingAlignedStatements[0],
                   this.CorrespondingAlignedStatements[1]);
               this.ResultStatement = result;
               if (result == null)
               {
                   return SyllogismRules.ConclusionValidity.InValid;
                   
               }
               if (result.StatementName.ToUpper() == this.ConclusionName.ToUpper())
               {
                   return SyllogismRules.ConclusionValidity.Valid;
               }
               else if (result.ImplicatedStatement.ToUpper() == this.ConclusionName.ToUpper())
               {
                   return SyllogismRules.ConclusionValidity.Valid;
               }
               else if (result.ConvertedStatement.ToUpper() == this.ConclusionName.ToUpper())
               {
                   return SyllogismRules.ConclusionValidity.Valid;
               }
               else
               {
                   return SyllogismRules.ConclusionValidity.InValid;

               }
           }
           else if (this.CorrespondingAlignedStatements.Count == 3)
           {
               Statement result1 = AddStatemets.Add(this.CorrespondingAlignedStatements[0],
                   this.CorrespondingAlignedStatements[1]);
               this.ResultStatement = result1;
               if (result1 == null)
               {
                   return SyllogismRules.ConclusionValidity.InValid;
               }
               else
               {
                   Statement result2 = AddStatemets.Add(result1,
                       this.CorrespondingAlignedStatements[2]);
                   this.ResultStatement = result2;
                   if (result2 == null)
                   {
                       return SyllogismRules.ConclusionValidity.InValid;
                   }
                   else
                   {
                       if (result2.StatementName.ToUpper() == this.ConclusionName.ToUpper())
                       {
                           return SyllogismRules.ConclusionValidity.Valid;
                       }
                       else if (result2.ImplicatedStatement.ToUpper() == this.ConclusionName.ToUpper())
                       {
                          return SyllogismRules.ConclusionValidity.Valid;
                       }
                       else if (result2.ConvertedStatement.ToUpper() == this.ConclusionName.ToUpper())
                       {
                           return SyllogismRules.ConclusionValidity.Valid;
                       }
                       else
                       {
                           return SyllogismRules.ConclusionValidity.InValid;

                       }
                   }
                   
               }

               
           }
           return SyllogismRules.ConclusionValidity.InValid;

       }

       #endregion

    }
}
