namespace Image_Optimizer_Plus
{
    partial class formMain
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
            this.customLabelOutputDirectory = new CustomUI.Controls.CustomLabel();
            this.customTextBoxOutputDirectory = new CustomUI.Controls.CustomTextBox();
            this.customButtonBrowse = new CustomUI.Controls.CustomButton();
            this.customCheckBoxOverwriteOriginalFiles = new CustomUI.Controls.CustomCheckBox();
            this.customButtonOptimize = new CustomUI.Controls.CustomButton();
            this.customButtonAddImages = new CustomUI.Controls.CustomButton();
            this.customButtonRemoveImages = new CustomUI.Controls.CustomButton();
            this.customButtonClearImages = new CustomUI.Controls.CustomButton();
            this.customStatusStripGlobalStatus = new CustomUI.Controls.CustomStatusStrip();
            this.customProgressBarStatus = new CustomUI.Controls.CustomProgressBar();
            this.customLabelStatus = new CustomUI.Controls.CustomLabel();
            this.customMenuStrip1 = new CustomUI.Controls.CustomMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customGroupBoxControls = new CustomUI.Controls.CustomGroupBox();
            this.customButtonCancel = new CustomUI.Controls.CustomButton();
            this.openFileDialogImages = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.customListViewLog = new Image_Optimizer_Plus.CustomListViewDragDrop();
            this.customMenuStrip1.SuspendLayout();
            this.customGroupBoxControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // customLabelOutputDirectory
            // 
            this.customLabelOutputDirectory.AutoSize = true;
            this.customLabelOutputDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.customLabelOutputDirectory.Location = new System.Drawing.Point(3, 14);
            this.customLabelOutputDirectory.Name = "customLabelOutputDirectory";
            this.customLabelOutputDirectory.Size = new System.Drawing.Size(84, 13);
            this.customLabelOutputDirectory.TabIndex = 0;
            this.customLabelOutputDirectory.Text = "Output Directory";
            // 
            // customTextBoxOutputDirectory
            // 
            this.customTextBoxOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextBoxOutputDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.customTextBoxOutputDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customTextBoxOutputDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.customTextBoxOutputDirectory.Location = new System.Drawing.Point(6, 36);
            this.customTextBoxOutputDirectory.Name = "customTextBoxOutputDirectory";
            this.customTextBoxOutputDirectory.Size = new System.Drawing.Size(713, 20);
            this.customTextBoxOutputDirectory.TabIndex = 1;
            // 
            // customButtonBrowse
            // 
            this.customButtonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButtonBrowse.Location = new System.Drawing.Point(725, 36);
            this.customButtonBrowse.Name = "customButtonBrowse";
            this.customButtonBrowse.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonBrowse.Size = new System.Drawing.Size(29, 20);
            this.customButtonBrowse.TabIndex = 2;
            this.customButtonBrowse.Text = "...";
            this.customButtonBrowse.Click += new System.EventHandler(this.customButtonBrowse_Click);
            // 
            // customCheckBoxOverwriteOriginalFiles
            // 
            this.customCheckBoxOverwriteOriginalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customCheckBoxOverwriteOriginalFiles.Location = new System.Drawing.Point(620, 13);
            this.customCheckBoxOverwriteOriginalFiles.Name = "customCheckBoxOverwriteOriginalFiles";
            this.customCheckBoxOverwriteOriginalFiles.Size = new System.Drawing.Size(134, 17);
            this.customCheckBoxOverwriteOriginalFiles.TabIndex = 3;
            this.customCheckBoxOverwriteOriginalFiles.Text = "Overwrite Original Files";
            this.customCheckBoxOverwriteOriginalFiles.CheckedChanged += new System.EventHandler(this.customCheckBoxOverwriteOriginalFiles_CheckedChanged);
            // 
            // customButtonOptimize
            // 
            this.customButtonOptimize.Enabled = false;
            this.customButtonOptimize.Location = new System.Drawing.Point(6, 62);
            this.customButtonOptimize.Name = "customButtonOptimize";
            this.customButtonOptimize.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonOptimize.Size = new System.Drawing.Size(116, 23);
            this.customButtonOptimize.TabIndex = 4;
            this.customButtonOptimize.Text = "Optimize!";
            this.customButtonOptimize.Click += new System.EventHandler(this.customButtonOptimize_Click);
            // 
            // customButtonAddImages
            // 
            this.customButtonAddImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButtonAddImages.Location = new System.Drawing.Point(394, 62);
            this.customButtonAddImages.Name = "customButtonAddImages";
            this.customButtonAddImages.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonAddImages.Size = new System.Drawing.Size(116, 23);
            this.customButtonAddImages.TabIndex = 5;
            this.customButtonAddImages.Text = "Add Images";
            this.customButtonAddImages.Click += new System.EventHandler(this.customButtonAddImages_Click);
            // 
            // customButtonRemoveImages
            // 
            this.customButtonRemoveImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButtonRemoveImages.Enabled = false;
            this.customButtonRemoveImages.Location = new System.Drawing.Point(516, 62);
            this.customButtonRemoveImages.Name = "customButtonRemoveImages";
            this.customButtonRemoveImages.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonRemoveImages.Size = new System.Drawing.Size(116, 23);
            this.customButtonRemoveImages.TabIndex = 6;
            this.customButtonRemoveImages.Text = "Remove Images";
            this.customButtonRemoveImages.Click += new System.EventHandler(this.customButtonRemoveImages_Click);
            // 
            // customButtonClearImages
            // 
            this.customButtonClearImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButtonClearImages.Enabled = false;
            this.customButtonClearImages.Location = new System.Drawing.Point(638, 62);
            this.customButtonClearImages.Name = "customButtonClearImages";
            this.customButtonClearImages.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonClearImages.Size = new System.Drawing.Size(116, 23);
            this.customButtonClearImages.TabIndex = 7;
            this.customButtonClearImages.Text = "Clear Images";
            this.customButtonClearImages.Click += new System.EventHandler(this.customButtonClearImages_Click);
            // 
            // customStatusStripGlobalStatus
            // 
            this.customStatusStripGlobalStatus.AutoSize = false;
            this.customStatusStripGlobalStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.customStatusStripGlobalStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.customStatusStripGlobalStatus.Location = new System.Drawing.Point(0, 434);
            this.customStatusStripGlobalStatus.Name = "customStatusStripGlobalStatus";
            this.customStatusStripGlobalStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.customStatusStripGlobalStatus.Size = new System.Drawing.Size(784, 27);
            this.customStatusStripGlobalStatus.SizingGrip = false;
            this.customStatusStripGlobalStatus.TabIndex = 10;
            this.customStatusStripGlobalStatus.Text = "customStatusStrip1";
            // 
            // customProgressBarStatus
            // 
            this.customProgressBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.customProgressBarStatus.CurrentValue = 0;
            this.customProgressBarStatus.Location = new System.Drawing.Point(534, 439);
            this.customProgressBarStatus.Maximum = 100;
            this.customProgressBarStatus.Name = "customProgressBarStatus";
            this.customProgressBarStatus.Size = new System.Drawing.Size(238, 19);
            this.customProgressBarStatus.TabIndex = 11;
            this.customProgressBarStatus.Visible = false;
            // 
            // customLabelStatus
            // 
            this.customLabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.customLabelStatus.AutoSize = true;
            this.customLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.customLabelStatus.Location = new System.Drawing.Point(9, 441);
            this.customLabelStatus.Name = "customLabelStatus";
            this.customLabelStatus.Size = new System.Drawing.Size(0, 13);
            this.customLabelStatus.TabIndex = 12;
            // 
            // customMenuStrip1
            // 
            this.customMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.customMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.customMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.customMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.customMenuStrip1.Name = "customMenuStrip1";
            this.customMenuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.customMenuStrip1.Size = new System.Drawing.Size(784, 24);
            this.customMenuStrip1.TabIndex = 13;
            this.customMenuStrip1.Text = "customMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // customGroupBoxControls
            // 
            this.customGroupBoxControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customGroupBoxControls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.customGroupBoxControls.Controls.Add(this.customButtonCancel);
            this.customGroupBoxControls.Controls.Add(this.customLabelOutputDirectory);
            this.customGroupBoxControls.Controls.Add(this.customTextBoxOutputDirectory);
            this.customGroupBoxControls.Controls.Add(this.customButtonBrowse);
            this.customGroupBoxControls.Controls.Add(this.customCheckBoxOverwriteOriginalFiles);
            this.customGroupBoxControls.Controls.Add(this.customButtonOptimize);
            this.customGroupBoxControls.Controls.Add(this.customButtonAddImages);
            this.customGroupBoxControls.Controls.Add(this.customButtonClearImages);
            this.customGroupBoxControls.Controls.Add(this.customButtonRemoveImages);
            this.customGroupBoxControls.Location = new System.Drawing.Point(12, 27);
            this.customGroupBoxControls.Name = "customGroupBoxControls";
            this.customGroupBoxControls.Size = new System.Drawing.Size(760, 91);
            this.customGroupBoxControls.TabIndex = 14;
            this.customGroupBoxControls.TabStop = false;
            // 
            // customButtonCancel
            // 
            this.customButtonCancel.Enabled = false;
            this.customButtonCancel.Location = new System.Drawing.Point(128, 62);
            this.customButtonCancel.Name = "customButtonCancel";
            this.customButtonCancel.Padding = new System.Windows.Forms.Padding(5);
            this.customButtonCancel.Size = new System.Drawing.Size(116, 23);
            this.customButtonCancel.TabIndex = 8;
            this.customButtonCancel.Text = "Cancel";
            this.customButtonCancel.Visible = false;
            this.customButtonCancel.Click += new System.EventHandler(this.customButtonCancel_Click);
            // 
            // openFileDialogImages
            // 
            this.openFileDialogImages.Filter = "PNG files (*.png)|*.png";
            this.openFileDialogImages.Multiselect = true;
            // 
            // customListViewLog
            // 
            this.customListViewLog.AllowDrop = true;
            this.customListViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customListViewLog.Location = new System.Drawing.Point(12, 124);
            this.customListViewLog.MultiSelect = true;
            this.customListViewLog.Name = "customListViewLog";
            this.customListViewLog.Size = new System.Drawing.Size(760, 307);
            this.customListViewLog.StringFont = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.customListViewLog.StringText = "Drag and drop images and folders here";
            this.customListViewLog.TabIndex = 8;
            this.customListViewLog.Text = "customListView1";
            this.customListViewLog.DragDrop += new System.Windows.Forms.DragEventHandler(this.customListViewLog_DragDrop);
            this.customListViewLog.DragEnter += new System.Windows.Forms.DragEventHandler(this.customListViewLog_DragEnter);
            this.customListViewLog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customListViewLog_KeyUp);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.customGroupBoxControls);
            this.Controls.Add(this.customLabelStatus);
            this.Controls.Add(this.customProgressBarStatus);
            this.Controls.Add(this.customStatusStripGlobalStatus);
            this.Controls.Add(this.customMenuStrip1);
            this.Controls.Add(this.customListViewLog);
            this.MainMenuStrip = this.customMenuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "formMain";
            this.Text = "Image Optimizer Plus";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.customMenuStrip1.ResumeLayout(false);
            this.customMenuStrip1.PerformLayout();
            this.customGroupBoxControls.ResumeLayout(false);
            this.customGroupBoxControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUI.Controls.CustomLabel customLabelOutputDirectory;
        private CustomUI.Controls.CustomTextBox customTextBoxOutputDirectory;
        private CustomUI.Controls.CustomButton customButtonBrowse;
        private CustomUI.Controls.CustomCheckBox customCheckBoxOverwriteOriginalFiles;
        private CustomUI.Controls.CustomButton customButtonOptimize;
        private CustomUI.Controls.CustomButton customButtonAddImages;
        private CustomUI.Controls.CustomButton customButtonRemoveImages;
        private CustomUI.Controls.CustomButton customButtonClearImages;
        private CustomListViewDragDrop customListViewLog;
        private CustomUI.Controls.CustomStatusStrip customStatusStripGlobalStatus;
        private CustomUI.Controls.CustomProgressBar customProgressBarStatus;
        private CustomUI.Controls.CustomLabel customLabelStatus;
        private CustomUI.Controls.CustomMenuStrip customMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private CustomUI.Controls.CustomGroupBox customGroupBoxControls;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogImages;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogBrowse;
        private CustomUI.Controls.CustomButton customButtonCancel;
    }
}

