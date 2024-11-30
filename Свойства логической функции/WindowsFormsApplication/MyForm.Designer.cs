namespace WindowsFormsApplication
{
    partial class MyForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.negation = new System.Windows.Forms.Button();
            this.formulaInputField = new System.Windows.Forms.TextBox();
            this.notAnd = new System.Windows.Forms.Button();
            this.notOr = new System.Windows.Forms.Button();
            this.conjunction = new System.Windows.Forms.Button();
            this.disjunction = new System.Windows.Forms.Button();
            this.exclusiveOr = new System.Windows.Forms.Button();
            this.implication = new System.Windows.Forms.Button();
            this.equivalence = new System.Windows.Forms.Button();
            this.openingBracketButton = new System.Windows.Forms.Button();
            this.closingBracketButton = new System.Windows.Forms.Button();
            this.logicalOperators = new System.Windows.Forms.GroupBox();
            this.brackets = new System.Windows.Forms.GroupBox();
            this.letterA = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.letterZ = new System.Windows.Forms.Button();
            this.letterY = new System.Windows.Forms.Button();
            this.letterX = new System.Windows.Forms.Button();
            this.letterW = new System.Windows.Forms.Button();
            this.letterV = new System.Windows.Forms.Button();
            this.letterU = new System.Windows.Forms.Button();
            this.letterT = new System.Windows.Forms.Button();
            this.letterS = new System.Windows.Forms.Button();
            this.letterR = new System.Windows.Forms.Button();
            this.letterQ = new System.Windows.Forms.Button();
            this.letterP = new System.Windows.Forms.Button();
            this.letterO = new System.Windows.Forms.Button();
            this.letterN = new System.Windows.Forms.Button();
            this.letterM = new System.Windows.Forms.Button();
            this.letterL = new System.Windows.Forms.Button();
            this.letterK = new System.Windows.Forms.Button();
            this.letterJ = new System.Windows.Forms.Button();
            this.letterI = new System.Windows.Forms.Button();
            this.letterH = new System.Windows.Forms.Button();
            this.letterG = new System.Windows.Forms.Button();
            this.letterF = new System.Windows.Forms.Button();
            this.letterE = new System.Windows.Forms.Button();
            this.letterD = new System.Windows.Forms.Button();
            this.letterC = new System.Windows.Forms.Button();
            this.letterB = new System.Windows.Forms.Button();
            this.eraseFromLeft = new System.Windows.Forms.Button();
            this.clearInput = new System.Windows.Forms.Button();
            this.submitQuery = new System.Windows.Forms.Button();
            this.logicFunctionArea = new System.Windows.Forms.GroupBox();
            this.truthTableBox = new System.Windows.Forms.GroupBox();
            this.truthTableStrings = new System.Windows.Forms.TextBox();
            this.boxPDNF = new System.Windows.Forms.GroupBox();
            this.stringFieldPDNF = new System.Windows.Forms.TextBox();
            this.boxPСNF = new System.Windows.Forms.GroupBox();
            this.stringFieldPСNF = new System.Windows.Forms.TextBox();
            this.boxMDNF = new System.Windows.Forms.GroupBox();
            this.stringFiledMDNF = new System.Windows.Forms.TextBox();
            this.logicalOperators.SuspendLayout();
            this.brackets.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.logicFunctionArea.SuspendLayout();
            this.truthTableBox.SuspendLayout();
            this.boxPDNF.SuspendLayout();
            this.boxPСNF.SuspendLayout();
            this.boxMDNF.SuspendLayout();
            this.SuspendLayout();
            // 
            // negation
            // 
            this.negation.BackColor = System.Drawing.Color.SlateGray;
            this.negation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.negation.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.negation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.negation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.negation.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.negation.ForeColor = System.Drawing.Color.Black;
            this.negation.Location = new System.Drawing.Point(6, 30);
            this.negation.Name = "negation";
            this.negation.Size = new System.Drawing.Size(64, 64);
            this.negation.TabIndex = 1;
            this.negation.Text = "¬";
            this.negation.UseVisualStyleBackColor = false;
            this.negation.Click += new System.EventHandler(this.negation_Click);
            // 
            // formulaInputField
            // 
            this.formulaInputField.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formulaInputField.Location = new System.Drawing.Point(6, 43);
            this.formulaInputField.Name = "formulaInputField";
            this.formulaInputField.Size = new System.Drawing.Size(496, 40);
            this.formulaInputField.TabIndex = 0;
            // 
            // notAnd
            // 
            this.notAnd.BackColor = System.Drawing.Color.SlateGray;
            this.notAnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notAnd.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.notAnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.notAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notAnd.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notAnd.ForeColor = System.Drawing.Color.Black;
            this.notAnd.Location = new System.Drawing.Point(76, 30);
            this.notAnd.Name = "notAnd";
            this.notAnd.Size = new System.Drawing.Size(64, 64);
            this.notAnd.TabIndex = 2;
            this.notAnd.Text = "|";
            this.notAnd.UseVisualStyleBackColor = false;
            this.notAnd.Click += new System.EventHandler(this.notAnd_Click);
            // 
            // notOr
            // 
            this.notOr.BackColor = System.Drawing.Color.SlateGray;
            this.notOr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notOr.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.notOr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.notOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notOr.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notOr.ForeColor = System.Drawing.Color.Black;
            this.notOr.Location = new System.Drawing.Point(146, 30);
            this.notOr.Name = "notOr";
            this.notOr.Size = new System.Drawing.Size(64, 64);
            this.notOr.TabIndex = 3;
            this.notOr.Text = "↓";
            this.notOr.UseVisualStyleBackColor = false;
            this.notOr.Click += new System.EventHandler(this.notOr_Click);
            // 
            // conjunction
            // 
            this.conjunction.BackColor = System.Drawing.Color.SlateGray;
            this.conjunction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.conjunction.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.conjunction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.conjunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conjunction.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conjunction.ForeColor = System.Drawing.Color.Black;
            this.conjunction.Location = new System.Drawing.Point(216, 30);
            this.conjunction.Name = "conjunction";
            this.conjunction.Size = new System.Drawing.Size(64, 64);
            this.conjunction.TabIndex = 4;
            this.conjunction.Text = "•";
            this.conjunction.UseVisualStyleBackColor = false;
            this.conjunction.Click += new System.EventHandler(this.conjunction_Click);
            // 
            // disjunction
            // 
            this.disjunction.BackColor = System.Drawing.Color.SlateGray;
            this.disjunction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disjunction.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.disjunction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.disjunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disjunction.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disjunction.ForeColor = System.Drawing.Color.Black;
            this.disjunction.Location = new System.Drawing.Point(286, 30);
            this.disjunction.Name = "disjunction";
            this.disjunction.Size = new System.Drawing.Size(64, 64);
            this.disjunction.TabIndex = 5;
            this.disjunction.Text = "∨";
            this.disjunction.UseVisualStyleBackColor = false;
            this.disjunction.Click += new System.EventHandler(this.disjunction_Click);
            // 
            // exclusiveOr
            // 
            this.exclusiveOr.BackColor = System.Drawing.Color.SlateGray;
            this.exclusiveOr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exclusiveOr.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.exclusiveOr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.exclusiveOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exclusiveOr.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exclusiveOr.ForeColor = System.Drawing.Color.Black;
            this.exclusiveOr.Location = new System.Drawing.Point(356, 30);
            this.exclusiveOr.Name = "exclusiveOr";
            this.exclusiveOr.Size = new System.Drawing.Size(64, 64);
            this.exclusiveOr.TabIndex = 6;
            this.exclusiveOr.Text = "⨁";
            this.exclusiveOr.UseVisualStyleBackColor = false;
            this.exclusiveOr.Click += new System.EventHandler(this.exclusiveOr_Click);
            // 
            // implication
            // 
            this.implication.BackColor = System.Drawing.Color.SlateGray;
            this.implication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.implication.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.implication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.implication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.implication.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.implication.ForeColor = System.Drawing.Color.Black;
            this.implication.Location = new System.Drawing.Point(426, 30);
            this.implication.Name = "implication";
            this.implication.Size = new System.Drawing.Size(64, 64);
            this.implication.TabIndex = 7;
            this.implication.Text = "→";
            this.implication.UseVisualStyleBackColor = false;
            this.implication.Click += new System.EventHandler(this.implication_Click);
            // 
            // equivalence
            // 
            this.equivalence.BackColor = System.Drawing.Color.SlateGray;
            this.equivalence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equivalence.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.equivalence.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.equivalence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.equivalence.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equivalence.ForeColor = System.Drawing.Color.Black;
            this.equivalence.Location = new System.Drawing.Point(496, 30);
            this.equivalence.Name = "equivalence";
            this.equivalence.Size = new System.Drawing.Size(64, 64);
            this.equivalence.TabIndex = 8;
            this.equivalence.Text = "~";
            this.equivalence.UseVisualStyleBackColor = false;
            this.equivalence.Click += new System.EventHandler(this.equivalence_Click);
            // 
            // openingBracketButton
            // 
            this.openingBracketButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.openingBracketButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openingBracketButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.openingBracketButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.openingBracketButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openingBracketButton.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openingBracketButton.ForeColor = System.Drawing.Color.Black;
            this.openingBracketButton.Location = new System.Drawing.Point(6, 30);
            this.openingBracketButton.Name = "openingBracketButton";
            this.openingBracketButton.Size = new System.Drawing.Size(64, 64);
            this.openingBracketButton.TabIndex = 9;
            this.openingBracketButton.Text = "(";
            this.openingBracketButton.UseVisualStyleBackColor = false;
            this.openingBracketButton.Click += new System.EventHandler(this.openingBracket_Click);
            // 
            // closingBracketButton
            // 
            this.closingBracketButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.closingBracketButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closingBracketButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.closingBracketButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.closingBracketButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closingBracketButton.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closingBracketButton.ForeColor = System.Drawing.Color.Black;
            this.closingBracketButton.Location = new System.Drawing.Point(76, 30);
            this.closingBracketButton.Name = "closingBracketButton";
            this.closingBracketButton.Size = new System.Drawing.Size(64, 64);
            this.closingBracketButton.TabIndex = 10;
            this.closingBracketButton.Text = ")";
            this.closingBracketButton.UseVisualStyleBackColor = false;
            this.closingBracketButton.Click += new System.EventHandler(this.closingBracket_Click);
            // 
            // logicalOperators
            // 
            this.logicalOperators.BackColor = System.Drawing.Color.Azure;
            this.logicalOperators.Controls.Add(this.negation);
            this.logicalOperators.Controls.Add(this.notAnd);
            this.logicalOperators.Controls.Add(this.notOr);
            this.logicalOperators.Controls.Add(this.equivalence);
            this.logicalOperators.Controls.Add(this.conjunction);
            this.logicalOperators.Controls.Add(this.implication);
            this.logicalOperators.Controls.Add(this.disjunction);
            this.logicalOperators.Controls.Add(this.exclusiveOr);
            this.logicalOperators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logicalOperators.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logicalOperators.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.logicalOperators.Location = new System.Drawing.Point(12, 118);
            this.logicalOperators.Name = "logicalOperators";
            this.logicalOperators.Size = new System.Drawing.Size(566, 100);
            this.logicalOperators.TabIndex = 11;
            this.logicalOperators.TabStop = false;
            this.logicalOperators.Text = "Логические операторы";
            // 
            // brackets
            // 
            this.brackets.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.brackets.Controls.Add(this.openingBracketButton);
            this.brackets.Controls.Add(this.closingBracketButton);
            this.brackets.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brackets.ForeColor = System.Drawing.Color.Goldenrod;
            this.brackets.Location = new System.Drawing.Point(584, 118);
            this.brackets.Name = "brackets";
            this.brackets.Size = new System.Drawing.Size(146, 100);
            this.brackets.TabIndex = 12;
            this.brackets.TabStop = false;
            this.brackets.Text = "Скобки";
            // 
            // letterA
            // 
            this.letterA.BackColor = System.Drawing.Color.IndianRed;
            this.letterA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterA.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterA.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterA.ForeColor = System.Drawing.Color.Black;
            this.letterA.Location = new System.Drawing.Point(11, 27);
            this.letterA.Name = "letterA";
            this.letterA.Size = new System.Drawing.Size(48, 48);
            this.letterA.TabIndex = 9;
            this.letterA.Text = "a";
            this.letterA.UseVisualStyleBackColor = false;
            this.letterA.Click += new System.EventHandler(this.letterA_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox1.Controls.Add(this.letterZ);
            this.groupBox1.Controls.Add(this.letterY);
            this.groupBox1.Controls.Add(this.letterX);
            this.groupBox1.Controls.Add(this.letterW);
            this.groupBox1.Controls.Add(this.letterV);
            this.groupBox1.Controls.Add(this.letterU);
            this.groupBox1.Controls.Add(this.letterT);
            this.groupBox1.Controls.Add(this.letterS);
            this.groupBox1.Controls.Add(this.letterR);
            this.groupBox1.Controls.Add(this.letterQ);
            this.groupBox1.Controls.Add(this.letterP);
            this.groupBox1.Controls.Add(this.letterO);
            this.groupBox1.Controls.Add(this.letterN);
            this.groupBox1.Controls.Add(this.letterM);
            this.groupBox1.Controls.Add(this.letterL);
            this.groupBox1.Controls.Add(this.letterK);
            this.groupBox1.Controls.Add(this.letterJ);
            this.groupBox1.Controls.Add(this.letterI);
            this.groupBox1.Controls.Add(this.letterH);
            this.groupBox1.Controls.Add(this.letterG);
            this.groupBox1.Controls.Add(this.letterF);
            this.groupBox1.Controls.Add(this.letterE);
            this.groupBox1.Controls.Add(this.letterD);
            this.groupBox1.Controls.Add(this.letterC);
            this.groupBox1.Controls.Add(this.letterB);
            this.groupBox1.Controls.Add(this.letterA);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(12, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 140);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Переменные";
            // 
            // letterZ
            // 
            this.letterZ.BackColor = System.Drawing.Color.IndianRed;
            this.letterZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterZ.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterZ.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterZ.ForeColor = System.Drawing.Color.Black;
            this.letterZ.Location = new System.Drawing.Point(659, 81);
            this.letterZ.Name = "letterZ";
            this.letterZ.Size = new System.Drawing.Size(48, 48);
            this.letterZ.TabIndex = 34;
            this.letterZ.Text = "z";
            this.letterZ.UseVisualStyleBackColor = false;
            this.letterZ.Click += new System.EventHandler(this.letterZ_Click);
            // 
            // letterY
            // 
            this.letterY.BackColor = System.Drawing.Color.IndianRed;
            this.letterY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterY.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterY.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterY.ForeColor = System.Drawing.Color.Black;
            this.letterY.Location = new System.Drawing.Point(605, 81);
            this.letterY.Name = "letterY";
            this.letterY.Size = new System.Drawing.Size(48, 48);
            this.letterY.TabIndex = 33;
            this.letterY.Text = "y";
            this.letterY.UseVisualStyleBackColor = false;
            this.letterY.Click += new System.EventHandler(this.letterY_Click);
            // 
            // letterX
            // 
            this.letterX.BackColor = System.Drawing.Color.IndianRed;
            this.letterX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterX.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterX.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterX.ForeColor = System.Drawing.Color.Black;
            this.letterX.Location = new System.Drawing.Point(551, 81);
            this.letterX.Name = "letterX";
            this.letterX.Size = new System.Drawing.Size(48, 48);
            this.letterX.TabIndex = 32;
            this.letterX.Text = "x";
            this.letterX.UseVisualStyleBackColor = false;
            this.letterX.Click += new System.EventHandler(this.letterX_Click);
            // 
            // letterW
            // 
            this.letterW.BackColor = System.Drawing.Color.IndianRed;
            this.letterW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterW.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterW.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterW.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterW.ForeColor = System.Drawing.Color.Black;
            this.letterW.Location = new System.Drawing.Point(497, 81);
            this.letterW.Name = "letterW";
            this.letterW.Size = new System.Drawing.Size(48, 48);
            this.letterW.TabIndex = 31;
            this.letterW.Text = "w";
            this.letterW.UseVisualStyleBackColor = false;
            this.letterW.Click += new System.EventHandler(this.letterW_Click);
            // 
            // letterV
            // 
            this.letterV.BackColor = System.Drawing.Color.IndianRed;
            this.letterV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterV.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterV.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterV.ForeColor = System.Drawing.Color.Black;
            this.letterV.Location = new System.Drawing.Point(443, 81);
            this.letterV.Name = "letterV";
            this.letterV.Size = new System.Drawing.Size(48, 48);
            this.letterV.TabIndex = 30;
            this.letterV.Text = "v";
            this.letterV.UseVisualStyleBackColor = false;
            this.letterV.Click += new System.EventHandler(this.letterV_Click);
            // 
            // letterU
            // 
            this.letterU.BackColor = System.Drawing.Color.IndianRed;
            this.letterU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterU.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterU.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterU.ForeColor = System.Drawing.Color.Black;
            this.letterU.Location = new System.Drawing.Point(389, 81);
            this.letterU.Name = "letterU";
            this.letterU.Size = new System.Drawing.Size(48, 48);
            this.letterU.TabIndex = 29;
            this.letterU.Text = "u";
            this.letterU.UseVisualStyleBackColor = false;
            this.letterU.Click += new System.EventHandler(this.letterU_Click);
            // 
            // letterT
            // 
            this.letterT.BackColor = System.Drawing.Color.IndianRed;
            this.letterT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterT.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterT.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterT.ForeColor = System.Drawing.Color.Black;
            this.letterT.Location = new System.Drawing.Point(335, 81);
            this.letterT.Name = "letterT";
            this.letterT.Size = new System.Drawing.Size(48, 48);
            this.letterT.TabIndex = 28;
            this.letterT.Text = "t";
            this.letterT.UseVisualStyleBackColor = false;
            this.letterT.Click += new System.EventHandler(this.letterT_Click);
            // 
            // letterS
            // 
            this.letterS.BackColor = System.Drawing.Color.IndianRed;
            this.letterS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterS.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterS.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterS.ForeColor = System.Drawing.Color.Black;
            this.letterS.Location = new System.Drawing.Point(281, 81);
            this.letterS.Name = "letterS";
            this.letterS.Size = new System.Drawing.Size(48, 48);
            this.letterS.TabIndex = 27;
            this.letterS.Text = "s";
            this.letterS.UseVisualStyleBackColor = false;
            this.letterS.Click += new System.EventHandler(this.letterS_Click);
            // 
            // letterR
            // 
            this.letterR.BackColor = System.Drawing.Color.IndianRed;
            this.letterR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterR.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterR.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterR.ForeColor = System.Drawing.Color.Black;
            this.letterR.Location = new System.Drawing.Point(227, 81);
            this.letterR.Name = "letterR";
            this.letterR.Size = new System.Drawing.Size(48, 48);
            this.letterR.TabIndex = 26;
            this.letterR.Text = "r";
            this.letterR.UseVisualStyleBackColor = false;
            this.letterR.Click += new System.EventHandler(this.letterR_Click);
            // 
            // letterQ
            // 
            this.letterQ.BackColor = System.Drawing.Color.IndianRed;
            this.letterQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterQ.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterQ.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterQ.ForeColor = System.Drawing.Color.Black;
            this.letterQ.Location = new System.Drawing.Point(173, 81);
            this.letterQ.Name = "letterQ";
            this.letterQ.Size = new System.Drawing.Size(48, 48);
            this.letterQ.TabIndex = 25;
            this.letterQ.Text = "q";
            this.letterQ.UseVisualStyleBackColor = false;
            this.letterQ.Click += new System.EventHandler(this.letterQ_Click);
            // 
            // letterP
            // 
            this.letterP.BackColor = System.Drawing.Color.IndianRed;
            this.letterP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterP.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterP.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterP.ForeColor = System.Drawing.Color.Black;
            this.letterP.Location = new System.Drawing.Point(119, 81);
            this.letterP.Name = "letterP";
            this.letterP.Size = new System.Drawing.Size(48, 48);
            this.letterP.TabIndex = 24;
            this.letterP.Text = "p";
            this.letterP.UseVisualStyleBackColor = false;
            this.letterP.Click += new System.EventHandler(this.letterP_Click);
            // 
            // letterO
            // 
            this.letterO.BackColor = System.Drawing.Color.IndianRed;
            this.letterO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterO.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterO.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterO.ForeColor = System.Drawing.Color.Black;
            this.letterO.Location = new System.Drawing.Point(65, 81);
            this.letterO.Name = "letterO";
            this.letterO.Size = new System.Drawing.Size(48, 48);
            this.letterO.TabIndex = 23;
            this.letterO.Text = "o";
            this.letterO.UseVisualStyleBackColor = false;
            this.letterO.Click += new System.EventHandler(this.letterO_Click);
            // 
            // letterN
            // 
            this.letterN.BackColor = System.Drawing.Color.IndianRed;
            this.letterN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterN.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterN.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterN.ForeColor = System.Drawing.Color.Black;
            this.letterN.Location = new System.Drawing.Point(11, 81);
            this.letterN.Name = "letterN";
            this.letterN.Size = new System.Drawing.Size(48, 48);
            this.letterN.TabIndex = 22;
            this.letterN.Text = "n";
            this.letterN.UseVisualStyleBackColor = false;
            this.letterN.Click += new System.EventHandler(this.letterN_Click);
            // 
            // letterM
            // 
            this.letterM.BackColor = System.Drawing.Color.IndianRed;
            this.letterM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterM.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterM.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterM.ForeColor = System.Drawing.Color.Black;
            this.letterM.Location = new System.Drawing.Point(659, 27);
            this.letterM.Name = "letterM";
            this.letterM.Size = new System.Drawing.Size(48, 48);
            this.letterM.TabIndex = 21;
            this.letterM.Text = "m";
            this.letterM.UseVisualStyleBackColor = false;
            this.letterM.Click += new System.EventHandler(this.letterM_Click);
            // 
            // letterL
            // 
            this.letterL.BackColor = System.Drawing.Color.IndianRed;
            this.letterL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterL.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterL.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterL.ForeColor = System.Drawing.Color.Black;
            this.letterL.Location = new System.Drawing.Point(605, 27);
            this.letterL.Name = "letterL";
            this.letterL.Size = new System.Drawing.Size(48, 48);
            this.letterL.TabIndex = 20;
            this.letterL.Text = "l";
            this.letterL.UseVisualStyleBackColor = false;
            this.letterL.Click += new System.EventHandler(this.letterL_Click);
            // 
            // letterK
            // 
            this.letterK.BackColor = System.Drawing.Color.IndianRed;
            this.letterK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterK.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterK.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterK.ForeColor = System.Drawing.Color.Black;
            this.letterK.Location = new System.Drawing.Point(551, 27);
            this.letterK.Name = "letterK";
            this.letterK.Size = new System.Drawing.Size(48, 48);
            this.letterK.TabIndex = 19;
            this.letterK.Text = "k";
            this.letterK.UseVisualStyleBackColor = false;
            this.letterK.Click += new System.EventHandler(this.letterK_Click);
            // 
            // letterJ
            // 
            this.letterJ.BackColor = System.Drawing.Color.IndianRed;
            this.letterJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterJ.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterJ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterJ.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterJ.ForeColor = System.Drawing.Color.Black;
            this.letterJ.Location = new System.Drawing.Point(497, 27);
            this.letterJ.Name = "letterJ";
            this.letterJ.Size = new System.Drawing.Size(48, 48);
            this.letterJ.TabIndex = 18;
            this.letterJ.Text = "j";
            this.letterJ.UseVisualStyleBackColor = false;
            this.letterJ.Click += new System.EventHandler(this.letterJ_Click);
            // 
            // letterI
            // 
            this.letterI.BackColor = System.Drawing.Color.IndianRed;
            this.letterI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterI.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterI.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterI.ForeColor = System.Drawing.Color.Black;
            this.letterI.Location = new System.Drawing.Point(443, 27);
            this.letterI.Name = "letterI";
            this.letterI.Size = new System.Drawing.Size(48, 48);
            this.letterI.TabIndex = 17;
            this.letterI.Text = "i";
            this.letterI.UseVisualStyleBackColor = false;
            this.letterI.Click += new System.EventHandler(this.letterI_Click);
            // 
            // letterH
            // 
            this.letterH.BackColor = System.Drawing.Color.IndianRed;
            this.letterH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterH.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterH.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterH.ForeColor = System.Drawing.Color.Black;
            this.letterH.Location = new System.Drawing.Point(389, 27);
            this.letterH.Name = "letterH";
            this.letterH.Size = new System.Drawing.Size(48, 48);
            this.letterH.TabIndex = 16;
            this.letterH.Text = "h";
            this.letterH.UseVisualStyleBackColor = false;
            this.letterH.Click += new System.EventHandler(this.letterH_Click);
            // 
            // letterG
            // 
            this.letterG.BackColor = System.Drawing.Color.IndianRed;
            this.letterG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterG.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterG.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterG.ForeColor = System.Drawing.Color.Black;
            this.letterG.Location = new System.Drawing.Point(335, 27);
            this.letterG.Name = "letterG";
            this.letterG.Size = new System.Drawing.Size(48, 48);
            this.letterG.TabIndex = 15;
            this.letterG.Text = "g";
            this.letterG.UseVisualStyleBackColor = false;
            this.letterG.Click += new System.EventHandler(this.letterG_Click);
            // 
            // letterF
            // 
            this.letterF.BackColor = System.Drawing.Color.IndianRed;
            this.letterF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterF.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterF.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterF.ForeColor = System.Drawing.Color.Black;
            this.letterF.Location = new System.Drawing.Point(281, 27);
            this.letterF.Name = "letterF";
            this.letterF.Size = new System.Drawing.Size(48, 48);
            this.letterF.TabIndex = 14;
            this.letterF.Text = "f";
            this.letterF.UseVisualStyleBackColor = false;
            this.letterF.Click += new System.EventHandler(this.letterF_Click);
            // 
            // letterE
            // 
            this.letterE.BackColor = System.Drawing.Color.IndianRed;
            this.letterE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterE.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterE.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterE.ForeColor = System.Drawing.Color.Black;
            this.letterE.Location = new System.Drawing.Point(227, 27);
            this.letterE.Name = "letterE";
            this.letterE.Size = new System.Drawing.Size(48, 48);
            this.letterE.TabIndex = 13;
            this.letterE.Text = "e";
            this.letterE.UseVisualStyleBackColor = false;
            this.letterE.Click += new System.EventHandler(this.letterE_Click);
            // 
            // letterD
            // 
            this.letterD.BackColor = System.Drawing.Color.IndianRed;
            this.letterD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterD.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterD.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterD.ForeColor = System.Drawing.Color.Black;
            this.letterD.Location = new System.Drawing.Point(173, 27);
            this.letterD.Name = "letterD";
            this.letterD.Size = new System.Drawing.Size(48, 48);
            this.letterD.TabIndex = 12;
            this.letterD.Text = "d";
            this.letterD.UseVisualStyleBackColor = false;
            this.letterD.Click += new System.EventHandler(this.letterD_Click);
            // 
            // letterC
            // 
            this.letterC.BackColor = System.Drawing.Color.IndianRed;
            this.letterC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterC.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterC.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterC.ForeColor = System.Drawing.Color.Black;
            this.letterC.Location = new System.Drawing.Point(119, 27);
            this.letterC.Name = "letterC";
            this.letterC.Size = new System.Drawing.Size(48, 48);
            this.letterC.TabIndex = 11;
            this.letterC.Text = "c";
            this.letterC.UseVisualStyleBackColor = false;
            this.letterC.Click += new System.EventHandler(this.letterC_Click);
            // 
            // letterB
            // 
            this.letterB.BackColor = System.Drawing.Color.IndianRed;
            this.letterB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.letterB.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.letterB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.letterB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letterB.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterB.ForeColor = System.Drawing.Color.Black;
            this.letterB.Location = new System.Drawing.Point(65, 27);
            this.letterB.Name = "letterB";
            this.letterB.Size = new System.Drawing.Size(48, 48);
            this.letterB.TabIndex = 10;
            this.letterB.Text = "b";
            this.letterB.UseVisualStyleBackColor = false;
            this.letterB.Click += new System.EventHandler(this.letterB_Click);
            // 
            // eraseFromLeft
            // 
            this.eraseFromLeft.BackColor = System.Drawing.Color.Gray;
            this.eraseFromLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraseFromLeft.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.eraseFromLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.eraseFromLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraseFromLeft.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseFromLeft.ForeColor = System.Drawing.Color.Black;
            this.eraseFromLeft.Location = new System.Drawing.Point(508, 19);
            this.eraseFromLeft.Name = "eraseFromLeft";
            this.eraseFromLeft.Size = new System.Drawing.Size(64, 64);
            this.eraseFromLeft.TabIndex = 9;
            this.eraseFromLeft.Text = "⌫";
            this.eraseFromLeft.UseVisualStyleBackColor = false;
            this.eraseFromLeft.Click += new System.EventHandler(this.eraseFromLeft_Click);
            // 
            // clearInput
            // 
            this.clearInput.BackColor = System.Drawing.Color.Red;
            this.clearInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearInput.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.clearInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.clearInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearInput.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearInput.ForeColor = System.Drawing.Color.Black;
            this.clearInput.Location = new System.Drawing.Point(578, 19);
            this.clearInput.Name = "clearInput";
            this.clearInput.Size = new System.Drawing.Size(64, 64);
            this.clearInput.TabIndex = 13;
            this.clearInput.Text = "✕";
            this.clearInput.UseVisualStyleBackColor = false;
            this.clearInput.Click += new System.EventHandler(this.clearInput_Click);
            // 
            // submitQuery
            // 
            this.submitQuery.BackColor = System.Drawing.Color.ForestGreen;
            this.submitQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitQuery.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.submitQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.submitQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitQuery.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitQuery.ForeColor = System.Drawing.Color.Black;
            this.submitQuery.Location = new System.Drawing.Point(648, 19);
            this.submitQuery.Name = "submitQuery";
            this.submitQuery.Size = new System.Drawing.Size(64, 64);
            this.submitQuery.TabIndex = 14;
            this.submitQuery.Text = "✓";
            this.submitQuery.UseVisualStyleBackColor = false;
            this.submitQuery.Click += new System.EventHandler(this.submitQuery_Click);
            // 
            // logicFunctionArea
            // 
            this.logicFunctionArea.BackColor = System.Drawing.Color.MediumAquamarine;
            this.logicFunctionArea.Controls.Add(this.formulaInputField);
            this.logicFunctionArea.Controls.Add(this.submitQuery);
            this.logicFunctionArea.Controls.Add(this.eraseFromLeft);
            this.logicFunctionArea.Controls.Add(this.clearInput);
            this.logicFunctionArea.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logicFunctionArea.ForeColor = System.Drawing.Color.DarkGreen;
            this.logicFunctionArea.Location = new System.Drawing.Point(12, 12);
            this.logicFunctionArea.Name = "logicFunctionArea";
            this.logicFunctionArea.Size = new System.Drawing.Size(718, 100);
            this.logicFunctionArea.TabIndex = 15;
            this.logicFunctionArea.TabStop = false;
            this.logicFunctionArea.Text = "Ввод формулы логической функции";
            // 
            // truthTableBox
            // 
            this.truthTableBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.truthTableBox.Controls.Add(this.truthTableStrings);
            this.truthTableBox.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truthTableBox.ForeColor = System.Drawing.Color.Navy;
            this.truthTableBox.Location = new System.Drawing.Point(736, 12);
            this.truthTableBox.Name = "truthTableBox";
            this.truthTableBox.Size = new System.Drawing.Size(326, 352);
            this.truthTableBox.TabIndex = 16;
            this.truthTableBox.TabStop = false;
            this.truthTableBox.Text = "Таблица истинности";
            // 
            // truthTableStrings
            // 
            this.truthTableStrings.Location = new System.Drawing.Point(13, 41);
            this.truthTableStrings.Multiline = true;
            this.truthTableStrings.Name = "truthTableStrings";
            this.truthTableStrings.ReadOnly = true;
            this.truthTableStrings.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.truthTableStrings.Size = new System.Drawing.Size(299, 298);
            this.truthTableStrings.TabIndex = 0;
            // 
            // boxPDNF
            // 
            this.boxPDNF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boxPDNF.Controls.Add(this.stringFieldPDNF);
            this.boxPDNF.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPDNF.ForeColor = System.Drawing.Color.Navy;
            this.boxPDNF.Location = new System.Drawing.Point(12, 370);
            this.boxPDNF.Name = "boxPDNF";
            this.boxPDNF.Size = new System.Drawing.Size(1050, 78);
            this.boxPDNF.TabIndex = 17;
            this.boxPDNF.TabStop = false;
            this.boxPDNF.Text = "СДНФ";
            // 
            // stringFieldPDNF
            // 
            this.stringFieldPDNF.Location = new System.Drawing.Point(11, 29);
            this.stringFieldPDNF.Name = "stringFieldPDNF";
            this.stringFieldPDNF.ReadOnly = true;
            this.stringFieldPDNF.Size = new System.Drawing.Size(1025, 40);
            this.stringFieldPDNF.TabIndex = 0;
            // 
            // boxPСNF
            // 
            this.boxPСNF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boxPСNF.Controls.Add(this.stringFieldPСNF);
            this.boxPСNF.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPСNF.ForeColor = System.Drawing.Color.Navy;
            this.boxPСNF.Location = new System.Drawing.Point(12, 454);
            this.boxPСNF.Name = "boxPСNF";
            this.boxPСNF.Size = new System.Drawing.Size(1050, 78);
            this.boxPСNF.TabIndex = 18;
            this.boxPСNF.TabStop = false;
            this.boxPСNF.Text = "СКНФ";
            // 
            // stringFieldPСNF
            // 
            this.stringFieldPСNF.Location = new System.Drawing.Point(11, 29);
            this.stringFieldPСNF.Name = "stringFieldPСNF";
            this.stringFieldPСNF.ReadOnly = true;
            this.stringFieldPСNF.Size = new System.Drawing.Size(1025, 40);
            this.stringFieldPСNF.TabIndex = 0;
            // 
            // boxMDNF
            // 
            this.boxMDNF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boxMDNF.Controls.Add(this.stringFiledMDNF);
            this.boxMDNF.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxMDNF.ForeColor = System.Drawing.Color.Navy;
            this.boxMDNF.Location = new System.Drawing.Point(12, 538);
            this.boxMDNF.Name = "boxMDNF";
            this.boxMDNF.Size = new System.Drawing.Size(1050, 78);
            this.boxMDNF.TabIndex = 19;
            this.boxMDNF.TabStop = false;
            this.boxMDNF.Text = "Первая МДНФ с наименьшим количеством импликант";
            // 
            // stringFiledMDNF
            // 
            this.stringFiledMDNF.Location = new System.Drawing.Point(11, 29);
            this.stringFiledMDNF.Name = "stringFiledMDNF";
            this.stringFiledMDNF.ReadOnly = true;
            this.stringFiledMDNF.Size = new System.Drawing.Size(1025, 40);
            this.stringFiledMDNF.TabIndex = 0;
            // 
            // MyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1074, 627);
            this.Controls.Add(this.boxMDNF);
            this.Controls.Add(this.boxPСNF);
            this.Controls.Add(this.boxPDNF);
            this.Controls.Add(this.truthTableBox);
            this.Controls.Add(this.logicFunctionArea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.brackets);
            this.Controls.Add(this.logicalOperators);
            this.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyForm";
            this.Text = "Свойства логической функции";
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.logicalOperators.ResumeLayout(false);
            this.brackets.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.logicFunctionArea.ResumeLayout(false);
            this.logicFunctionArea.PerformLayout();
            this.truthTableBox.ResumeLayout(false);
            this.truthTableBox.PerformLayout();
            this.boxPDNF.ResumeLayout(false);
            this.boxPDNF.PerformLayout();
            this.boxPСNF.ResumeLayout(false);
            this.boxPСNF.PerformLayout();
            this.boxMDNF.ResumeLayout(false);
            this.boxMDNF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox formulaInputField;
        private System.Windows.Forms.Button negation;
        private System.Windows.Forms.Button notAnd;
        private System.Windows.Forms.Button notOr;
        private System.Windows.Forms.Button conjunction;
        private System.Windows.Forms.Button disjunction;
        private System.Windows.Forms.Button exclusiveOr;
        private System.Windows.Forms.Button implication;
        private System.Windows.Forms.Button equivalence;
        private System.Windows.Forms.Button openingBracketButton;
        private System.Windows.Forms.Button closingBracketButton;
        private System.Windows.Forms.GroupBox logicalOperators;
        private System.Windows.Forms.GroupBox brackets;
        private System.Windows.Forms.Button letterA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button letterI;
        private System.Windows.Forms.Button letterH;
        private System.Windows.Forms.Button letterG;
        private System.Windows.Forms.Button letterF;
        private System.Windows.Forms.Button letterE;
        private System.Windows.Forms.Button letterD;
        private System.Windows.Forms.Button letterC;
        private System.Windows.Forms.Button letterB;
        private System.Windows.Forms.Button letterZ;
        private System.Windows.Forms.Button letterY;
        private System.Windows.Forms.Button letterX;
        private System.Windows.Forms.Button letterW;
        private System.Windows.Forms.Button letterV;
        private System.Windows.Forms.Button letterU;
        private System.Windows.Forms.Button letterT;
        private System.Windows.Forms.Button letterS;
        private System.Windows.Forms.Button letterR;
        private System.Windows.Forms.Button letterQ;
        private System.Windows.Forms.Button letterP;
        private System.Windows.Forms.Button letterO;
        private System.Windows.Forms.Button letterN;
        private System.Windows.Forms.Button letterM;
        private System.Windows.Forms.Button letterL;
        private System.Windows.Forms.Button letterK;
        private System.Windows.Forms.Button letterJ;
        private System.Windows.Forms.Button eraseFromLeft;
        private System.Windows.Forms.Button clearInput;
        private System.Windows.Forms.Button submitQuery;
        private System.Windows.Forms.GroupBox logicFunctionArea;
        private System.Windows.Forms.GroupBox truthTableBox;
        private System.Windows.Forms.TextBox truthTableStrings;
        private System.Windows.Forms.GroupBox boxPDNF;
        private System.Windows.Forms.TextBox stringFieldPDNF;
        private System.Windows.Forms.GroupBox boxPСNF;
        private System.Windows.Forms.TextBox stringFieldPСNF;
        private System.Windows.Forms.GroupBox boxMDNF;
        private System.Windows.Forms.TextBox stringFiledMDNF;
    }
}

