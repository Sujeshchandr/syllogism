using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;

namespace SYLLOGISM.Rules.ResultStatus.Rules
{
    public interface IRule<T>
    {
        public SyllogismRules.ConclusionValidity c1validity { get; set; }

        public SyllogismRules.ConclusionValidity c2validity { get; set; }

        public Conclusion c1 { get; set; }

        public Conclusion c2 { get; set; }

        bool IsSatisfied(Conclusion c2, Conclusion c2);
        
    }
}
