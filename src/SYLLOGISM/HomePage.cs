using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SYLLOGISM.Models;
using SYLLOGISM.Rules.Types;
using SYLLOGISM.Rules;
using SYLLOGISM.UserControls;
using SyllogismResult = SYLLOGISM.Models.PropositionList.SyllogismResult;


namespace SYLLOGISM
{

    public partial class HomePage : Form
    {
        #region PRIVATEVARIABLES
        private int CurrentPageNumber = -1;
        System.Windows.Forms.Timer WinTimer = null;
        STEP1Controller step1Controller = new STEP1Controller();
        STEP2Controller step2Controller = new STEP2Controller();
        private PropositionList pList = null;

        private string _statement1 { get; set; }

        private bool slideshowEnable { get; set; }
        #endregion

        #region PRIVATECONSTANTS

        private const string TYPE = "TYPE";
        private const string INVALIDTYPE = "INVALID TYPE";

        #endregion

        #region PUBLICPROPERTIES

        public string Statement1
        {

            get
            {
                return txtStatement1.Text.ToUpper().Trim('.');
            }
            set { }

        }
        public string Statement2
        {
            get
            {
                return txtStatement2.Text.ToUpper().Trim('.');
            }
            set { }
        }
        public string Statement3
        {
            get
            {
                return txtStatement3.Text.ToUpper().Trim('.');
            }
            set { }
        }
        public string Conclusion1
        {
            get
            {
                return txtConclusion1.Text.ToUpper();
            }
            set { }
        }
        public string Conclusion2
        {
            get
            {
                return txtConclusion2.Text.ToUpper();
            }
            set { }
        }
        public string Conclusion3
        {
            get
            {
                return txtConclusion3.Text.ToUpper();
            }
            set { }
        }
        public string Conclusion4
        {
            get
            {
                return txtConclusion4.Text.ToUpper();
            }
            set { }
        }

        public string Statement1Type { get; set; }
        public string Statement2Type { get; set; }
        public string Statement3Type { get; set; }
        public string Statement1Subject { get; set; }
        public string Statement2Subject { get; set; }
        public string Statement3Subject { get; set; }
        public string Statement1Predicate { get; set; }
        public string Statement2Predicate { get; set; }
        public string Statement3Predicate { get; set; }

        public string Conclusion1Type { get; set; }
        public string Conclusion2Type { get; set; }
        public string Conclusion3Type { get; set; }
        public string Conclusion4Type { get; set; }
        public string Conclusion1Subject { get; set; }
        public string Conclusion2Subject { get; set; }
        public string Conclusion3Subject { get; set; }
        public string Conclusion4Subject { get; set; }
        public string Conclusion1Predicate { get; set; }
        public string Conclusion2Predicate { get; set; }
        public string Conclusion3Predicate { get; set; }
        public string Conclusion4Predicate { get; set; }
        public string Result1 { get; set; }
        public string Result2 { get; set; }
        public string Result3 { get; set; }

        public int TimerInterval { get; set; }

        #endregion

        #region CONSTRUCTOR

        public HomePage()
        {
            InitializeComponent();
        }

        #endregion

        #region CONTROLEVENTS

        private void button1_Click(object sender, EventArgs e)
        {


            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement3 = txtStatement3.Text;

            Conclusion1 = txtConclusion1.Text;
            Conclusion2 = txtConclusion2.Text;
            Conclusion3 = txtConclusion3.Text;
            Conclusion4 = txtConclusion4.Text;


            Result1 = TableRules.AddStatements(Statement1, Statement2);

            Result2 = TableRules.AddStatements(Statement2, Statement3);

            Result3 = TableRules.AddStatements(Statement1, Statement3);

            //Consider Conclusion1 by taking subject and predicate.
            Conclusion1Subject = SyllogismRules.GetSubjectByProposition(Conclusion1);
            Conclusion1Predicate = SyllogismRules.GetPredicateByProposition(Conclusion2);
            if (Conclusion1Subject.ToUpper() != "INVALID TYPE" || Conclusion1Predicate.ToUpper() != "INVALID TYPE")
            {
                // ToD0 :- Check Which of the given statements having this suject and predicate by conclusion.
                string[] allStatements = new string[] { Statement1, Statement2, Statement3 };
                string[] sortedStatements = new string[] { };
                sortedStatements = SyllogismRules.GetPairedStatementsByConclusion(allStatements, Conclusion1);
            }

            if (Conclusion1 != string.Empty && Conclusion2 != string.Empty)
            {

                var r1 = TableRules.CheckConclusionByStatements(Conclusion1, Statement1, Statement2, Result1).ToUpper();

                var r2 = TableRules.CheckConclusionByStatements(Conclusion2, Statement1, Statement2, Result1).ToUpper();

                if (r1.ToUpper() == "CONCLUSION IS VALID" && r2.ToUpper() == "CONCLUSION IS NOT VALID")
                {
                    lblResult.Text = "ONLY CONCLUSION 1 FOLLOWS";
                }
                else if (r1.ToUpper() == "CONCLUSION IS NOT VALID" && r2.ToUpper() == "CONCLUSION IS VALID")
                {
                    lblResult.Text = "ONLY CONCLUSION 2 FOLLOWS";
                }
                else if (r1.ToUpper() == "CONCLUSION IS VALID" && r2.ToUpper() == "CONCLUSION IS VALID")
                {
                    lblResult.Text = "BOTH CONCLUSION 1 AND CONCLUSION 2 FOLLOWS";
                }
                else if (r1.ToUpper() == "CONCLUSION IS NOT VALID" && r2.ToUpper() == "CONCLUSION IS NOT VALID")
                {
                    lblResult.Text = ComplementaryPair.IsComplementaryPair(Conclusion1, Conclusion2)
                        ? "EITHER CONCLUSION 1 OR CONCLUSION 2 FOLLOWS"
                        : "NEITHER CONCLUSION 1 NOR CONCLUSION 2 FOLLOWS";
                }
                else
                {
                    lblResult.Text = "NEITHER CONCLUSION 1 NOR CONCLUSION 2 FOLLOWS";
                }

            }
            else if (Conclusion1 != string.Empty)
            {
                var r1 = TableRules.CheckConclusionByStatements(Conclusion1, Statement1, Statement2, Result1).ToUpper();
                lblResult.Text = r1.ToUpper();
            }
            else if (Conclusion2 != string.Empty)
            {
                var r2 = TableRules.CheckConclusionByStatements(Conclusion2, Statement1, Statement2, Result1).ToUpper();

                lblResult.Text = r2.ToUpper();
            }
            else
            {
                lblResult.Text = Result1;

            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void HomePage_Load(object sender, EventArgs e)
        {
            txtStatement1.Text = "Some oranges are apples.";
            txtStatement2.Text = "All apples are guavas..";
            txtStatement3.Text = "No guavas are bananas...";

            txtConclusion1.Text = "Some guavas are oranges";
            txtConclusion2.Text = "No apples are bananas";
            txtConclusion3.Text = "Some oranges are bananas";
            txtConclusion4.Text = "Some apples are bananas";

            SetTimeInterval(15000);//15 sec
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblResult.Text = GetResult();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement s1 = new Statement(Statement1);
            Statement s2 = new Statement(Statement2);

            StatementPair testPair = new StatementPair(s1, s2);

            if (testPair.ResultStatement != null)
            {
                lblResult.Text = "Aligned Statements are : " + "\n\n" +
                                  "1 ) " + testPair.Statement1.StatementName + "\n" +
                                  "2 ) " + testPair.Statement2.StatementName + "\n\n" +
                                  "Result : " + testPair.ResultStatement.StatementName;
            }
            else
            {
                lblResult.Text = "Aligned Statements are : " + "\n\n" +
                                  "1 ) " + testPair.Statement1.StatementName + "\n" +
                                  "2 ) " + testPair.Statement2.StatementName + "\n\n" +
                                  "Result : No Result of TYPE " + testPair.Statement1.PropositionType + " + " + testPair.Statement2.PropositionType + " !";



            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement3 = txtStatement3.Text;

            Conclusion1 = txtConclusion1.Text;

            Statement s1 = new Statement(Statement1.ToUpper().Trim());
            Statement s2 = new Statement(Statement2.ToUpper().Trim());
            Statement s3 = new Statement(Statement3.ToUpper().Trim());
            IList<Statement> StatementList = new List<Statement> { };

            if (!String.IsNullOrEmpty(Statement1.Trim()))
            {

                StatementList.Add(s1);
            }
            if (!String.IsNullOrEmpty(Statement2.Trim()))
            {

                StatementList.Add(s2);
            }
            if (!String.IsNullOrEmpty(Statement3.Trim()))
            {

                StatementList.Add(s3);
            }

            Conclusion c1 = null;

            if (!String.IsNullOrEmpty(Conclusion1.Trim()))
            {

                c1 = new Conclusion(Conclusion1.ToUpper().Trim(), StatementList);

            }
            IList<Statement> sList = new List<Statement>();
            StatementList = CorrespondingPair.GetCorrespondingAlignedStatementsByConclusion(c1, StatementList, out sList);

            if (StatementList.Count == 1)
            {
                lblResult.Text = "Corresponding Statement is : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n";

            }
            else if (StatementList.Count == 2)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                   "2 ) " + StatementList[1].StatementName.ToUpper() + "\n";


            }
            else if (StatementList.Count == 3)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                  "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                  "2 ) " + StatementList[1].StatementName.ToUpper() + "\n" +
                                  "3 ) " + StatementList[2].StatementName.ToUpper() + "\n";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement3 = txtStatement3.Text;

            Conclusion2 = txtConclusion2.Text;

            Statement s1 = new Statement(Statement1.ToUpper().Trim());
            Statement s2 = new Statement(Statement2.ToUpper().Trim());
            Statement s3 = new Statement(Statement3.ToUpper().Trim());
            IList<Statement> StatementList = new List<Statement> { };

            if (!String.IsNullOrEmpty(Statement1.Trim()))
            {

                StatementList.Add(s1);
            }
            if (!String.IsNullOrEmpty(Statement2.Trim()))
            {

                StatementList.Add(s2);
            }
            if (!String.IsNullOrEmpty(Statement3.Trim()))
            {

                StatementList.Add(s3);
            }

            Conclusion c2 = null;

            if (!String.IsNullOrEmpty(Conclusion2.Trim()))
            {

                c2 = new Conclusion(Conclusion2.ToUpper().Trim(), StatementList);

            }
            IList<Statement> sList = new List<Statement>();
            StatementList = CorrespondingPair.GetCorrespondingAlignedStatementsByConclusion(c2, StatementList, out sList);

            if (StatementList.Count == 1)
            {
                lblResult.Text = "Corresponding Statement is : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n";

            }
            else if (StatementList.Count == 2)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                   "2 ) " + StatementList[1].StatementName.ToUpper() + "\n";


            }
            else if (StatementList.Count == 3)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                  "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                  "2 ) " + StatementList[1].StatementName.ToUpper() + "\n" +
                                  "3 ) " + StatementList[2].StatementName.ToUpper() + "\n";
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement3 = txtStatement3.Text;

            Conclusion3 = txtConclusion3.Text;

            Statement s1 = new Statement(Statement1.ToUpper().Trim());
            Statement s2 = new Statement(Statement2.ToUpper().Trim());
            Statement s3 = new Statement(Statement3.ToUpper().Trim());
            IList<Statement> StatementList = new List<Statement> { };

            if (!String.IsNullOrEmpty(Statement1.Trim()))
            {

                StatementList.Add(s1);
            }
            if (!String.IsNullOrEmpty(Statement2.Trim()))
            {

                StatementList.Add(s2);
            }
            if (!String.IsNullOrEmpty(Statement3.Trim()))
            {

                StatementList.Add(s3);
            }

            Conclusion c3 = null;

            if (!String.IsNullOrEmpty(Conclusion3.Trim()))
            {

                c3 = new Conclusion(Conclusion3.ToUpper().Trim(), StatementList);

            }
            IList<Statement> sList = new List<Statement>();
            StatementList = CorrespondingPair.GetCorrespondingAlignedStatementsByConclusion(c3, StatementList, out sList);

            if (StatementList.Count == 1)
            {
                lblResult.Text = "Corresponding Statement is : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n";

            }
            else if (StatementList.Count == 2)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                   "2 ) " + StatementList[1].StatementName.ToUpper() + "\n";


            }
            else if (StatementList.Count == 3)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                  "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                  "2 ) " + StatementList[1].StatementName.ToUpper() + "\n" +
                                  "3 ) " + StatementList[2].StatementName.ToUpper() + "\n";
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Statement1 = txtStatement1.Text;
            Statement2 = txtStatement2.Text;
            Statement3 = txtStatement3.Text;

            Conclusion4 = txtConclusion4.Text;

            Statement s1 = new Statement(Statement1.ToUpper().Trim());
            Statement s2 = new Statement(Statement2.ToUpper().Trim());
            Statement s3 = new Statement(Statement3.ToUpper().Trim());
            IList<Statement> StatementList = new List<Statement> { };

            if (!String.IsNullOrEmpty(Statement1.Trim()))
            {

                StatementList.Add(s1);
            }
            if (!String.IsNullOrEmpty(Statement2.Trim()))
            {

                StatementList.Add(s2);
            }
            if (!String.IsNullOrEmpty(Statement3.Trim()))
            {

                StatementList.Add(s3);
            }

            Conclusion c4 = null;

            if (!String.IsNullOrEmpty(Conclusion4.Trim()))
            {

                c4 = new Conclusion(Conclusion4.ToUpper().Trim(), StatementList);

            }
            IList<Statement> sList = new List<Statement>();
            StatementList = CorrespondingPair.GetCorrespondingAlignedStatementsByConclusion(c4, StatementList, out sList);

            if (StatementList.Count == 1)
            {
                lblResult.Text = "Corresponding Statement is : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n";

            }
            else if (StatementList.Count == 2)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                   "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                   "2 ) " + StatementList[1].StatementName.ToUpper() + "\n";


            }
            else if (StatementList.Count == 3)
            {
                lblResult.Text = "Corresponding Statements are : " + "\n\n" +
                                  "1 ) " + StatementList[0].StatementName.ToUpper() + "\n" +
                                  "2 ) " + StatementList[1].StatementName.ToUpper() + "\n" +
                                  "3 ) " + StatementList[2].StatementName.ToUpper() + "\n";
            }


        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            StartSlideShow();
        }

        private void StartSlideShow()
        {
            slideshowEnable = true;
            GetResult();
            WinTimer = new System.Windows.Forms.Timer();
            SetTimeInterval(15000);//15 sec
            WinTimer.Interval = GetTimeInterval();
            WinTimer.Tick += new EventHandler(WinTimer_Tick);//bind the tick event of the timer

            WinTimer.Start();
            pnlPreview.Visible = true;
            pnlPreview.BackgroundImage = Properties.Resources.Welcome;
            pnlPreview.BackgroundImageLayout = ImageLayout.Tile;
            CurrentPageNumber = 0;
            pbStep1.Visible = true;
            pbStep2.Visible = true;

        }

        private void StopSlideShow()
        {
            slideshowEnable = false;
            WinTimer.Stop();
            pnlPreview.Visible = false;
            CurrentPageNumber = -1;
            step1Controller.Hide();
            step2Controller.Hide();

        }

        void WinTimer_Tick(object sender, EventArgs e)
        {
            //WinTimerList.Add(string.Format("Tick Generated from {0}", Thread.CurrentThread.Name));
            LOADPREVIEWCOTROLLER();
        }

        private void LOADPREVIEWCOTROLLER()

        {

            switch (CurrentPageNumber)
            {
                case 0:
                    LoadSTEP1PREVIEW();
                    break;

                case 1:
                    LoadSTEP2PREVIEW();
                    break;

                case 2:
                    LoadThankYouPreview();
                    break;

                default:
                    WinTimer.Stop();
                    CurrentPageNumber = -1;
                    break;

            }

        }

        private void LoadSTEP1PREVIEW()
        {
            //STEP1Controller pc = new STEP1Controller();
            pnlPreview.Visible = false;
            step1Controller.Location = pnlPreview.Location;
            step1Controller.Size = pnlPreview.Size;
            step1Controller.LoadAction(Preview.Conclusion);
            step1Controller.LoadResult(Preview.Conclusion);
            this.pnlParent.Controls.Add(step1Controller);
            step1Controller.Show();
            CurrentPageNumber++;
        }

        private void LoadSTEP2PREVIEW()
        {
            step1Controller.Hide();
            step2Controller.Location = pnlPreview.Location;
            step2Controller.Size = pnlPreview.Size;
            step2Controller.LoadAction(Preview.Conclusion);
            step2Controller.LoadResult(Preview.Conclusion);
            this.pnlParent.Controls.Add(step2Controller);
            step2Controller.Show();
            CurrentPageNumber++;
        }

        private void LoadThankYouPreview()
        {
            step2Controller.Hide();
            pnlPreview.Visible = true;
            pnlPreview.BackgroundImage = Properties.Resources.ThankYou;
            pnlPreview.BackgroundImageLayout = ImageLayout.Zoom;
            CurrentPageNumber++;

        }

        private string GetResult()
        {

            Statement s1 = new Statement(Statement1);
            Statement s2 = new Statement(Statement2);
            Statement s3 = new Statement(Statement3);

            label6.Text = s1.PropositionType + " TYPE";
            label9.Text = s2.PropositionType + " TYPE";
            label10.Text = s3.PropositionType + " TYPE";

            IList<Statement> StatementList = new List<Statement> { };

            if (!String.IsNullOrEmpty(Statement1))
            {

                StatementList.Add(s1);
            }
            if (!String.IsNullOrEmpty(Statement2))
            {

                StatementList.Add(s2);
            }
            if (!String.IsNullOrEmpty(Statement3))
            {

                StatementList.Add(s3);
            }

            Conclusion c1 = null;
            Conclusion c2 = null;
            Conclusion c3 = null;
            Conclusion c4 = null;
            IList<Conclusion> ConclusionList = new List<Conclusion> { };
            if (!String.IsNullOrEmpty(Conclusion1))
            {

                c1 = new Conclusion(Conclusion1, StatementList);
                ConclusionList.Add(c1);
            }
            if (!String.IsNullOrEmpty(Conclusion2))
            {
                c2 = new Conclusion(Conclusion2, StatementList);
                ConclusionList.Add(c2);
            }
            if (!String.IsNullOrEmpty(Conclusion3))
            {
                c3 = new Conclusion(Conclusion3, StatementList);
                ConclusionList.Add(c3);
            }
            if (!String.IsNullOrEmpty(Conclusion4))
            {
                c4 = new Conclusion(Conclusion4, StatementList);
                ConclusionList.Add(c4);
            }

            pList = new PropositionList(StatementList, ConclusionList);

            var result = string.Empty;
            int syllogismResult = (int)pList.Result;

            if (pList.ConclusionList.Count > 0)
            {
                Preview.PopulatePreviewPropertiesByConclusion(pList, pList.ConclusionList[0]);//==> conclusion1  preview
            }

            switch (ConclusionList.Count)
            {
                case 1:
                    #region ONECONCLUSION
                    switch (syllogismResult)
                    {
                        case 0:
                            result = "no result";
                            break;
                        case 17:
                            result = "conclusion is valid";
                            break;
                        case 18:
                            result = "conclusion is not valid";
                            break;
                        default:
                            result = "Enter valid conclusions";
                            break;
                    }
                    #endregion
                    break;
                case 2:
                    #region TWOCONCLUSION
                    switch (syllogismResult)
                    {
                        case 0:
                            result = "no result";
                            break;
                        case 1:
                            result = "all are invalid";
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result = "Either c1 or c2 is valid";
                            }
                            break;
                        case 2:
                            result = "all are valid";
                            break;
                        case 3:
                            result = "c1 is valid";
                            break;
                        case 4:
                            result = "c2 is valid";
                            break;
                        default:
                            result = "Enter valid conclusions";
                            break;
                    }
                    #endregion
                    break;
                case 3:
                    #region THREECONCLSUION
                    switch (syllogismResult)
                    {
                        case 0:
                            result = "no result";
                            break;
                        case 1:
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result = "Either c1 or c2 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result = string.IsNullOrEmpty(result) ? "Either c1 or c3 is valid" : result + " And " + "Either c1 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result = string.IsNullOrEmpty(result) ? "Either c2 or c3 is valid" : result + " And " + "Either c2 or c3 is valid";
                            }
                            result = string.IsNullOrEmpty(result) ? "all are invalid" : result;
                            break;
                        case 2:
                            result = "all are valid";
                            break;
                        case 3:
                            result = "c1 is valid";
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result = string.IsNullOrEmpty(result) ? "Either c2 or c3 is valid" : result + " And " + "Either c2 or c3 is valid";
                            }
                            break;
                        case 4:
                            result = "c2 is valid";
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result = string.IsNullOrEmpty(result) ? "Either c1 or c3 is valid" : result + " And " + "Either c1 or c3 is valid";
                            }
                            break;
                        case 5:
                            result = "c3 is valid";
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result = string.IsNullOrEmpty(result) ? "Either c1 or c2 is valid" : result + " And " + "Either c1 or c2 is valid";
                            }
                            break;
                        case 7:
                            result = "c1 c2 are valid";
                            break;
                        case 8:
                            result = "c1 c3 are vaalid";
                            break;
                        case 10:
                            result = "c2 c3 are valid";
                            break;
                        default:
                            result = "Enter valid conclusions";
                            break;
                    }

                    #endregion
                    break;
                case 4:
                    #region FOURCONCLUSION
                    switch (syllogismResult)
                    {
                        case 0:
                            result = "no result";
                            break;
                        case 1:
                            //;
                            //check all complemantary pair of c1,c2,c3,c4 here

                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result = "Either c1 or c2 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result += string.IsNullOrEmpty(result) ? "Either c1 or c3 is valid" : " And " + "Either c1 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[3]))
                            {
                                result += string.IsNullOrEmpty(result) ? "Either c1 or c4 is valid" : " And " + "Either c1 or c4 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result += string.IsNullOrEmpty(result) ? "Either c2 or c3 is valid" : " And " + "Either c2 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[3]))
                            {
                                result += string.IsNullOrEmpty(result) ? "Either c2 or c4 is valid" : " And " + "Either c2 or c4 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[2], ConclusionList[3]))
                            {
                                result += string.IsNullOrEmpty(result) ? "Either c3 or c4 is valid" : " And " + "Either c3 or c4 is valid";
                            }
                            result = string.IsNullOrEmpty(result) ? "all are invalid" : result;
                            break;
                        case 2:
                            result = "all are valid";
                            break;

                        case 3:
                            result = "c1 is valid";
                            //check  complemantary pairof c2,c3 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result += " And " + "Either c2 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[3]))
                            {
                                result += " And " + "Either c2 or c4 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[2], ConclusionList[3]))
                            {
                                result += " And " + "Either c3 or c4 is valid";
                            }
                            break;
                        case 4:
                            result = "c2 is valid";
                            //check  complemantary pairof c1,c3 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result += " And " + "Either c1 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[3]))
                            {
                                result += " And " + "Either c1 or c4 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[2], ConclusionList[3]))
                            {
                                result += " And " + "Either c3 or c4 is valid";
                            }
                            break;
                        case 5:
                            result = "c3 is valid";
                            //check  complemantary pairof c1,c2 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result += " And " + "Either c1 or c2 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[3]))
                            {
                                result += " And " + "Either c2 or c4 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[3]))
                            {
                                result += " And " + "Either c1 or c4 is valid";
                            }
                            break;
                        case 6:
                            result = "c4 is valid";
                            //check  complemantary pairof c1,c2 and c3 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result = " And " + "Either c1 or c2 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result += " And " + "Either c1 or c3 is valid";
                            }
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result += " And " + "Either c2 or c3 is valid";
                            }
                            break;

                        case 7:
                            result = "c1 & c2 is valid";
                            //check  complemantary pairof c3 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[2], ConclusionList[3]))
                            {
                                result += " And " + "Either c3 or c4 is valid";
                            }
                            break;
                        case 8:
                            result = "c1 & c3 is valid";
                            //check  complemantary pairof c2 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[3]))
                            {
                                result += " And " + "Either c2 or c4 is valid";
                            }
                            break;
                        case 9:
                            result = "c1 & c4 is valid";
                            //check  complemantary pairof c2 and c3 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[1], ConclusionList[2]))
                            {
                                result += " And " + "Either c2 or c3 is valid";
                            }
                            break;
                        case 10:
                            result = "c2 & c3 is valid";
                            //check  complemantary pairof c1 and c4 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[3]))
                            {
                                result += " And " + "Either c1 or c4 is valid";
                            }
                            break;
                        case 11:
                            result = "c2 & c4 is valid";
                            //check  complemantary pairof c1 and c3 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[2]))
                            {
                                result += " And " + "Either c1 or c3 is valid";
                            }
                            break;
                        case 12:
                            result = "c3 & c4 is valid";
                            //check  complemantary pairof c1 and c2 here
                            if (HelperClass.IsComplementaryPair(ConclusionList[0], ConclusionList[1]))
                            {
                                result += " And " + "Either c1 or c2 is valid";
                            }
                            break;

                        case 13:
                            result = "c1,c2 & c3 is valid";
                            break;
                        case 14:
                            result = "c1,c2 & c4 is valid";
                            break;
                        case 15:
                            result = "c1,c3 & c4 is valid";
                            break;
                        case 16:
                            result = "c2,c3 & c4 is valid";
                            break;


                        default:
                            result = "Enter valid conclusions";
                            break;


                    }
                    #endregion
                    break;
                default:
                    #region DEFAULT
                    result = "Enter four conclusions";
                    #endregion
                    break;
            }
            return result;
        }

        private void SetTimeInterval(int time)
        {
            TimerInterval = time;
        }

        private int GetTimeInterval()
        {

            return TimerInterval;
        }

        private void pbStep1_Click(object sender, EventArgs e)
        {

            pbStep1.BackColor = Color.Red;
            pbStep2.BackColor = Color.Green;
            WinTimer.Stop();
            step2Controller.Hide();
            LoadSTEP1PREVIEW();
        }

        private void pbStep2_Click(object sender, EventArgs e)
        {
            pbStep2.BackColor = Color.Red;
            pbStep1.BackColor = Color.Green;
            WinTimer.Stop();
            step1Controller.Hide();
            pnlPreview.Visible = false;
            LoadSTEP2PREVIEW();

        }

        private void SetSelectedButtonColor(Control c)
        {
            //TO Do==> set the selected button to a new  color from others 
            //Get buttons ussing tag "PageNumberButtons"
        }

        private void pbSlideShow_Click(object sender, EventArgs e)
        {
            if (slideshowEnable)
            {
                StopSlideShow();
            }
            else
            {
                StartSlideShow();
            }

        }

    }

}

