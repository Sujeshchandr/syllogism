using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;

namespace SYLLOGISM.Rules.ResultStatus.Rules
{
    public interface IRule<T>
    {
        SyllogismRules.ConclusionValidity c1validity { get; set; }

        SyllogismRules.ConclusionValidity c2validity { get; set; }

        Conclusion c1 { get; set; }

        Conclusion c2 { get; set; }

        bool IsSatisfied(Conclusion c1, Conclusion c2);
        
    }
}
