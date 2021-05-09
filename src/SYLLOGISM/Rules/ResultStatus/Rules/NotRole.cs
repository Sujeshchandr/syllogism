using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;
using SYLLOGISM.Rules.ResultStatus.Rules;

namespace SYLLOGISM.Rules.ResultStatus.Rules
{
    public class NotRole<T> : Rules.IRule<T>
    {
        public SyllogismRules.ConclusionValidity c1validity { get; set; }

        public SyllogismRules.ConclusionValidity c2validity { get; set; }

        public Conclusion c1 { get; set; }

        public Conclusion c2 { get; set; }

        public bool IsSatisfied(Conclusion c1, Conclusion c2)
        {
            return !(c1.ConclusionValidity == c1validity) ;
        }
    }
}
