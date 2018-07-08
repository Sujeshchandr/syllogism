using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Rules.Types;

namespace SYLLOGISM.Rules
{
    public static class TableRules
    { 
        #region PRIVATECONSTANTS

        private const string CANNOTTALIGN = "COLUD NOT ABLE TO ALIGN";
        private const string VALIDCONCLUSION = "CONCLUSION IS VALID";
        private const string INVALIDCONCLUSION = "CONCLUSION IS NOT VALID";
        private const string NODEFINITECONCLUSION =  "NO DEFINITE CONCLUSION OF <<TYPE1>> AND <<TYPE2>> - TYPE COMBINATION";

       #endregion

        #region PUBLICPROPERTIES

        public static string TYPE1 { get; set; }
        public static string TYPE2 { get; set; }
        public static string RESULTTYPE1 { get; set; }
        public static string STATEMENT1 { get; set; }
        public static string STATEMENT2 { get; set; }
        public static string Statement3 { get; set; }
        public static string Statement1Type { get; set; }
        public static string Statement2Type { get; set; }
        public static string Statement3Type { get; set; }
        public static string Statement1Subject { get; set; }
        public static string Statement2Subject { get; set; }
        public static string Statement3Subject { get; set; }
        public static string Statement1Predicate { get; set; }
        public static string Statement2Predicate { get; set; }
        public static string Statement3Predicate { get; set; }
        public static string Conclusion1 { get; set; }
        public static string Conclusion2 { get; set; }
        public static string Conclusion3 { get; set; }
        public static string Conclusion4 { get; set; }
        
        

        #endregion

        #region PUBLICMETHODS

        public static string AddStatements(string statement1, string statement2)
        {
            TYPE1 = SyllogismRules.GetTypeByProposition(statement1);
            TYPE2 = SyllogismRules.GetTypeByProposition(statement2);
            STATEMENT1 = statement1;
            STATEMENT2 = statement2;
           
            if (TYPE1 == "A" && TYPE2 == "A")
            {

                if (CheckStatementsCanBeAligned(AType.GetSubjectByProposition(STATEMENT1), AType.GetPredicateByProposition(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2), AType.GetPredicateByProposition(STATEMENT2)))
                {
                    if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                    {
                        //return "A";
                        return AType.GetPropositionBySubjectAndPredicate(AType.GetSubjectByProposition(STATEMENT1), AType.GetPredicateByProposition(STATEMENT2));
                    }
                    if (ReArrangingOrder(STATEMENT1,STATEMENT2))
                    {
                        if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                        {
                            //return "A";
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, AType.GetPropositionType(), STATEMENT2, AType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT1, STATEMENT2) : CANNOTTALIGN;
                    }
                }
                else
                {
                    return CANNOTTALIGN;
                }

            }
            else if (TYPE1 == "A" && TYPE2 == "E")
            {


                if (CheckStatementsCanBeAligned(AType.GetSubjectByProposition(STATEMENT1), AType.GetPredicateByProposition(STATEMENT1), EType.GetSubjectByStatement(STATEMENT2), EType.GetPredicateByStatement(STATEMENT2)))
                {
                    if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), EType.GetSubjectByStatement(STATEMENT2)))
                    {
                        //return "E";
                        return EType.GetPropositionBySubjectAndPredicate(AType.GetSubjectByProposition(STATEMENT1), EType.GetPredicateByStatement(STATEMENT2));
                    }
                    else  if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), EType.GetSubjectByStatement(STATEMENT2)))
                        {
                            //return "E";
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, AType.GetPropositionType(), STATEMENT2, EType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT1, STATEMENT2) : CANNOTTALIGN;
                    }
                }
                else
                {
                    return CANNOTTALIGN;
                }

            }
            else if (TYPE1 == "E" && TYPE2 == "A")
            {


                if (CheckStatementsCanBeAligned(EType.GetSubjectByStatement(STATEMENT1), EType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2), AType.GetPredicateByProposition(STATEMENT2)))
                {
                    if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                    {
                        //return "O*";
                        return OType.GetStatementBySubjectAndPredicate(AType.GetPredicateByProposition(STATEMENT2), EType.GetSubjectByStatement(STATEMENT1));
                    }
                    if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                        {
                            //return "O*";
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, EType.GetPropositionType(), STATEMENT2, AType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT2, STATEMENT1) : CANNOTTALIGN;
                    }
                }
                else
                {
                    return CANNOTTALIGN;
                }


            }
            else if (TYPE1 == "E" && TYPE2 == "I")
            {


                if (CheckStatementsCanBeAligned(EType.GetSubjectByStatement(STATEMENT1), EType.GetPredicateByStatement(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2), IType.GetPredicateByStatement(STATEMENT2)))
                {
                    if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2)))
                    {
                        //return "O*";
                        return OType.GetStatementBySubjectAndPredicate(IType.GetPredicateByStatement(STATEMENT2), EType.GetSubjectByStatement(STATEMENT1));
                    }
                    if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2)))
                        {
                            //return "O*";
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, EType.GetPropositionType(), STATEMENT2, IType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT2, STATEMENT1) : CANNOTTALIGN;
                    }
                }
                else
                {
                    return CANNOTTALIGN;
                }


            }
            else if (TYPE1 == "I" && TYPE2 == "A")
            {


                if (CheckStatementsCanBeAligned(IType.GetSubjectByStatement(STATEMENT1), IType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2), AType.GetPredicateByProposition(STATEMENT2)))
                {
                    if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                    {
                       // return "I";                     
                        return IType.GetStatementBySubjectAndPredicate(IType.GetSubjectByStatement(STATEMENT1), AType.GetPredicateByProposition(STATEMENT2));
                    }
                    if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))
                        {
                            // return "I";                     
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, IType.GetPropositionType(), STATEMENT2, AType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT1, STATEMENT2) : CANNOTTALIGN;
                    }
                }
                else
                {
                    return CANNOTTALIGN;
                }


            }
            else if (TYPE1 == "I" && TYPE2 == "E")
            {


                if (CheckStatementsCanBeAligned(IType.GetSubjectByStatement(STATEMENT1), IType.GetPredicateByStatement(STATEMENT1), EType.GetSubjectByStatement(statement2), EType.GetPredicateByStatement(statement2)))
                {
                    if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), EType.GetSubjectByStatement(statement2)))
                    {
                       // return "O";
                        return OType.GetStatementBySubjectAndPredicate(IType.GetSubjectByStatement(STATEMENT1), EType.GetPredicateByStatement(statement2));
                    }
                    if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), EType.GetSubjectByStatement(statement2)))
                        {
                            //return "O";
                            return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);
                        }
                        ReArrangingOrder(STATEMENT1, STATEMENT2);
                        return AlignStatementsByIEARule(STATEMENT1, IType.GetPropositionType(), STATEMENT2, EType.GetPropositionType()) ? AddStatementsAfterAlign(STATEMENT1, STATEMENT2) : CANNOTTALIGN;
                    }
                }
            }
            else if (TYPE1 == "A" && TYPE2 == "I")
            {
                if (CheckStatementsCanBeAligned(AType.GetSubjectByProposition(STATEMENT1), AType.GetPredicateByProposition(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2), IType.GetPredicateByStatement(STATEMENT2)))
                {
                    if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2)))
                    {
                        //return "A";
                        //return AType.GetStatementBySubjectAndPredicate(AType.GetSubjectByStatement(STATEMENT1), AType.GetPredicateByStatement(STATEMENT2));
                    }
                    else if (ReArrangingOrder(STATEMENT1, STATEMENT2))
                    {
                        return AddStatementsAfterAlign(STATEMENT1, STATEMENT2);

                    }


                }
                else
                {
                    return CANNOTTALIGN;
                }
            }
            return NODEFINITECONCLUSION.Replace("<<TYPE1>>", TYPE1)
                                       .Replace("<<TYPE2>>", TYPE2);
        }

        public static string CheckConclusionByStatements(string conclusion, string statement1, string statement2, string result)
        {
            TYPE1 = SyllogismRules.GetTypeByProposition(statement1);
            TYPE2 = SyllogismRules.GetTypeByProposition(statement2);           
            STATEMENT1 = statement1;
            STATEMENT2 = statement2;

            if (TYPE1 == "A" && TYPE2 == "A")
            {
                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }               
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }


            }
            else if (TYPE1 == "A" && TYPE2 == "E")
            {




                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "E" && TYPE2 == "A")
            {



                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }


            }
            else if (TYPE1 == "E" && TYPE2 == "I")
            {



                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "I" && TYPE2 == "A")
            {



                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "I" && TYPE2 == "E")
            {




                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "I" && TYPE2 == "I")
            {


                //if (result.ToUpper() == conclusion.ToUpper())
                //{
                //    result = VALIDCONCLUSION;
                //}

                //else 
                
                if (IType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "A" && TYPE2 == "I")
            {
                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                //TODO convert result and check

                else  if (AType.ConvertProposition(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "A" && TYPE2 == "O")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (AType.ConvertProposition(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (OType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "E" && TYPE2 == "E")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (EType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "E" && TYPE2 == "O")
            {

                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (EType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (OType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "I" && TYPE2 == "O")//may exist complemetarypair
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (IType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (OType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "O" && TYPE2 == "A")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (OType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (AType.ConvertProposition(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "O" && TYPE2 == "E")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (OType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (EType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "O" && TYPE2 == "I")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (OType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (IType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }
            else if (TYPE1 == "O" && TYPE2 == "O")
            {


                if (result.ToUpper() == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }

                else if (OType.ConvertStatement(statement1) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else if (OType.ConvertStatement(statement2) == conclusion.ToUpper())
                {
                    result = VALIDCONCLUSION;
                }
                else
                {
                    result = CheckconclusionByConvertingResult(result, conclusion);
                }

            }

            else
            {
                return NODEFINITECONCLUSION.Replace("<<TYPE1>>", TYPE1)
                                       .Replace("<<TYPE2>>", TYPE2);
            }
            return result;
        }
        public static bool CheckStatementsCanBeAligned(string s1Subject, string s1Predicate, string s2Subject, string s2Predicate)
        {

            Statement1Subject = s1Subject;
            Statement1Predicate = s1Predicate;
            Statement2Subject = s2Subject;
            Statement2Predicate = s2Predicate;

            if (String.Equals(Statement1Subject, Statement2Subject, StringComparison.CurrentCultureIgnoreCase) || String.Equals(Statement1Subject, Statement2Predicate, StringComparison.CurrentCultureIgnoreCase) || String.Equals(Statement1Predicate, Statement2Predicate, StringComparison.CurrentCultureIgnoreCase) || String.Equals(Statement1Predicate, Statement2Subject, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return String.Equals(Statement1Predicate, Statement2Subject, StringComparison.CurrentCultureIgnoreCase) || String.Equals(Statement1Predicate, Statement2Predicate, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion

        #region PRIVATEMETHODS

        private static string CheckconclusionByConvertingResult(string result, string conclusion)
        {
            RESULTTYPE1 = SyllogismRules.GetTypeByProposition(result);
            string tempresult;
            switch (RESULTTYPE1)
            {
                case "A":
                    tempresult = AType.ConvertProposition(result) == conclusion.ToUpper() ? VALIDCONCLUSION : INVALIDCONCLUSION;
                    if (tempresult == INVALIDCONCLUSION)
                    {
                        tempresult = AType.ImplicateProposition(result) == conclusion.ToUpper()
                            ? VALIDCONCLUSION
                            : INVALIDCONCLUSION;
                    }
                    result = tempresult;
                    break;
                case "E":
                    tempresult = EType.ConvertStatement(result) == conclusion.ToUpper() ? VALIDCONCLUSION : INVALIDCONCLUSION;
                    if (tempresult == INVALIDCONCLUSION)
                    {
                        tempresult = EType.ImplicateStatement(result) == conclusion.ToUpper() ? VALIDCONCLUSION : INVALIDCONCLUSION;
                          
                       
                    }
                    result = tempresult;
                    break;
                case "I":
                    tempresult = IType.ConvertStatement(result) == conclusion.ToUpper() ? VALIDCONCLUSION : INVALIDCONCLUSION;
                    if (tempresult == INVALIDCONCLUSION)
                    {
                        tempresult = IType.ImplicateStatement(result) == conclusion.ToUpper()
                            ? VALIDCONCLUSION
                            : INVALIDCONCLUSION;
                       
                    }
                    result = tempresult;
                    break;
                case "O":
                    tempresult = OType.ConvertStatement(result) == conclusion.ToUpper() ? VALIDCONCLUSION : INVALIDCONCLUSION;
                    if (tempresult == INVALIDCONCLUSION)
                    {
                        tempresult = OType.ImplicateStatement(result) == conclusion.ToUpper()
                            ? VALIDCONCLUSION
                            : INVALIDCONCLUSION;
                    }
                    result = tempresult;
                    break;
            }
            return result;

        }

        private static bool ReArrangingOrder(string s1, string s2)
        {

            STATEMENT1 = s1;
            STATEMENT2 = s2;
            var temp = string.Empty;

            temp = STATEMENT1;
            STATEMENT1 = STATEMENT2;
            STATEMENT2 = temp;
            return true;

        }

        public static bool IsAligned(string s1Predicate, string s2Subject)
        {

            Statement1Predicate = s1Predicate;
            Statement2Subject = s2Subject;

            return String.Equals(Statement1Predicate, Statement2Subject, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool AlignStatementsByIEARule(string s1, string s1Type, string s2, string s2Type)
        {

            STATEMENT1 = s1;
            STATEMENT2 = s2;
            TYPE1 = s1Type;
            TYPE2 = s2Type;
            var temp = string.Empty;
            if (TYPE1 == "A" && TYPE2 == "A")
            {
                STATEMENT1 = AType.ConvertProposition(STATEMENT1);
                if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;                    
                //return true;
            }
            if (TYPE1 == "A" && TYPE2 == "E")
            {
                STATEMENT2 = EType.ConvertStatement(STATEMENT2);
                if (IsAligned(AType.GetPredicateByProposition(STATEMENT1), EType.GetSubjectByStatement(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;  
                //return true;
            }
            if (TYPE1 == "E" && TYPE2 == "A")
            {
                STATEMENT1 = EType.ConvertStatement(STATEMENT1);
                if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;  
                //return true;
            }
            if (TYPE1 == "E" && TYPE2 == "I")
            {
                STATEMENT2 = IType.ConvertStatement(STATEMENT2);
                if (IsAligned(EType.GetPredicateByStatement(STATEMENT1), IType.GetSubjectByStatement(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;  
                //return true;
            }
            if (TYPE1 == "I" && TYPE2 == "A")
            {
                STATEMENT1 = IType.ConvertStatement(STATEMENT1);
                if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), AType.GetSubjectByProposition(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;  
                //return true;
            }
            if (TYPE1 == "I" && TYPE2 == "E")
            {
                STATEMENT1 = IType.ConvertStatement(STATEMENT1);
                if (IsAligned(IType.GetPredicateByStatement(STATEMENT1), EType.GetSubjectByStatement(STATEMENT2)))//Recheck after convertion
                {
                    return true;
                }
                temp = STATEMENT1;
                STATEMENT1 = STATEMENT2;
                STATEMENT2 = temp;  
               // return true;
            }
            return false;
        }

        public static string AddStatementsAfterAlign(string s1, string s2)
        {
          var result =  AddStatements(s1, s2);
          return result;
        }

        #endregion

    }
}
