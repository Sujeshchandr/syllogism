using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYLLOGISM.Models;
using SYLLOGISM.Rules;

namespace SYLLOGISM.Rules
{
   public class IAERule
    {

       public static bool AlignStatements(Statement s1, Statement s2, out Statement alignedS1, out Statement alignedS2)
       {           

           alignedS1 = new Statement();
           alignedS2 = new Statement();

           var TYPE1 = s1.PropositionType;
           var TYPE2 = s2.PropositionType;


           if (IsAligned(s1, s2, ConvertedStatementOrder.none, out  alignedS1, out alignedS2))
           {
               return true;
           }
           else
           {
               if (CheckStatementsCanBeAligned(s1, s2))
               {          

                   //==>Convert  Statement by IAE Rule                      
                   if (TYPE1 == "A" && TYPE2 == "A") //==>Convert Any Statement(Both ara A so take any) and Check it is Aligned
                   {
                       return (IsAligned(s1, s2, ConvertedStatementOrder.first, out  alignedS1, out alignedS2)
                                || IsAligned(s1, s2, ConvertedStatementOrder.second, out  alignedS1, out alignedS2));//=>Convert Statement1 or Convert Statement2

                   }
                   else if (TYPE1 == "A" && TYPE2 == "E")//==>Convert Second Statement(E type) and Check it is Aligned
                   {

                       return IsAligned(s1, s2, ConvertedStatementOrder.second, out  alignedS1, out alignedS2);

                   }
                   else if (TYPE1 == "A" && TYPE2 == "I")//==>Convert Second Statement(I type) and Check it is Aligned
                   {
                       return IsAligned(s1, s2, ConvertedStatementOrder.second, out  alignedS1, out alignedS2);
                   }

                   else if (TYPE1 == "E" && TYPE2 == "A")//==>Convert First Statement(E type) and Check it is Aligned
                   {
                       return IsAligned(s1, s2, ConvertedStatementOrder.first, out  alignedS1, out alignedS2);  
                   }
                   else if (TYPE1 == "E" && TYPE2 == "I")//=>Convert Second Statement(I type) and Check it is Aligned
                   {
                       return IsAligned(s1, s2, ConvertedStatementOrder.second, out  alignedS1, out alignedS2); 
                   }
                   else if (TYPE1 == "I" && TYPE2 == "E") //==>Convert First Statement(I type) and Check it is Aligned
                   {
                      return  IsAligned(s1, s2, ConvertedStatementOrder.first, out  alignedS1, out alignedS2);  
                   }
                   else if (TYPE1 == "I" && TYPE2 == "A")//Convert First Statement(I type) and Check it is Aligned
                   {
                     return IsAligned(s1, s2, ConvertedStatementOrder.first, out  alignedS1, out alignedS2); 
                   }
                   else
                   {
                       //==>All other pairs with no result                           
                       return false;
                   }
               }
               else
               {   
                   return false;
               }


           }



       }

       private static bool IsAligned( Statement s1,  Statement s2, ConvertedStatementOrder convertedStatementOrder, out Statement aligneds1,out Statement aligneds2)
       {

           if (convertedStatementOrder == ConvertedStatementOrder.none)
           {

               
           }
           else if (convertedStatementOrder == ConvertedStatementOrder.first)//Convert First Statement
           {
               s1 = new Statement(s1.ConvertedStatement);
           }
           else if (convertedStatementOrder == ConvertedStatementOrder.second)//Convert Second Statement
           {
               s2 = new Statement(s2.ConvertedStatement);
           }
           
           string s1Subject = s1.Subject;
           string s1predicate = s1.Predicate;
           string s2Subject = s2.Subject;
           string s2predicate = s2.Predicate;
           if (String.Equals(s1predicate, s2Subject, StringComparison.CurrentCultureIgnoreCase))
           {

               aligneds1 = s1;
               aligneds2 = s2;
               return true;
           }
           else if (String.Equals(s2predicate, s1Subject, StringComparison.CurrentCultureIgnoreCase))
           {
               aligneds1 = s2;
               aligneds2 = s1;
               return true;              

           }
           aligneds1 = s1;
           aligneds2 = s2;
           return false;
       }     

       public static bool CheckStatementsCanBeAligned(Statement s1, Statement s2)
       {       

           if (String.Equals(s1.Subject, s2.Subject, StringComparison.CurrentCultureIgnoreCase))
           {
               return true;
           }
           else if (String.Equals(s1.Predicate, s2.Predicate, StringComparison.CurrentCultureIgnoreCase))
           {
               return true;
           }
           else if (String.Equals(s1.Subject, s2.Predicate, StringComparison.CurrentCultureIgnoreCase))
           {
               return true;
           }

           else if (String.Equals(s1.Predicate, s2.Subject, StringComparison.CurrentCultureIgnoreCase))
           {
               return true;
           }
           else
           {
               return false;
           }

       }      

       private enum ConvertedStatementOrder
       {
           none =0,
           first =1,
           second =2
       }

      
    }
}
