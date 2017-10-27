namespace wordsearch
{
    partial class Form1
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
            this.wordSearch = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWord = new System.Windows.Forms.Label();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wordSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // wordSearch
            // 
            this.wordSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordSearch.Location = new System.Drawing.Point(13, 4);
            this.wordSearch.Name = "wordSearch";
            this.wordSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wordSearch.Size = new System.Drawing.Size(1042, 249);
            this.wordSearch.TabIndex = 0;
            this.wordSearch.MultiSelectChanged += new System.EventHandler(this.selectionChanged);
            this.wordSearch.SelectionChanged += new System.EventHandler(this.selectionChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 259);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Location = new System.Drawing.Point(106, 264);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(89, 13);
            this.lblWord.TabIndex = 2;
            this.lblWord.Text = "Word to look for: ";
            // 
            // lstWords
            // 
            this.lstWords.FormattingEnabled = true;
            this.lstWords.Location = new System.Drawing.Point(12, 309);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(183, 134);
            this.lstWords.TabIndex = 3;
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(79, 293);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(38, 13);
            this.lblWords.TabIndex = 4;
            this.lblWords.Text = "Words";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(201, 340);
            this.txtInput.MaxLength = 10;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(116, 20);
            this.txtInput.TabIndex = 5;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(201, 309);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(116, 23);
            this.btnAddWord.TabIndex = 6;
            this.btnAddWord.Text = "Add";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(201, 420);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(116, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(201, 366);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(116, 23);
            this.btnReadFile.TabIndex = 8;
            this.btnReadFile.Text = "Load from file";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Found word?:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.wordSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Word Search Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView wordSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
    }
}

