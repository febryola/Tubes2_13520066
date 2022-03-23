namespace src
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.checkBoxAllOcc = new System.Windows.Forms.CheckBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.radioButtonBFS = new System.Windows.Forms.RadioButton();
            this.radioButtonDFS = new System.Windows.Forms.RadioButton();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.labelTimeSpent = new System.Windows.Forms.Label();
            this.labelPathFile = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.labelDelay = new System.Windows.Forms.Label();
            this.trackBarDelay = new System.Windows.Forms.TrackBar();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelChooseDir = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDialog2 = new System.Windows.Forms.PrintDialog();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.panelOutput.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.BackColor = System.Drawing.Color.Transparent;
            this.labelInput.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInput.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelInput.Location = new System.Drawing.Point(13, 24);
            this.labelInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(72, 32);
            this.labelInput.TabIndex = 12;
            this.labelInput.Text = "Input";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.BackColor = System.Drawing.Color.Transparent;
            this.labelOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOutput.ForeColor = System.Drawing.Color.White;
            this.labelOutput.Location = new System.Drawing.Point(22, 24);
            this.labelOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(105, 32);
            this.labelOutput.TabIndex = 13;
            this.labelOutput.Text = "Output :";
            this.labelOutput.Click += new System.EventHandler(this.labelOutput_Click);
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInputFile.Location = new System.Drawing.Point(17, 149);
            this.labelInputFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(145, 25);
            this.labelInputFile.TabIndex = 15;
            this.labelInputFile.Text = "Input File Name";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(21, 177);
            this.textBoxFilename.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(269, 31);
            this.textBoxFilename.TabIndex = 16;
            // 
            // checkBoxAllOcc
            // 
            this.checkBoxAllOcc.AutoSize = true;
            this.checkBoxAllOcc.Location = new System.Drawing.Point(21, 213);
            this.checkBoxAllOcc.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAllOcc.Name = "checkBoxAllOcc";
            this.checkBoxAllOcc.Size = new System.Drawing.Size(184, 29);
            this.checkBoxAllOcc.TabIndex = 17;
            this.checkBoxAllOcc.Text = "Find All Occurence";
            this.checkBoxAllOcc.UseVisualStyleBackColor = true;
            this.checkBoxAllOcc.CheckedChanged += new System.EventHandler(this.checkBoxAllOcc_CheckedChanged);
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMethod.Location = new System.Drawing.Point(14, 259);
            this.labelMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(137, 25);
            this.labelMethod.TabIndex = 18;
            this.labelMethod.Text = "Search Method";
            // 
            // radioButtonBFS
            // 
            this.radioButtonBFS.AutoSize = true;
            this.radioButtonBFS.Location = new System.Drawing.Point(21, 286);
            this.radioButtonBFS.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBFS.Name = "radioButtonBFS";
            this.radioButtonBFS.Size = new System.Drawing.Size(66, 29);
            this.radioButtonBFS.TabIndex = 19;
            this.radioButtonBFS.TabStop = true;
            this.radioButtonBFS.Text = "BFS";
            this.radioButtonBFS.UseVisualStyleBackColor = true;
            this.radioButtonBFS.CheckedChanged += new System.EventHandler(this.radioButtonBFS_CheckedChanged);
            // 
            // radioButtonDFS
            // 
            this.radioButtonDFS.AutoSize = true;
            this.radioButtonDFS.Location = new System.Drawing.Point(125, 286);
            this.radioButtonDFS.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonDFS.Name = "radioButtonDFS";
            this.radioButtonDFS.Size = new System.Drawing.Size(69, 29);
            this.radioButtonDFS.TabIndex = 20;
            this.radioButtonDFS.TabStop = true;
            this.radioButtonDFS.Text = "DFS";
            this.radioButtonDFS.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearch.Location = new System.Drawing.Point(23, 437);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(106, 34);
            this.buttonSearch.TabIndex = 21;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Teal;
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(986, 98);
            this.panelHeader.TabIndex = 22;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // panelOutput
            // 
            this.panelOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelOutput.Controls.Add(this.label1);
            this.panelOutput.Controls.Add(this.richTextBox1);
            this.panelOutput.Controls.Add(this.pathBox);
            this.panelOutput.Controls.Add(this.panelGraph);
            this.panelOutput.Controls.Add(this.resultBox);
            this.panelOutput.Controls.Add(this.labelTimeSpent);
            this.panelOutput.Controls.Add(this.labelPathFile);
            this.panelOutput.Controls.Add(this.labelOutput);
            this.panelOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOutput.Location = new System.Drawing.Point(311, 98);
            this.panelOutput.Margin = new System.Windows.Forms.Padding(2);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(675, 527);
            this.panelOutput.TabIndex = 23;
            this.panelOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOutput_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(139, 478);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 30;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 422);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(592, 50);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // pathBox
            // 
            this.pathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.pathBox.ForeColor = System.Drawing.Color.White;
            this.pathBox.Location = new System.Drawing.Point(118, 398);
            this.pathBox.Margin = new System.Windows.Forms.Padding(2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(482, 24);
            this.pathBox.TabIndex = 28;
            this.pathBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Location = new System.Drawing.Point(22, 68);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(2);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(592, 318);
            this.panelGraph.TabIndex = 15;
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.resultBox.ForeColor = System.Drawing.Color.White;
            this.resultBox.Location = new System.Drawing.Point(132, 24);
            this.resultBox.Margin = new System.Windows.Forms.Padding(2);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(482, 32);
            this.resultBox.TabIndex = 27;
            this.resultBox.TextChanged += new System.EventHandler(this.resultBox_TextChanged);
            // 
            // labelTimeSpent
            // 
            this.labelTimeSpent.AutoSize = true;
            this.labelTimeSpent.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeSpent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeSpent.ForeColor = System.Drawing.Color.White;
            this.labelTimeSpent.Location = new System.Drawing.Point(22, 478);
            this.labelTimeSpent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeSpent.Name = "labelTimeSpent";
            this.labelTimeSpent.Size = new System.Drawing.Size(111, 25);
            this.labelTimeSpent.TabIndex = 25;
            this.labelTimeSpent.Text = "Time Spent:";
            // 
            // labelPathFile
            // 
            this.labelPathFile.AutoSize = true;
            this.labelPathFile.BackColor = System.Drawing.Color.Transparent;
            this.labelPathFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPathFile.ForeColor = System.Drawing.Color.White;
            this.labelPathFile.Location = new System.Drawing.Point(22, 398);
            this.labelPathFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPathFile.Name = "labelPathFile";
            this.labelPathFile.Size = new System.Drawing.Size(86, 25);
            this.labelPathFile.TabIndex = 24;
            this.labelPathFile.Text = "Path File:";
            this.labelPathFile.Click += new System.EventHandler(this.labelPathFile_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelInput.Controls.Add(this.labelDelay);
            this.panelInput.Controls.Add(this.trackBarDelay);
            this.panelInput.Controls.Add(this.buttonRefresh);
            this.panelInput.Controls.Add(this.labelChooseDir);
            this.panelInput.Controls.Add(this.textBoxDir);
            this.panelInput.Controls.Add(this.buttonChooseFolder);
            this.panelInput.Controls.Add(this.labelInput);
            this.panelInput.Controls.Add(this.labelInputFile);
            this.panelInput.Controls.Add(this.buttonSearch);
            this.panelInput.Controls.Add(this.textBoxFilename);
            this.panelInput.Controls.Add(this.radioButtonDFS);
            this.panelInput.Controls.Add(this.checkBoxAllOcc);
            this.panelInput.Controls.Add(this.radioButtonBFS);
            this.panelInput.Controls.Add(this.labelMethod);
            this.panelInput.Location = new System.Drawing.Point(0, 98);
            this.panelInput.Margin = new System.Windows.Forms.Padding(2);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(311, 528);
            this.panelInput.TabIndex = 24;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDelay.Location = new System.Drawing.Point(14, 333);
            this.labelDelay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(58, 25);
            this.labelDelay.TabIndex = 27;
            this.labelDelay.Text = "Delay";
            // 
            // trackBarDelay
            // 
            this.trackBarDelay.Location = new System.Drawing.Point(19, 366);
            this.trackBarDelay.Maximum = 5000;
            this.trackBarDelay.Name = "trackBarDelay";
            this.trackBarDelay.Size = new System.Drawing.Size(269, 69);
            this.trackBarDelay.TabIndex = 26;
            this.trackBarDelay.Scroll += new System.EventHandler(this.trackBarDelay_Scroll);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(156, 437);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(38, 34);
            this.buttonRefresh.TabIndex = 25;
            this.buttonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelChooseDir
            // 
            this.labelChooseDir.AutoSize = true;
            this.labelChooseDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChooseDir.Location = new System.Drawing.Point(14, 70);
            this.labelChooseDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseDir.Name = "labelChooseDir";
            this.labelChooseDir.Size = new System.Drawing.Size(228, 25);
            this.labelChooseDir.TabIndex = 24;
            this.labelChooseDir.Text = "Choose Starting Directory";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(19, 97);
            this.textBoxDir.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(230, 31);
            this.textBoxDir.TabIndex = 23;
            this.textBoxDir.TextChanged += new System.EventHandler(this.textBoxDir_TextChanged);
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.BackColor = System.Drawing.Color.White;
            this.buttonChooseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChooseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChooseFolder.Location = new System.Drawing.Point(255, 97);
            this.buttonChooseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(35, 31);
            this.buttonChooseFolder.TabIndex = 22;
            this.buttonChooseFolder.Text = "...";
            this.buttonChooseFolder.UseVisualStyleBackColor = false;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDialog2
            // 
            this.printDialog2.UseEXDialog = true;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 625);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelOutput.ResumeLayout(false);
            this.panelOutput.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label labelInput;
        private Label labelOutput;
        private Label labelInputFile;
        private TextBox textBoxFilename;
        private CheckBox checkBoxAllOcc;
        private Label labelMethod;
        private RadioButton radioButtonBFS;
        private RadioButton radioButtonDFS;
        private Button buttonSearch;
        private Panel panelHeader;
        private Panel panelOutput;
        private Panel panelGraph;
        private TextBox resultBox;
        private Label labelPathFile;
        private Label labelTimeSpent;
        private Panel panelInput;
        private TextBox textBoxDir;
        private Button buttonChooseFolder;
        private Label labelChooseDir;
        private PrintDialog printDialog1;
        private PrintDialog printDialog2;
        private System.ComponentModel.BackgroundWorker bgworker;
        private Button buttonRefresh;
        private TextBox pathBox;
        private RichTextBox richTextBox1;
        private Label label1;
        private TrackBar trackBarDelay;
        private Label labelDelay;
    }
}
