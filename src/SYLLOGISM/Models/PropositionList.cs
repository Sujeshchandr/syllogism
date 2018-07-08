using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Rules.Types;
using SYLLOGISM.Rules;

namespace SYLLOGISM.Models
{
    public class PropositionList 
    {
       public  IList<Statement> StatementList { get; set; }
       public  IList<Conclusion> ConclusionList { get; set; }
       public SyllogismResult Result { get; set; }

       public PropositionList()
       {
           
       }
        public PropositionList(IList<Statement> sList,IList<Conclusion> cList)
        {
           this.StatementList = sList;
           this.ConclusionList = cList;
           this.Result = GetResult(this.ConclusionList);
        }

        private SyllogismResult GetResult(IList<Conclusion> cList)
        {
            Conclusion c1 = null;
            Conclusion c2 = null;
            Conclusion c3 = null;
            Conclusion c4 = null;

            var result = SyllogismResult.NORESULT;
            switch (cList.Count)
            {
               
                case 1:
                    #region ONECONCLUSION 
                    
                    c1 = cList[0];

                    if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.CONCLSUIONISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.CONCLSUIONISNOTVALID;

                    }
                    else
                    {
                        result = SyllogismResult.NORESULT;
                    }  
                    
                    #endregion
                    break;  
                case 2:
                    #region TWOCONCLUSION 
                    c1 = cList[0];
                    c2 = cList[1];
                    if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.ALLAREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C2ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.ALLAREINVALID;
                    }
                    else
                    {
                        result = SyllogismResult.NORESULT;

                    }
  #endregion
                    break;
                case 3:
                    #region THREECONCLUSION
                    c1 = cList[0];
                    c2 = cList[1];
                    c3 = cList[2];
                    if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                           && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                           && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.ALLAREINVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                          && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                          && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.ALLAREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                          && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                          && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                          && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                          && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C2ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                          && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                          && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C3ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                           && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                           && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1C2AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                            && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                            && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C1C3AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C2C3AREVALID;
                    }
                    else
                    {
                        result = SyllogismResult.NORESULT;

                    }
#endregion
                    break;
                case 4:
                    #region FOURCONCLUSION
                    c1 = cList[0];
                    c2 = cList[1];
                    c3 = cList[2];
                    c4 = cList[3];

                    if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                           && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                           && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                           && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.ALLAREINVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                      && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                      && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                      && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.ALLAREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1C2C3AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C1C2C4AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C1C3C4AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C2C3C4AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1ISVALID;

                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C2ISVALID;

                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C3ISVALID;

                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C4ISVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1C2AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C1C3AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C1C4AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid)
                    {
                        result = SyllogismResult.C2C3AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C2C4AREVALID;
                    }
                    else if (c1.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c2.ConclusionValidity == SyllogismRules.ConclusionValidity.InValid
                             && c3.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid
                             && c4.ConclusionValidity == SyllogismRules.ConclusionValidity.Valid)
                    {
                        result = SyllogismResult.C3C4AREVALID;
                    }
                    else
                    {
                        result = SyllogismResult.NORESULT;
                    }

#endregion
                    break;
                default:
                    result = SyllogismResult.NORESULT;
                    break;

            }
            return result;
        }

        public enum SyllogismResult 
        {
            NORESULT =0,
            ALLAREINVALID =1,
            ALLAREVALID =2,

            C1ISVALID = 3,
            C2ISVALID = 4,
            C3ISVALID = 5,
            C4ISVALID = 6,
            
            C1C2AREVALID=7,
            C1C3AREVALID =8,
            C1C4AREVALID =9,
            C2C3AREVALID =10,
            C2C4AREVALID =11,
            C3C4AREVALID =12,

            C1C2C3AREVALID=13,
            C1C2C4AREVALID =14,
            C1C3C4AREVALID =15,
            C2C3C4AREVALID =16,

            CONCLSUIONISVALID =17,
            CONCLSUIONISNOTVALID =18

        }


    }
}
