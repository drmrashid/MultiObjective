namespace MultiObjective
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.lblMaxParticles = new System.Windows.Forms.Label();
            this.lblMaxIterations = new System.Windows.Forms.Label();
            this.txtMaxIterations = new System.Windows.Forms.TextBox();
            this.txtMaxParticles = new System.Windows.Forms.TextBox();
            this.lblNonDominatedCount = new System.Windows.Forms.Label();
            this.lblGenerationalDistance = new System.Windows.Forms.Label();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.lblErrorRatio = new System.Windows.Forms.Label();
            this.chkRandomPlacement = new System.Windows.Forms.CheckBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.cboZoom = new System.Windows.Forms.ComboBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.cboFunction = new System.Windows.Forms.ComboBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.lblNghRadius = new System.Windows.Forms.Label();
            this.txtNghRadius = new System.Windows.Forms.TextBox();
            this.pbrIterations = new System.Windows.Forms.ProgressBar();
            this.lblScale = new System.Windows.Forms.Label();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.chkDisplayGuess = new System.Windows.Forms.CheckBox();
            this.chkDisplaySearchSpace = new System.Windows.Forms.CheckBox();
            this.chkDrawDominated = new System.Windows.Forms.CheckBox();
            this.chkGridSearch = new System.Windows.Forms.CheckBox();
            this.lblGridDepth = new System.Windows.Forms.Label();
            this.txtGridDepth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.pnlGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(67, 21);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblMaxParticles
            // 
            this.lblMaxParticles.AutoSize = true;
            this.lblMaxParticles.Location = new System.Drawing.Point(85, 16);
            this.lblMaxParticles.Name = "lblMaxParticles";
            this.lblMaxParticles.Size = new System.Drawing.Size(70, 13);
            this.lblMaxParticles.TabIndex = 1;
            this.lblMaxParticles.Text = "Max Particles";
            // 
            // lblMaxIterations
            // 
            this.lblMaxIterations.AutoSize = true;
            this.lblMaxIterations.Location = new System.Drawing.Point(255, 16);
            this.lblMaxIterations.Name = "lblMaxIterations";
            this.lblMaxIterations.Size = new System.Drawing.Size(73, 13);
            this.lblMaxIterations.TabIndex = 2;
            this.lblMaxIterations.Text = "Max Iterations";
            // 
            // txtMaxIterations
            // 
            this.txtMaxIterations.Location = new System.Drawing.Point(334, 11);
            this.txtMaxIterations.Name = "txtMaxIterations";
            this.txtMaxIterations.Size = new System.Drawing.Size(83, 20);
            this.txtMaxIterations.TabIndex = 3;
            this.txtMaxIterations.Text = "50";
            // 
            // txtMaxParticles
            // 
            this.txtMaxParticles.Location = new System.Drawing.Point(161, 12);
            this.txtMaxParticles.Name = "txtMaxParticles";
            this.txtMaxParticles.Size = new System.Drawing.Size(83, 20);
            this.txtMaxParticles.TabIndex = 4;
            this.txtMaxParticles.Text = "10";
            // 
            // lblNonDominatedCount
            // 
            this.lblNonDominatedCount.AutoSize = true;
            this.lblNonDominatedCount.Location = new System.Drawing.Point(12, 52);
            this.lblNonDominatedCount.Name = "lblNonDominatedCount";
            this.lblNonDominatedCount.Size = new System.Drawing.Size(133, 13);
            this.lblNonDominatedCount.TabIndex = 5;
            this.lblNonDominatedCount.Text = "Non Dominated Solutions :";
            // 
            // lblGenerationalDistance
            // 
            this.lblGenerationalDistance.AutoSize = true;
            this.lblGenerationalDistance.Location = new System.Drawing.Point(12, 65);
            this.lblGenerationalDistance.Name = "lblGenerationalDistance";
            this.lblGenerationalDistance.Size = new System.Drawing.Size(118, 13);
            this.lblGenerationalDistance.TabIndex = 6;
            this.lblGenerationalDistance.Text = "Generational Distance :";
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(12, 78);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(52, 13);
            this.lblSpacing.TabIndex = 7;
            this.lblSpacing.Text = "Spacing :";
            // 
            // lblErrorRatio
            // 
            this.lblErrorRatio.AutoSize = true;
            this.lblErrorRatio.Location = new System.Drawing.Point(12, 91);
            this.lblErrorRatio.Name = "lblErrorRatio";
            this.lblErrorRatio.Size = new System.Drawing.Size(63, 13);
            this.lblErrorRatio.TabIndex = 8;
            this.lblErrorRatio.Text = "Error Ratio :";
            // 
            // chkRandomPlacement
            // 
            this.chkRandomPlacement.AutoSize = true;
            this.chkRandomPlacement.Checked = true;
            this.chkRandomPlacement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandomPlacement.Location = new System.Drawing.Point(15, 36);
            this.chkRandomPlacement.Name = "chkRandomPlacement";
            this.chkRandomPlacement.Size = new System.Drawing.Size(119, 17);
            this.chkRandomPlacement.TabIndex = 9;
            this.chkRandomPlacement.Text = "Random Placement";
            this.chkRandomPlacement.UseVisualStyleBackColor = true;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(423, 14);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(48, 13);
            this.lblZoom.TabIndex = 11;
            this.lblZoom.Text = "Zoom(%)";
            // 
            // cboZoom
            // 
            this.cboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoom.FormattingEnabled = true;
            this.cboZoom.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "75",
            "100",
            "150",
            "200",
            "400",
            "600",
            "800"});
            this.cboZoom.Location = new System.Drawing.Point(477, 11);
            this.cboZoom.Name = "cboZoom";
            this.cboZoom.Size = new System.Drawing.Size(86, 21);
            this.cboZoom.TabIndex = 12;
            this.cboZoom.SelectedIndexChanged += new System.EventHandler(this.cboScale_SelectedIndexChanged);
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(569, 14);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(48, 13);
            this.lblFunction.TabIndex = 13;
            this.lblFunction.Text = "Function";
            // 
            // cboFunction
            // 
            this.cboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFunction.FormattingEnabled = true;
            this.cboFunction.Location = new System.Drawing.Point(623, 11);
            this.cboFunction.Name = "cboFunction";
            this.cboFunction.Size = new System.Drawing.Size(91, 21);
            this.cboFunction.TabIndex = 14;
            this.cboFunction.SelectedIndexChanged += new System.EventHandler(this.cboFunction_SelectedIndexChanged);
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(3, 3);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(132, 125);
            this.picGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGraph.TabIndex = 15;
            this.picGraph.TabStop = false;
            // 
            // pnlGraph
            // 
            this.pnlGraph.AutoScroll = true;
            this.pnlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGraph.Controls.Add(this.picGraph);
            this.pnlGraph.Location = new System.Drawing.Point(15, 107);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(997, 571);
            this.pnlGraph.TabIndex = 16;
            // 
            // lblNghRadius
            // 
            this.lblNghRadius.AutoSize = true;
            this.lblNghRadius.Location = new System.Drawing.Point(720, 14);
            this.lblNghRadius.Name = "lblNghRadius";
            this.lblNghRadius.Size = new System.Drawing.Size(110, 13);
            this.lblNghRadius.TabIndex = 17;
            this.lblNghRadius.Text = "Neighborhood Radius";
            // 
            // txtNghRadius
            // 
            this.txtNghRadius.Location = new System.Drawing.Point(836, 11);
            this.txtNghRadius.Name = "txtNghRadius";
            this.txtNghRadius.Size = new System.Drawing.Size(66, 20);
            this.txtNghRadius.TabIndex = 18;
            this.txtNghRadius.Text = "0.01";
            // 
            // pbrIterations
            // 
            this.pbrIterations.Location = new System.Drawing.Point(15, 684);
            this.pbrIterations.Name = "pbrIterations";
            this.pbrIterations.Size = new System.Drawing.Size(998, 10);
            this.pbrIterations.TabIndex = 19;
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(423, 41);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(34, 13);
            this.lblScale.TabIndex = 20;
            this.lblScale.Text = "Scale";
            // 
            // cboScale
            // 
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Items.AddRange(new object[] {
            "1",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "125",
            "150",
            "175",
            "200"});
            this.cboScale.Location = new System.Drawing.Point(477, 38);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(86, 21);
            this.cboScale.TabIndex = 21;
            this.cboScale.SelectedIndexChanged += new System.EventHandler(this.cboScale_SelectedIndexChanged_1);
            // 
            // chkDisplayGuess
            // 
            this.chkDisplayGuess.AutoSize = true;
            this.chkDisplayGuess.Location = new System.Drawing.Point(270, 59);
            this.chkDisplayGuess.Name = "chkDisplayGuess";
            this.chkDisplayGuess.Size = new System.Drawing.Size(93, 17);
            this.chkDisplayGuess.TabIndex = 22;
            this.chkDisplayGuess.Text = "Display Guess";
            this.chkDisplayGuess.UseVisualStyleBackColor = true;
            this.chkDisplayGuess.CheckedChanged += new System.EventHandler(this.chkDisplayGuess_CheckedChanged);
            // 
            // chkDisplaySearchSpace
            // 
            this.chkDisplaySearchSpace.AutoSize = true;
            this.chkDisplaySearchSpace.Location = new System.Drawing.Point(270, 36);
            this.chkDisplaySearchSpace.Name = "chkDisplaySearchSpace";
            this.chkDisplaySearchSpace.Size = new System.Drawing.Size(131, 17);
            this.chkDisplaySearchSpace.TabIndex = 23;
            this.chkDisplaySearchSpace.Text = "Display Search Space";
            this.chkDisplaySearchSpace.UseVisualStyleBackColor = true;
            this.chkDisplaySearchSpace.CheckedChanged += new System.EventHandler(this.chkDisplaySearchSpace_CheckedChanged);
            // 
            // chkDrawDominated
            // 
            this.chkDrawDominated.AutoSize = true;
            this.chkDrawDominated.Location = new System.Drawing.Point(270, 82);
            this.chkDrawDominated.Name = "chkDrawDominated";
            this.chkDrawDominated.Size = new System.Drawing.Size(105, 17);
            this.chkDrawDominated.TabIndex = 24;
            this.chkDrawDominated.Text = "Draw Dominated";
            this.chkDrawDominated.UseVisualStyleBackColor = true;
            this.chkDrawDominated.CheckedChanged += new System.EventHandler(this.chkDrawDominated_CheckedChanged_1);
            // 
            // chkGridSearch
            // 
            this.chkGridSearch.AutoSize = true;
            this.chkGridSearch.Location = new System.Drawing.Point(572, 40);
            this.chkGridSearch.Name = "chkGridSearch";
            this.chkGridSearch.Size = new System.Drawing.Size(82, 17);
            this.chkGridSearch.TabIndex = 25;
            this.chkGridSearch.Text = "Grid Search";
            this.chkGridSearch.UseVisualStyleBackColor = true;
            // 
            // lblGridDepth
            // 
            this.lblGridDepth.AutoSize = true;
            this.lblGridDepth.Location = new System.Drawing.Point(720, 40);
            this.lblGridDepth.Name = "lblGridDepth";
            this.lblGridDepth.Size = new System.Drawing.Size(58, 13);
            this.lblGridDepth.TabIndex = 26;
            this.lblGridDepth.Text = "Grid Depth";
            // 
            // txtGridDepth
            // 
            this.txtGridDepth.Location = new System.Drawing.Point(836, 37);
            this.txtGridDepth.Name = "txtGridDepth";
            this.txtGridDepth.Size = new System.Drawing.Size(66, 20);
            this.txtGridDepth.TabIndex = 27;
            this.txtGridDepth.Text = "5";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 742);
            this.Controls.Add(this.txtGridDepth);
            this.Controls.Add(this.lblGridDepth);
            this.Controls.Add(this.chkGridSearch);
            this.Controls.Add(this.chkDrawDominated);
            this.Controls.Add(this.chkDisplaySearchSpace);
            this.Controls.Add(this.chkDisplayGuess);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.pbrIterations);
            this.Controls.Add(this.txtNghRadius);
            this.Controls.Add(this.lblNghRadius);
            this.Controls.Add(this.pnlGraph);
            this.Controls.Add(this.cboFunction);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.cboZoom);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.chkRandomPlacement);
            this.Controls.Add(this.lblErrorRatio);
            this.Controls.Add(this.lblSpacing);
            this.Controls.Add(this.lblGenerationalDistance);
            this.Controls.Add(this.lblNonDominatedCount);
            this.Controls.Add(this.txtMaxParticles);
            this.Controls.Add(this.txtMaxIterations);
            this.Controls.Add(this.lblMaxIterations);
            this.Controls.Add(this.lblMaxParticles);
            this.Controls.Add(this.btnRun);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Multi Objective Function Optimization";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.pnlGraph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblMaxParticles;
        private System.Windows.Forms.Label lblMaxIterations;
        private System.Windows.Forms.TextBox txtMaxIterations;
        private System.Windows.Forms.TextBox txtMaxParticles;
        private System.Windows.Forms.Label lblNonDominatedCount;
        private System.Windows.Forms.Label lblGenerationalDistance;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.Label lblErrorRatio;
        private System.Windows.Forms.CheckBox chkRandomPlacement;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.ComboBox cboZoom;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.ComboBox cboFunction;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.Label lblNghRadius;
        private System.Windows.Forms.TextBox txtNghRadius;
        private System.Windows.Forms.ProgressBar pbrIterations;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.ComboBox cboScale;
        private System.Windows.Forms.CheckBox chkDisplayGuess;
        private System.Windows.Forms.CheckBox chkDisplaySearchSpace;
        private System.Windows.Forms.CheckBox chkDrawDominated;
        private System.Windows.Forms.CheckBox chkGridSearch;
        private System.Windows.Forms.Label lblGridDepth;
        private System.Windows.Forms.TextBox txtGridDepth;
    }
}

