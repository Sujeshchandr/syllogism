using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;

namespace SYLLOGISM.Rules.ResultStatus.Rules
{
   public class EqualRule<T> :IRule<T>
    {
        public SyllogismRules.ConclusionValidity validity { get; set; }
        

        public Conclusion c { get; set; }
        public SyllogismRules.ConclusionValidity c1validity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SyllogismRules.ConclusionValidity c2validity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Conclusion c1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Conclusion c2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsSatisfied(Conclusion c)
        {
            return (c.ConclusionValidity == validity);
        }

        public bool IsSatisfied(Conclusion c1, Conclusion c2)
        {
            throw new NotImplementedException();
        }
    }
}
