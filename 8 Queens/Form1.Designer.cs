namespace _8_Queens
{
	partial class frmMain
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblSize = new System.Windows.Forms.Label();
			this.updSize = new System.Windows.Forms.NumericUpDown();
			this.btnExecute = new System.Windows.Forms.Button();
			this.lblPossibilities = new System.Windows.Forms.Label();
			this.lstPossibilities = new System.Windows.Forms.ListBox();
			this.picBoard = new System.Windows.Forms.PictureBox();
			this.updWait = new System.Windows.Forms.NumericUpDown();
			this.lblWait = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.updSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.updWait)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(9, 9);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(109, 13);
			this.lblSize.TabIndex = 0;
			this.lblSize.Text = "Largeur de grill (NxN):";
			// 
			// updSize
			// 
			this.updSize.Location = new System.Drawing.Point(12, 25);
			this.updSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.updSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.updSize.Name = "updSize";
			this.updSize.Size = new System.Drawing.Size(149, 20);
			this.updSize.TabIndex = 1;
			this.updSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(12, 51);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(149, 23);
			this.btnExecute.TabIndex = 2;
			this.btnExecute.Text = "Exécuter";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// lblPossibilities
			// 
			this.lblPossibilities.AutoSize = true;
			this.lblPossibilities.Location = new System.Drawing.Point(9, 148);
			this.lblPossibilities.Name = "lblPossibilities";
			this.lblPossibilities.Size = new System.Drawing.Size(61, 13);
			this.lblPossibilities.TabIndex = 3;
			this.lblPossibilities.Text = "Possibilités:";
			// 
			// lstPossibilities
			// 
			this.lstPossibilities.FormattingEnabled = true;
			this.lstPossibilities.Location = new System.Drawing.Point(12, 168);
			this.lstPossibilities.Name = "lstPossibilities";
			this.lstPossibilities.Size = new System.Drawing.Size(149, 329);
			this.lstPossibilities.TabIndex = 4;
			// 
			// picBoard
			// 
			this.picBoard.Location = new System.Drawing.Point(167, 12);
			this.picBoard.Name = "picBoard";
			this.picBoard.Size = new System.Drawing.Size(485, 485);
			this.picBoard.TabIndex = 5;
			this.picBoard.TabStop = false;
			this.picBoard.Click += new System.EventHandler(this.picBoard_Click);
			this.picBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoard_Paint);
			// 
			// updWait
			// 
			this.updWait.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.updWait.Location = new System.Drawing.Point(12, 109);
			this.updWait.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.updWait.Name = "updWait";
			this.updWait.Size = new System.Drawing.Size(149, 20);
			this.updWait.TabIndex = 7;
			this.updWait.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// lblWait
			// 
			this.lblWait.AutoSize = true;
			this.lblWait.Location = new System.Drawing.Point(9, 93);
			this.lblWait.Name = "lblWait";
			this.lblWait.Size = new System.Drawing.Size(110, 13);
			this.lblWait.TabIndex = 6;
			this.lblWait.Text = "Temps d\'attente (mS):";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 509);
			this.Controls.Add(this.updWait);
			this.Controls.Add(this.lblWait);
			this.Controls.Add(this.picBoard);
			this.Controls.Add(this.lstPossibilities);
			this.Controls.Add(this.lblPossibilities);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.updSize);
			this.Controls.Add(this.lblSize);
			this.Name = "frmMain";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.updSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.updWait)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.NumericUpDown updSize;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Label lblPossibilities;
		private System.Windows.Forms.PictureBox picBoard;
		public System.Windows.Forms.ListBox lstPossibilities;
		private System.Windows.Forms.NumericUpDown updWait;
		private System.Windows.Forms.Label lblWait;
	}
}

