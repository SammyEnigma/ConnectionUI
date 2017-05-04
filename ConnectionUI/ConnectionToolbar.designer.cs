namespace AdamOneilSoftware
{
	partial class ConnectionToolbar
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionToolbar));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.tscbConnection = new System.Windows.Forms.ToolStripComboBox();
			this.tsbCodeGenOptions = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButton1,
			this.tscbConnection,
			this.tsbCodeGenOptions});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(490, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Connections...";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// tscbConnection
			// 
			this.tscbConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbConnection.Name = "tscbConnection";
			this.tscbConnection.Size = new System.Drawing.Size(150, 25);
			this.tscbConnection.SelectedIndexChanged += new System.EventHandler(this.tscbConnection_SelectedIndexChanged);
			// 
			// tsbCodeGenOptions
			// 
			this.tsbCodeGenOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbCodeGenOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbCodeGenOptions.Image")));
			this.tsbCodeGenOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCodeGenOptions.Name = "tsbCodeGenOptions";
			this.tsbCodeGenOptions.Size = new System.Drawing.Size(94, 22);
			this.tsbCodeGenOptions.Text = "Integration...";
			this.tsbCodeGenOptions.Click += new System.EventHandler(this.tsbCodeGenOptions_Click);
			// 
			// ConnectionToolbar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Name = "ConnectionToolbar";
			this.Size = new System.Drawing.Size(490, 25);
			this.Load += new System.EventHandler(this.ConnectionToolbar_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripComboBox tscbConnection;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton tsbCodeGenOptions;
	}
}