using System.Windows.Forms;

namespace Ex05.CheckersGUI
{
    partial class SetupForm : Form
    {
        private void InitializeComponent()
        {
            this.LabelBoardSize = new System.Windows.Forms.Label();
            this.RadioButton6x6 = new System.Windows.Forms.RadioButton();
            this.RadioButton8x8 = new System.Windows.Forms.RadioButton();
            this.RadioButton10x10 = new System.Windows.Forms.RadioButton();
            this.LabelPlayers = new System.Windows.Forms.Label();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelBoardSize
            // 
            this.LabelBoardSize.AccessibleName = "LabelBoardSize";
            this.LabelBoardSize.AutoSize = true;
            this.LabelBoardSize.Location = new System.Drawing.Point(17, 19);
            this.LabelBoardSize.Name = "LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(83, 20);
            this.LabelBoardSize.TabIndex = 0;
            this.LabelBoardSize.Text = "Board Size:";
            // 
            // RadioButton6x6
            // 
            this.RadioButton6x6.AccessibleName = "RadioButton6x6";
            this.RadioButton6x6.AutoSize = true;
            this.RadioButton6x6.Checked = true;
            this.RadioButton6x6.Location = new System.Drawing.Point(51, 44);
            this.RadioButton6x6.Name = "RadioButton6x6";
            this.RadioButton6x6.Size = new System.Drawing.Size(61, 24);
            this.RadioButton6x6.TabIndex = 1;
            this.RadioButton6x6.TabStop = true;
            this.RadioButton6x6.Text = "6 x 6";
            this.RadioButton6x6.UseVisualStyleBackColor = true;
            this.RadioButton6x6.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // RadioButton8x8
            // 
            this.RadioButton8x8.AccessibleName = "RadioButton8x8";
            this.RadioButton8x8.AutoSize = true;
            this.RadioButton8x8.Location = new System.Drawing.Point(142, 44);
            this.RadioButton8x8.Name = "RadioButton8x8";
            this.RadioButton8x8.Size = new System.Drawing.Size(61, 24);
            this.RadioButton8x8.TabIndex = 2;
            this.RadioButton8x8.Text = "8 x 8";
            this.RadioButton8x8.UseVisualStyleBackColor = true;
            this.RadioButton8x8.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // RadioButton10x10
            // 
            this.RadioButton10x10.AccessibleName = "RadioButton10x10";
            this.RadioButton10x10.AutoSize = true;
            this.RadioButton10x10.Location = new System.Drawing.Point(233, 44);
            this.RadioButton10x10.Name = "RadioButton10x10";
            this.RadioButton10x10.Size = new System.Drawing.Size(77, 24);
            this.RadioButton10x10.TabIndex = 3;
            this.RadioButton10x10.Text = "10 x 10";
            this.RadioButton10x10.UseVisualStyleBackColor = true;
            this.RadioButton10x10.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // LabelPlayers
            // 
            this.LabelPlayers.AccessibleName = "LabelPlayers";
            this.LabelPlayers.AutoSize = true;
            this.LabelPlayers.Location = new System.Drawing.Point(17, 83);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(58, 20);
            this.LabelPlayers.TabIndex = 4;
            this.LabelPlayers.Text = "Players:";
            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.AccessibleName = "LabelPlayer1";
            this.LabelPlayer1.AutoSize = true;
            this.LabelPlayer1.Location = new System.Drawing.Point(30, 115);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(60, 20);
            this.LabelPlayer1.TabIndex = 5;
            this.LabelPlayer1.Text = "Player1:";
            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.AccessibleName = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.AutoSize = true;
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(30, 150);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(82, 24);
            this.CheckBoxPlayer2.TabIndex = 7;
            this.CheckBoxPlayer2.Text = "Player2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckStateChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckStateChanged);
            // 
            // TextBoxPlayer1
            // 
            this.TextBoxPlayer1.AccessibleName = "TextBoxPlayer1";
            this.TextBoxPlayer1.Location = new System.Drawing.Point(122, 112);
            this.TextBoxPlayer1.Name = "TextBoxPlayer1";
            this.TextBoxPlayer1.Size = new System.Drawing.Size(188, 27);
            this.TextBoxPlayer1.TabIndex = 6;
            // 
            // TextBoxPlayer2
            // 
            this.TextBoxPlayer2.AccessibleName = "TextBoxPlayer2";
            this.TextBoxPlayer2.Enabled = false;
            this.TextBoxPlayer2.Location = new System.Drawing.Point(122, 148);
            this.TextBoxPlayer2.Name = "TextBoxPlayer2";
            this.TextBoxPlayer2.Size = new System.Drawing.Size(188, 27);
            this.TextBoxPlayer2.TabIndex = 8;
            this.TextBoxPlayer2.Text = "[Computer]";
            // 
            // ButtonDone
            // 
            this.ButtonDone.AccessibleName = "ButtonDone";
            this.ButtonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDone.Location = new System.Drawing.Point(196, 197);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(117, 36);
            this.ButtonDone.TabIndex = 9;
            this.ButtonDone.Text = "&Done";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // SetupForm
            // 
            this.AcceptButton = this.ButtonDone;
            this.AccessibleName = "SetupForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(327, 246);
            this.Controls.Add(this.ButtonDone);
            this.Controls.Add(this.TextBoxPlayer2);
            this.Controls.Add(this.TextBoxPlayer1);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.LabelPlayers);
            this.Controls.Add(this.RadioButton10x10);
            this.Controls.Add(this.RadioButton8x8);
            this.Controls.Add(this.RadioButton6x6);
            this.Controls.Add(this.LabelBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label LabelBoardSize;
        private RadioButton RadioButton6x6;
        private RadioButton RadioButton8x8;
        private RadioButton RadioButton10x10;
        private Label LabelPlayers;
        private Label LabelPlayer1;
        private CheckBox CheckBoxPlayer2;
        private TextBox TextBoxPlayer1;
        private TextBox TextBoxPlayer2;
        private Button ButtonDone;
    }
}