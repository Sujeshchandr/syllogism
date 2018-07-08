using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using SYLLOGISM.Rules;

namespace SYLLOGISM.Models
{
    public class StatementPair
    {
        public Statement Statement1
        {
            get; set;
            
        }
        public Statement Statement2
        {
            get;
            set;

        }
        public bool CanBeAligned { get; set; }
        public bool IsAligned { get; set; }
        public bool IsResultValid { get; set; }
        public Statement ResultStatement { get; set; }

        public Statement AlignedStatement1 { get; set; }
        public Statement AlignedStatement2 { get; set; }

        public StatementPair()
        {
            
        }
        public StatementPair(Statement s1,Statement s2)
        {
            Statement1 = s1;
            Statement2 = s2;

            Statement alignedS1 = new Statement();
            Statement alignedS2 = new Statement(); 
  
          
           if (IAERule.AlignStatements(Statement1, Statement2, out alignedS1, out alignedS2))//out variables return aligned statements
           {
               this.IsAligned = true;
               this.CanBeAligned = true;            
               this.Statement1 = new Statement(alignedS1.StatementName);
               this.Statement2 = new Statement(alignedS2.StatementName);              
              
               this.ResultStatement = AddStatemets.Add(Statement1, Statement2);
             
               this.IsResultValid = ResultStatement == null ? false : true;
           }
           else
           {
               this.IsAligned = false;
               this.CanBeAligned = false;
               this.IsResultValid = false;
             
           }
           

        }
    }
}
