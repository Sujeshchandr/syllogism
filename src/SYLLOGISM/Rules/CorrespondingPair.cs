using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;
using SYLLOGISM.Rules;
using SYLLOGISM.Rules.Types;
namespace SYLLOGISM.Rules
{
    public class CorrespondingPair
    {

        #region PUBLIC PROPERTIES
        public static IList<Statement> SortedStatementList { get; set; }
        public static IList<Statement> CorrespondingAlignedStatements { get; set; }

        #endregion


        #region PUBLIC METHODS

        public static IList<Statement> GetCorrespondingAlignedStatementsByConclusion(Conclusion conclusion,
            IList<Statement> statementList,out IList<Statement> sortedStatementList )
        {
            sortedStatementList = null;
            IList<Statement> correspondingAlignedList = new List<Statement>();
            var isAllStatementsConsidered = false;
            if (conclusion.Subject == conclusion.Predicate) return null;

            IList<Statement> sortedList = GetSortedStatementsByConclusion(conclusion, statementList);
            
            correspondingAlignedList.Clear();
            switch (sortedList.Count)
            {

                case 1:
                    correspondingAlignedList.Add(sortedList[0]);
                    //===>HERE CORRESPONDING ALIGNEDLIST AND SORTED LIST ARE SAME
                    break;
                case 2:                  
                              
                    if (!IAERule.CheckStatementsCanBeAligned(sortedList[0], sortedList[1]))
                    {
                        isAllStatementsConsidered = true;
                    }
                    else
                    {   
                        correspondingAlignedList.Add(sortedList[0]);
                        correspondingAlignedList.Add(sortedList[1]);
                        
                    }
                  
                    break;
                case 3:
                    //==>Split  statememts into 3 Pairs

                    StatementPair Pair1 = new StatementPair(sortedList[0], sortedList[1]);
                    StatementPair Pair2 = new StatementPair(sortedList[1], sortedList[2]);
                    StatementPair Pair3 = new StatementPair(sortedList[0], sortedList[2]);

                    StatementPair resultPair = GetCorrespondingPairByStatementPairs(Pair1, Pair2, Pair3, conclusion);
                    if (resultPair != null)
                    {
                        correspondingAlignedList.Add(resultPair.Statement1);
                        correspondingAlignedList.Add(resultPair.Statement2);
                    }
                    else
                    {
                        isAllStatementsConsidered = true;
                    }
                    break;
            }


            if (correspondingAlignedList.Count == 0 || isAllStatementsConsidered)
            {
                correspondingAlignedList.Clear();
                correspondingAlignedList.Add(statementList[0]);
                correspondingAlignedList.Add(statementList[1]);
                correspondingAlignedList.Add(statementList[2]);
              
            }

            SortedStatementList =  sortedStatementList = sortedList; //==>Populate sorted list property and return in out paramaeter
            CorrespondingAlignedStatements = correspondingAlignedList;//==>populate corresponding aligned statements from sorted list
           
            return correspondingAlignedList;
        }

        #endregion

        #region PRIVATE METHODS

        private enum PairStatus
        {
            AllAreInvalid = 0,
            AllAreValid = 1,
            FirstPairAloneIsValid = 2,
            SecondPairAloneIsValid = 3,
            ThirdPairAloneIsValid = 4,
            FirstAndSecondPairsAreValid = 5,
            SecondAndThirdPairsAreValid = 6,
            FirstAndThirdPairsAreValid = 7,
            None = -1

        }

        private static bool CheckCorrespondingPairs(Conclusion conclusion, Statement resultConclusion)
        {
            if (conclusion.Subject.ToUpper() == resultConclusion.Subject.ToUpper() &&
                           conclusion.Predicate.ToUpper() == resultConclusion.Predicate.ToUpper())
            {
                return true;


            }
            else if (conclusion.Predicate.ToUpper() == resultConclusion.Subject.ToUpper() &&
                     conclusion.Subject.ToUpper() == resultConclusion.Predicate.ToUpper())
            {
                return true;

            }
            else if (conclusion.Subject.ToUpper() == resultConclusion.Subject.ToUpper() ||
                     conclusion.Subject.ToUpper() == resultConclusion.Predicate.ToUpper())
            {
                return true;
            }
            else if (conclusion.Predicate.ToUpper() == resultConclusion.Subject.ToUpper() ||
                     conclusion.Predicate.ToUpper() == resultConclusion.Predicate.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static IList<Statement> GetSortedStatementsByConclusion(Conclusion conclusion,
            IList<Statement> stetementList)
        {
            IList<Statement> sortedList = new List<Statement>();
            foreach (var statement in stetementList)
            {


                if (conclusion.Subject.ToUpper() == statement.Subject.ToUpper() &&
                    conclusion.Predicate.ToUpper() == statement.Predicate.ToUpper())
                {
                    sortedList.Clear();
                    sortedList.Add(statement);
                    break;

                }
                else if (conclusion.Predicate.ToUpper() == statement.Subject.ToUpper() &&
                         conclusion.Subject.ToUpper() == statement.Predicate.ToUpper())
                {
                    sortedList.Clear();
                    sortedList.Add(statement);
                    break;

                }
                else if (conclusion.Subject.ToUpper() == statement.Subject.ToUpper() ||
                         conclusion.Subject.ToUpper() == statement.Predicate.ToUpper())
                {
                    sortedList.Add(statement);
                }
                else if (conclusion.Predicate.ToUpper() == statement.Subject.ToUpper() ||
                         conclusion.Predicate.ToUpper() == statement.Predicate.ToUpper())
                {
                    sortedList.Add(statement);
                }

            }
            return sortedList;
        }

        private static StatementPair GetCorrespondingPairByStatementPairs(StatementPair pair1, StatementPair pair2, StatementPair pair3, Conclusion conclusion)
        {
            PairStatus status = GetPairResultStatus(pair1, pair2, pair3);

            switch (status)
            {
                case PairStatus.AllAreInvalid://==>All pair results are invalid
                    return null;
                case PairStatus.AllAreValid://==>All pair results are valid

                    if (CheckCorrespondingPairs(conclusion, pair1.ResultStatement))//Checking First Pair
                    {
                        return pair1;
                    }
                    else if (CheckCorrespondingPairs(conclusion, pair2.ResultStatement)) //Checking Second Pair
                    {
                        return pair2;

                    }
                    else if (CheckCorrespondingPairs(conclusion, pair3.ResultStatement)) //Checking Third Pair
                    {
                        return pair3;
                    }
                    return null;
                case PairStatus.FirstPairAloneIsValid://==> pair1 result alone is valid

                    if (CheckCorrespondingPairs(conclusion, pair1.ResultStatement))//Checking First Pair
                    {
                        return pair1;
                    }

                    return null;
                case PairStatus.SecondPairAloneIsValid://==> pair2 result alone is valid

                    if (CheckCorrespondingPairs(conclusion, pair2.ResultStatement)) //Checking Second Pair
                    {
                        return pair2;
                    }

                    return null;
                case PairStatus.ThirdPairAloneIsValid://==> pair3 result alone is valid

                    if (CheckCorrespondingPairs(conclusion, pair3.ResultStatement))//Checking Third Pair
                    {
                        return pair3;
                    }

                    return null;
                case PairStatus.FirstAndSecondPairsAreValid://==> pair1  & pair2 results are valid

                    if (CheckCorrespondingPairs(conclusion, pair1.ResultStatement))//Checking First Pair
                    {
                        return pair1;

                    }
                    else if (CheckCorrespondingPairs(conclusion, pair2.ResultStatement))//Checking Second Pair
                    {
                        return pair2;
                    }
                    return null;
                case PairStatus.SecondAndThirdPairsAreValid://==> pair2  & pair3 results are valid

                    if (CheckCorrespondingPairs(conclusion, pair2.ResultStatement))//Checking Second Pair
                    {
                        return pair2;

                    }
                    else if (CheckCorrespondingPairs(conclusion, pair3.ResultStatement))//Checking Third Pair
                    {
                        return pair3;
                    }
                    return null;
                case PairStatus.FirstAndThirdPairsAreValid://==> pair1  & pair3 results are valid                  
                    if (CheckCorrespondingPairs(conclusion, pair1.ResultStatement))//Checking First Pair
                    {
                        return pair1;

                    }
                    else if (CheckCorrespondingPairs(conclusion, pair3.ResultStatement))//Checking Third Pair
                    {
                        return pair3;
                    }
                    return null;


            }

            return null;
        }

        private static PairStatus GetPairResultStatus(StatementPair p1, StatementPair p2, StatementPair p3)
        {
            var r1 = p1.ResultStatement;
            var r2 = p2.ResultStatement;
            var r3 = p3.ResultStatement;

            if (r1 == null && r2 == null && r3 == null)
            {
                return PairStatus.AllAreInvalid;
            }
            else if (r1 != null && r2 != null && r3 != null)
            {

                return PairStatus.AllAreValid;
            }
            else if (r1 != null && r2 == null && r3 == null)
            {
                return PairStatus.FirstPairAloneIsValid;
            }
            else if (r1 == null && r2 != null && r3 == null)
            {
                return PairStatus.SecondPairAloneIsValid;
            }
            else if (r1 == null && r2 == null && r3 != null)
            {
                return PairStatus.ThirdPairAloneIsValid;

            }
            else if (r1 != null && r2 != null && r3 == null)
            {
                return PairStatus.FirstAndSecondPairsAreValid;

            }
            else if (r1 == null && r2 != null && r3 != null)
            {
                return PairStatus.SecondAndThirdPairsAreValid;

            }
            else if (r1 != null && r2 == null && r3 != null)
            {
                return PairStatus.FirstAndThirdPairsAreValid;

            }

            return PairStatus.None;

        }

        #endregion
    }
}
