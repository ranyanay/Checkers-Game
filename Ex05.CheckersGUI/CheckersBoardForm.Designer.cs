using System.Windows.Forms;

namespace Ex05.CheckersGUI
{
    partial class CheckersBoardForm
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
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.LabelPlayer2 = new System.Windows.Forms.Label();
            this.LabelPlayer1Points = new System.Windows.Forms.Label();
            this.LabelPlayer2Points = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.AccessibleName = "LabelPlayer1";
            this.LabelPlayer1.AutoSize = true;
            this.LabelPlayer1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayer1.Location = new System.Drawing.Point(82, 12);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(65, 22);
            this.LabelPlayer1.TabIndex = 0;
            this.LabelPlayer1.Text = "Player 1";
            // 
            // LabelPlayer2
            // 
            this.LabelPlayer2.AccessibleName = "LabelPlayer2";
            this.LabelPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPlayer2.AutoSize = true;
            this.LabelPlayer2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayer2.Location = new System.Drawing.Point(282, 12);
            this.LabelPlayer2.Name = "LabelPlayer2";
            this.LabelPlayer2.Size = new System.Drawing.Size(65, 22);
            this.LabelPlayer2.TabIndex = 1;
            this.LabelPlayer2.Text = "Player 2";
            // 
            // LabelPlayer1Points
            // 
            this.LabelPlayer1Points.AccessibleName = "LabelPlayer1Points";
            this.LabelPlayer1Points.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LabelPlayer1Points.AutoSize = true;
            this.LabelPlayer1Points.Location = new System.Drawing.Point(141, 15);
            this.LabelPlayer1Points.Name = "LabelPlayer1Points";
            this.LabelPlayer1Points.Size = new System.Drawing.Size(20, 16);
            this.LabelPlayer1Points.TabIndex = 2;
            this.LabelPlayer1Points.Text = ": 0";
            // 
            // LabelPlayer2Points
            // 
            this.LabelPlayer2Points.AccessibleName = "LabelPlayer1Points";
            this.LabelPlayer2Points.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LabelPlayer2Points.AutoSize = true;
            this.LabelPlayer2Points.Location = new System.Drawing.Point(343, 15);
            this.LabelPlayer2Points.Name = "LabelPlayer2Points";
            this.LabelPlayer2Points.Size = new System.Drawing.Size(20, 16);
            this.LabelPlayer2Points.TabIndex = 3;
            this.LabelPlayer2Points.Text = ": 0";
            // 
            // CheckersBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 337);
            this.Controls.Add(this.LabelPlayer2Points);
            this.Controls.Add(this.LabelPlayer1Points);
            this.Controls.Add(this.LabelPlayer2);
            this.Controls.Add(this.LabelPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CheckersBoardForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelPlayer1;
        private Label LabelPlayer2;
        private Label LabelPlayer1Points;
        private Label LabelPlayer2Points;
    }
}