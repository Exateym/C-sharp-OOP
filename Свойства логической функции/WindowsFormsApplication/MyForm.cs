using MySpecificLibraries.MyLogicalFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void MyForm_Load(object sender, EventArgs e)
        {

        }

        private void negation_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '¬';
        }

        private void notAnd_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '|';
        }

        private void notOr_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '↓';
        }

        private void conjunction_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '•';
        }

        private void disjunction_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '∨';
        }

        private void exclusiveOr_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '⨁';
        }

        private void implication_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '→';
        }

        private void equivalence_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '~';
        }

        private void openingBracket_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += '(';
        }

        private void closingBracket_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += ')';
        }

        private void letterA_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'a';
        }

        private void letterB_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'b';
        }

        private void letterC_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'c';
        }

        private void letterD_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'd';
        }

        private void letterE_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'e';
        }

        private void letterF_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'f';
        }

        private void letterG_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'g';
        }

        private void letterH_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'h';
        }

        private void letterI_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'i';
        }

        private void letterJ_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'j';
        }

        private void letterK_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'k';
        }

        private void letterL_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'l';
        }

        private void letterM_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'm';
        }

        private void letterN_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'n';
        }

        private void letterO_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'o';
        }

        private void letterP_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'p';
        }

        private void letterQ_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'q';
        }

        private void letterR_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'r';
        }

        private void letterS_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 's';
        }

        private void letterT_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 't';
        }

        private void letterU_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'u';
        }

        private void letterV_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'v';
        }

        private void letterW_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'w';
        }

        private void letterX_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'x';
        }

        private void letterY_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'y';
        }

        private void letterZ_Click(object sender, EventArgs e)
        {
            formulaInputField.Text += 'z';
        }

        private void eraseFromLeft_Click(object sender, EventArgs e)
        {
            if (formulaInputField.Text != string.Empty)
            {
                formulaInputField.Text = formulaInputField.Text.Substring(0, formulaInputField.Text.Length - 1);
            }
        }

        private void clearInput_Click(object sender, EventArgs e)
        {
            formulaInputField.Clear();
        }

        private void submitQuery_Click(object sender, EventArgs e)
        {
            try
            {
                MyLogicalFunction myLogicalFunction = new MyLogicalFunction(formulaInputField.Text);
                truthTableStrings.Clear();
                truthTableStrings.Lines = myLogicalFunction.GetTruthRows();
                stringFieldPDNF.Clear();
                stringFieldPDNF.Text = myLogicalFunction.GetStringPDNF();
                stringFieldPСNF.Clear();
                stringFieldPСNF.Text = myLogicalFunction.GetStringPCNF();
                stringFiledMDNF.Clear();
                stringFiledMDNF.Text = myLogicalFunction.GetStringFirstShortestMDNF();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Обработана исключительная ситуация:\n{exception.Message}");
            }
        }
    }
}
