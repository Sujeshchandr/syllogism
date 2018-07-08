using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SYLLOGISM.Rules;

namespace SYLLOGISM.Models
{
   public class ConclusionPair
    {
        public Conclusion Conclusion1
        {
            get;
            set;

        }
        public Conclusion Conclusion2
        {
            get;
            set;

        }
        public bool IsComplemantaryPair
        {
            get;
            set;

        }
      

       //public ConclusionPair()
       //{
           
       //}

       //public ConclusionPair(IList<Conclusion> conclusionPairs)
       //{
       //    Conclusion1 = conclusionPairs[0];
       //    Conclusion2 = conclusionPairs[1];
       //    IsComplemantaryPair = TableRules.CheckStatementsCanBeAligned()
       //}
    }
}
