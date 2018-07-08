using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SYLLOGISM.Models;
using SYLLOGISM.Rules.Types;
using SYLLOGISM.Rules;

namespace SYLLOGISM.UserControls
{
    public partial class STEP1Controller : UserControl
    {
        public STEP1Controller()
        {
            InitializeComponent();
        }


        public void LoadAction(Conclusion conclusion)
        {
            lblAction.Text = lblAction.Text.Replace("<<subject>>", conclusion.Subject) 
                            .Replace("<<predicate>>",conclusion.Predicate)
                            .Replace("<<ConclusionName>>", conclusion.ConclusionName);
        }

        public void LoadResult(Conclusion conclusion)
        {

            switch (conclusion.CorrespondingAlignedStatements.Count)
            {
                case 0:
                    lblResult.Text = lblResult.Text.Replace("<<corresponding pairs>>", "are not defined");
                    break;
                case 1:
                    lblResult.Text = lblResult.Text.Replace("<<corresponding pairs>>", conclusion.CorrespondingAlignedStatements[0].StatementName);
                    break;
                case 2:
                    lblResult.Text = lblResult.Text.Replace("<<corresponding pairs>>", conclusion.CorrespondingAlignedStatements[0].StatementName + 
                                                                                       "\n" + conclusion.CorrespondingAlignedStatements[1].StatementName);
                    break;
                case 3:
                    lblResult.Text = lblResult.Text.Replace("<<corresponding pairs>>", conclusion.CorrespondingAlignedStatements[0].StatementName + 
                                                                                      "\n" + conclusion.CorrespondingAlignedStatements[1].StatementName +
                                                                                      "\n" + conclusion.CorrespondingAlignedStatements[2].StatementName);
                    break;


            }
                            

        }
    }
}
