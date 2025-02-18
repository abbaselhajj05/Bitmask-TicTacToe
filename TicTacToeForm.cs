using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game {
    public partial class TicTacToeForm : Form {
        private TicTacToe _game = new TicTacToe();
        private bool _playerTurn = true;
        private bool _gameOver = false;

        public TicTacToeForm() {
            InitializeComponent();
            _InitializeGame();
        }
        
        private void _InitializeGame() {
            byte _boardSize = _game.BoardSize;

            gamePanel.RowStyles.Clear();
            gamePanel.ColumnStyles.Clear();

            gamePanel.ColumnCount = gamePanel.RowCount = _boardSize;

            // Set equal sizing for rows
            for (int i = 0; i < gamePanel.RowCount; i++)
                gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(gamePanel.RowCount) / 100)); // Equal height for each row
            
            // Set equal sizing for columns
            for (int j = 0; j < gamePanel.ColumnCount; j++)
                gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(gamePanel.ColumnCount) / 100)); // Equal width for each column

            // Add PictureBoxes
            short cellPosition = 0;
            for (short rowIndex = 0; rowIndex < gamePanel.RowCount; rowIndex++) {
                for (short columnIndex = 0; columnIndex < gamePanel.ColumnCount; columnIndex++) {
                    PictureBox cell = new PictureBox()
                    {
                        BackColor = Color.FromArgb(255, 224, 247, 250),
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = Resources.Question,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = cellPosition++,
                        Dock = DockStyle.Fill,
                    };
                    cell.Click += new EventHandler(cell_Click);
                    gamePanel.Controls.Add(cell, rowIndex, columnIndex);
                }
            }

            Controls.Add(gamePanel);

            lblCurrentPlayer.Text = _game.GetCurrentPlayerName() + "'s Turn";
            _UpdateGameStatus(enGameStatus.GameInProgress);
        }

        enum enGameStatus { GameOver, InvalidMove, GameInProgress, WinnerDeclared, Draw }

        private void _UpdateGameStatus(enGameStatus gameStatus) {
            switch(gameStatus) {
                case enGameStatus.GameOver:
                    lblGameStatus.Text = "Game is already over.\nReset to play again.";
                    break;
                case enGameStatus.InvalidMove:
                    lblGameStatus.Text = "Invalid Move!\nPlease choose an empty cell.";
                    break;
                case enGameStatus.GameInProgress:
                    lblGameStatus.Text = "Game in Progress...";
                    break;
                case enGameStatus.WinnerDeclared:
                    lblGameStatus.Text = $"{_game.GetWinnerName()} Wins!";
                    break;
                case enGameStatus.Draw:
                    lblGameStatus.Text = "It's a Draw!";
                    break;
            }
        }

        private void _UpdateCurrentPlayer() {
            lblCurrentPlayer.Text = _game.GetCurrentPlayerName() + "'s Turn";
        }

        private void _SwitchPlayer() {
            _playerTurn = !_playerTurn;
            _UpdateCurrentPlayer();
        }

        private void _HighlightWinningPositions() {
            List<byte> winningPositions = _game.GetWinningPositions();
            foreach (PictureBox cell in gamePanel.Controls)
                foreach (short position in winningPositions)
                    if (Convert.ToByte(cell.Tag) == position)
                        cell.BackColor = Color.LightGreen;
        }

        private void cell_Click(object sender, EventArgs e) {
            if (_gameOver) {
                _UpdateGameStatus(enGameStatus.GameOver);
                return;
            }

            PictureBox cell = (PictureBox)sender;
            byte position = Convert.ToByte(cell.Tag);

            if (!_game.IsValidMove(position)) {
                _UpdateGameStatus(enGameStatus.InvalidMove);
                return;
            }

            _UpdateGameStatus(enGameStatus.GameInProgress);

            cell.Image = (_playerTurn) ? Resources.X : Resources.O;

            _game.RegisterPlayerMove(Convert.ToByte(cell.Tag));

            if (!_game.IsGameOver()) {
                _SwitchPlayer();
                return;
            }

            _gameOver = true;
            string winnerName = _game.GetWinnerName();
            enGameStatus gameStatus = winnerName == null ? enGameStatus.Draw : enGameStatus.WinnerDeclared;
            _UpdateGameStatus(gameStatus);

            if (gameStatus == enGameStatus.WinnerDeclared)
                _HighlightWinningPositions();
        }

        private void restartButton_Click(object sender, EventArgs e) {
            _game.ResetGame();
            foreach(PictureBox cell in gamePanel.Controls) {
                cell.Image = Resources.Question;
                cell.BackColor = Color.FromArgb(255, 224, 247, 250);
            }
                
            _playerTurn = true;
            _gameOver = false;
            _UpdateCurrentPlayer();
            _UpdateGameStatus(enGameStatus.GameInProgress);
        }

        private void TicTacToeForm_Load(object sender, EventArgs e) {

        }
    }
}
