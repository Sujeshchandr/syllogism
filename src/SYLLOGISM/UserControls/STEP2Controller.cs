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
    public partial class STEP2Controller : UserControl
    {
        public STEP2Controller()
        {
            InitializeComponent();
        }


        public void LoadAction(Conclusion conclusion)
        {
            lblAction.Text = lblAction.Text.Replace("<<conclusionname>>", conclusion.ConclusionName);
        }

        public void LoadResult(Conclusion conclusion)
        {
            lblResult.Text = lblResult.Text.Replace("<<conclusionname>>", conclusion.ConclusionName)
                                         .Replace("<<VALIDITITY>>", conclusion.ConclusionValidity.ToString());

            if (Preview.CorrespondingAllignedStatements != null)
            {
                switch (Preview.CorrespondingAllignedStatements.Count)
                {
                    case 1:
                        lblResult.Text = lblResult.Text.Replace("<<aligned statements>>", conclusion.CorrespondingAlignedStatements[0].StatementName)
                                                       .Replace("<<Result Statement>>",   conclusion.ResultStatement.StatementName);
                        break;
                    case 2:

                        lblResult.Text = lblResult.Text.Replace("<<aligned statements>>", "\n 1) " + conclusion.CorrespondingAlignedStatements[0].StatementName +
                                                                                          "\n 2) " + conclusion.CorrespondingAlignedStatements[1].StatementName)
                                                       .Replace("<<Result Statement>>", conclusion.ResultStatement.StatementName);

                        break;
                    case 3:
                        lblResult.Text = lblResult.Text.Replace("<<aligned statements>>", "\n 1) " + conclusion.CorrespondingAlignedStatements[0].StatementName +
                                                                                          "\n 2) " + conclusion.CorrespondingAlignedStatements[1].StatementName +
                                                                                          "\n 3) " + conclusion.CorrespondingAlignedStatements[2].StatementName);
                        break;

                    default:
                        lblResult.Text = lblResult.Text.Replace("<<aligned statements>>", "some error occured")
                                                       .Replace("<<Result Statement>>", "no result");
                        break;


                }
            }
                                               
        }

       
    }
}
