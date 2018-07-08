using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;

namespace SYLLOGISM.Rules.ResultStatus.Rules
{
   public class EqualRule :IRule
    {
        public SyllogismRules.ConclusionValidity validity { get; set; }
        

        public Conclusion c { get; set; }       

        public bool IsSatisfied(Conclusion c)
        {
            return (c.ConclusionValidity == validity);
        }
    }
}
