namespace Tic_Tac_Toe_Game {
    partial class TicTacToeForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.titleLabel = new System.Windows.Forms.Label();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.titleLabel.Location = new System.Drawing.Point(91, 20);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(203, 44);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Tic Tac Toe";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlayer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(91, 66);
            this.lblCurrentPlayer.Margin = new System.Windows.Forms.Padding(10);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(202, 25);
            this.lblCurrentPlayer.TabIndex = 2;
            this.lblCurrentPlayer.Text = "Current Player";
            this.lblCurrentPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblGameStatus.Location = new System.Drawing.Point(19, 93);
            this.lblGameStatus.Margin = new System.Windows.Forms.Padding(10);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(346, 60);
            this.lblGameStatus.TabIndex = 3;
            this.lblGameStatus.Text = "Game Status";
            this.lblGameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            this.restartButton.AutoSize = true;
            this.restartButton.BackColor = System.Drawing.Color.Teal;
            this.restartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.restartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.White;
            this.restartButton.Location = new System.Drawing.Point(132, 470);
            this.restartButton.Margin = new System.Windows.Forms.Padding(10);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(120, 31);
            this.restartButton.TabIndex = 4;
            this.restartButton.Text = "Restart Game";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.gamePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.gamePanel.ColumnCount = 2;
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Location = new System.Drawing.Point(42, 152);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(10);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.RowCount = 2;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Size = new System.Drawing.Size(300, 300);
            this.gamePanel.TabIndex = 5;
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(384, 511);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.lblGameStatus);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "TicTacToeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.TicTacToeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.TableLayoutPanel gamePanel;
    }
}

