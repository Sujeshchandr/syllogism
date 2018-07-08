using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYLLOGISM.Models
{
    public static class Preview
    {

        //Preview is bascially for one conlcusion and StatememntList now
        public static PropositionList Propositions { get; set; }
        public static Conclusion Conclusion { get; set; }
        public static IList<Statement> Statements { get; set; }
        public static IList<Statement> SortedList { get; set; }
        public static IList<Statement> CorrespondingAllignedStatements { get; set; } 
        public static Statement ResultStatement { get; set; }

        public static void PopulatePreviewPropertiesByConclusion(PropositionList pList,Conclusion currentPreviewConclusion)
        {
            Propositions = pList; 
            Statements = pList.StatementList;
            Conclusion = currentPreviewConclusion;
            SortedList = currentPreviewConclusion.sortedStatementList;
            CorrespondingAllignedStatements = currentPreviewConclusion.CorrespondingAlignedStatements;
            ResultStatement = currentPreviewConclusion.ResultStatement;          


        }
    }



}
