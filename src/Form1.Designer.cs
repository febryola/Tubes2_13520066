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
            this.labelTimeSpent = new System.Windows.Forms.Label();
            this.labelPathFile = new System.Windows.Forms.Label();
            this.panelTreeBox = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.labelChooseDir = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.panelOutput.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.BackColor = System.Drawing.Color.Transparent;
            this.labelInput.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInput.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelInput.Location = new System.Drawing.Point(21, 24);
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
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(92, 32);
            this.labelOutput.TabIndex = 13;
            this.labelOutput.Text = "Output";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInputFile.Location = new System.Drawing.Point(21, 178);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(145, 25);
            this.labelInputFile.TabIndex = 15;
            this.labelInputFile.Text = "Input File Name";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(21, 206);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(269, 31);
            this.textBoxFilename.TabIndex = 16;
            // 
            // checkBoxAllOcc
            // 
            this.checkBoxAllOcc.AutoSize = true;
            this.checkBoxAllOcc.Location = new System.Drawing.Point(21, 243);
            this.checkBoxAllOcc.Name = "checkBoxAllOcc";
            this.checkBoxAllOcc.Size = new System.Drawing.Size(184, 29);
            this.checkBoxAllOcc.TabIndex = 17;
            this.checkBoxAllOcc.Text = "Find All Occurence";
            this.checkBoxAllOcc.UseVisualStyleBackColor = true;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMethod.Location = new System.Drawing.Point(21, 305);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(137, 25);
            this.labelMethod.TabIndex = 18;
            this.labelMethod.Text = "Search Method";
            // 
            // radioButtonBFS
            // 
            this.radioButtonBFS.AutoSize = true;
            this.radioButtonBFS.Location = new System.Drawing.Point(21, 333);
            this.radioButtonBFS.Name = "radioButtonBFS";
            this.radioButtonBFS.Size = new System.Drawing.Size(66, 29);
            this.radioButtonBFS.TabIndex = 19;
            this.radioButtonBFS.TabStop = true;
            this.radioButtonBFS.Text = "BFS";
            this.radioButtonBFS.UseVisualStyleBackColor = true;
            // 
            // radioButtonDFS
            // 
            this.radioButtonDFS.AutoSize = true;
            this.radioButtonDFS.Location = new System.Drawing.Point(21, 368);
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
            this.buttonSearch.Location = new System.Drawing.Point(21, 422);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(96, 34);
            this.buttonSearch.TabIndex = 21;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Teal;
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(986, 97);
            this.panelHeader.TabIndex = 22;
            // 
            // panelOutput
            // 
            this.panelOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelOutput.Controls.Add(this.labelTimeSpent);
            this.panelOutput.Controls.Add(this.labelPathFile);
            this.panelOutput.Controls.Add(this.panelTreeBox);
            this.panelOutput.Controls.Add(this.labelOutput);
            this.panelOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOutput.Location = new System.Drawing.Point(311, 97);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(675, 528);
            this.panelOutput.TabIndex = 23;
            // 
            // labelTimeSpent
            // 
            this.labelTimeSpent.AutoSize = true;
            this.labelTimeSpent.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeSpent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeSpent.ForeColor = System.Drawing.Color.White;
            this.labelTimeSpent.Location = new System.Drawing.Point(22, 478);
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
            this.labelPathFile.Name = "labelPathFile";
            this.labelPathFile.Size = new System.Drawing.Size(86, 25);
            this.labelPathFile.TabIndex = 24;
            this.labelPathFile.Text = "Path File:";
            // 
            // panelTreeBox
            // 
            this.panelTreeBox.BackColor = System.Drawing.Color.White;
            this.panelTreeBox.Location = new System.Drawing.Point(22, 68);
            this.panelTreeBox.Name = "panelTreeBox";
            this.panelTreeBox.Size = new System.Drawing.Size(593, 317);
            this.panelTreeBox.TabIndex = 14;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.panelInput.Location = new System.Drawing.Point(0, 97);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(311, 528);
            this.panelInput.TabIndex = 24;
            // 
            // labelChooseDir
            // 
            this.labelChooseDir.AutoSize = true;
            this.labelChooseDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChooseDir.Location = new System.Drawing.Point(21, 87);
            this.labelChooseDir.Name = "labelChooseDir";
            this.labelChooseDir.Size = new System.Drawing.Size(228, 25);
            this.labelChooseDir.TabIndex = 24;
            this.labelChooseDir.Text = "Choose Starting Directory";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(19, 115);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(230, 31);
            this.textBoxDir.TabIndex = 23;
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.BackColor = System.Drawing.Color.White;
            this.buttonChooseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChooseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChooseFolder.Location = new System.Drawing.Point(255, 115);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(35, 31);
            this.buttonChooseFolder.TabIndex = 22;
            this.buttonChooseFolder.Text = "...";
            this.buttonChooseFolder.UseVisualStyleBackColor = false;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelOutput.ResumeLayout(false);
            this.panelOutput.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
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
        private Panel panelTreeBox;
        private Label labelPathFile;
        private Label labelTimeSpent;
        private Panel panelInput;
        private TextBox textBoxDir;
        private Button buttonChooseFolder;
        private Label labelChooseDir;
    }
}