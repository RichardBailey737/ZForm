namespace TMS_Tracking_Process_Utility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.pb = new System.Windows.Forms.PictureBox();
            this.PropertySplitContainer = new System.Windows.Forms.SplitContainer();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.output = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayBtn = new System.Windows.Forms.ToolStripButton();
            this.stepSimBtn = new System.Windows.Forms.ToolStripButton();
            this.stopSimBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomBtn = new System.Windows.Forms.ToolStripButton();
            this.MoveBtn = new System.Windows.Forms.ToolStripButton();
            this.resetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertySplitContainer)).BeginInit();
            this.PropertySplitContainer.Panel1.SuspendLayout();
            this.PropertySplitContainer.Panel2.SuspendLayout();
            this.PropertySplitContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.MainSplitContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(789, 672);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(789, 697);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.pb);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.PropertySplitContainer);
            this.MainSplitContainer.Size = new System.Drawing.Size(789, 672);
            this.MainSplitContainer.SplitterDistance = 549;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(549, 672);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.Click += new System.EventHandler(this.pb_Click);
            // 
            // PropertySplitContainer
            // 
            this.PropertySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.PropertySplitContainer.Name = "PropertySplitContainer";
            this.PropertySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // PropertySplitContainer.Panel1
            // 
            this.PropertySplitContainer.Panel1.Controls.Add(this.pg);
            // 
            // PropertySplitContainer.Panel2
            // 
            this.PropertySplitContainer.Panel2.Controls.Add(this.output);
            this.PropertySplitContainer.Size = new System.Drawing.Size(236, 672);
            this.PropertySplitContainer.SplitterDistance = 400;
            this.PropertySplitContainer.TabIndex = 0;
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(0, 0);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(236, 400);
            this.pg.TabIndex = 0;
            // 
            // output
            // 
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.FormattingEnabled = true;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(236, 268);
            this.output.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.toolStripSeparator1,
            this.PlayBtn,
            this.stepSimBtn,
            this.stopSimBtn,
            this.toolStripSeparator2,
            this.zoomBtn,
            this.MoveBtn,
            this.resetBtn,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(371, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // newBtn
            // 
            this.newBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(23, 22);
            this.newBtn.Text = "toolStripButton1";
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PlayBtn
            // 
            this.PlayBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayBtn.Image")));
            this.PlayBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(23, 22);
            this.PlayBtn.Text = "toolStripButton2";
            // 
            // stepSimBtn
            // 
            this.stepSimBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepSimBtn.Image = ((System.Drawing.Image)(resources.GetObject("stepSimBtn.Image")));
            this.stepSimBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepSimBtn.Name = "stepSimBtn";
            this.stepSimBtn.Size = new System.Drawing.Size(23, 22);
            this.stepSimBtn.Text = "toolStripButton3";
            // 
            // stopSimBtn
            // 
            this.stopSimBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopSimBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopSimBtn.Image")));
            this.stopSimBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopSimBtn.Name = "stopSimBtn";
            this.stopSimBtn.Size = new System.Drawing.Size(23, 22);
            this.stopSimBtn.Text = "toolStripButton4";
            this.stopSimBtn.Click += new System.EventHandler(this.stopSimBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomBtn
            // 
            this.zoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomBtn.Image")));
            this.zoomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomBtn.Name = "zoomBtn";
            this.zoomBtn.Size = new System.Drawing.Size(23, 22);
            this.zoomBtn.Text = "toolStripButton5";
            this.zoomBtn.Click += new System.EventHandler(this.zoomBtn_Click);
            // 
            // MoveBtn
            // 
            this.MoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoveBtn.Image")));
            this.MoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(85, 22);
            this.MoveBtn.Text = "Move Camera";
            this.MoveBtn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetBtn.Image")));
            this.resetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(83, 22);
            this.resetBtn.Text = "Reset Camera";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "Test";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 697);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.PropertySplitContainer.Panel1.ResumeLayout(false);
            this.PropertySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertySplitContainer)).EndInit();
            this.PropertySplitContainer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer PropertySplitContainer;
        private System.Windows.Forms.PropertyGrid pg;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton PlayBtn;
        private System.Windows.Forms.ToolStripButton stepSimBtn;
        private System.Windows.Forms.ToolStripButton stopSimBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton zoomBtn;
        private System.Windows.Forms.ToolStripButton MoveBtn;
        private System.Windows.Forms.ToolStripButton resetBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

    }
}

