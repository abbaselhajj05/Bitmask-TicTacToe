using System;
using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac_Toe_Game {
    internal class TicTacToe {
        // Represents a player in the game
        public class Player {
            private string _name;  // Player's name
            private int _occupiedPositions = 0;  // Tracks the positions occupied by the player

            // Constructor to initialize player's name
            public Player(string name) { _name = name; }

            // Method to mark a move by the player
            public void MakeMove(byte position) {
                _occupiedPositions |= (1 << position);  // Set the bit for the occupied position
            }

            // Property to get the positions occupied by the player
            public int OccupiedPositions => _occupiedPositions;

            // Property to get the player's name
            public string Name => _name;

            // Method to reset the player's occupied positions (for game reset)
            public void Reset() => _occupiedPositions = 0;
        }

        // Enum to track which player's turn it is
        enum enPlayerTurn : byte { PlayerOne, PlayerTwo }

        private const byte StandardBoardSize = 3;  // Default board size (3x3)

        private byte _boardSize;  // The size of the board (number of rows/columns)
        private List<Player> _players;  // List of players
        private enPlayerTurn _currentTurn;  // Tracks the current player's turn

        private byte _totalPositionsCount = 0;  // Total number of positions on the board
        private int _totalOccupiedPositions = 0;  // Total number of occupied positions
        private List<int> _winningMasks;  // List of masks that represent winning positions

        // Constructor to initialize the game
        public TicTacToe(byte boardSize = StandardBoardSize, string player1Name = "Player1", string player2Name = "Player2") {
            _boardSize = boardSize;
            _players = new List<Player>() { new Player(player1Name), new Player(player2Name) };
            _currentTurn = enPlayerTurn.PlayerOne;

            _totalPositionsCount = Convert.ToByte(Math.Pow(boardSize, 2));  // Calculate total positions based on board size
            _winningMasks = _FindWinningMasks();  // Generate winning masks
        }

        // Switches the current player to the other player
        private void _SwitchPlayer() {
            _currentTurn = (_currentTurn == enPlayerTurn.PlayerOne) ? enPlayerTurn.PlayerTwo : enPlayerTurn.PlayerOne;
        }

        // Checks if the move is valid (position within range and not already occupied)
        public bool IsValidMove(byte position) {
            if (position < 0 || position >= _totalPositionsCount)
                return false;

            int positionToOccupy = (1 << position); // Generate mask for the position
            return (positionToOccupy & _totalOccupiedPositions) == 0;  // Check if the position is already occupied
        }

        // Registers a move for the current player at the specified position
        public void RegisterPlayerMove(byte position) {
            if (!IsValidMove(position))
                throw new ArgumentException();  // Throw exception if the move is invalid

            int positionToOccupy = (1 << position);  // Generate mask for the position
            _totalOccupiedPositions |= positionToOccupy;  // Mark the position as occupied

            Player currentPlayer = _players[(byte)_currentTurn];  // Get the current player
            currentPlayer.MakeMove(position);  // Mark the move for the current player

            if (IsGameOver())  // Check if the game is over
                return;

            _SwitchPlayer();  // Switch to the next player
        }

        // Generates a mask for a horizontal line from startPosition to endPosition
        private int _GenerateHorizontalMask(short startPosition, short endPosition) {
            int mask = 0;
            for (short i = startPosition; i <= endPosition; i++)
                mask |= (1 << i);  // Set the bit for each position in the horizontal line
            return mask;
        }

        // Generates all horizontal line masks based on the board size
        private List<int> _GenerateHorizontalMasks() {
            List<int> horizontalMasks = new List<int>();
            int mask;
            for (byte i = 0; i < _totalPositionsCount; i += _boardSize) {
                mask = _GenerateHorizontalMask(i, (short)(_boardSize + i - 1));  // Generate mask for each row
                horizontalMasks.Add(mask);
            }
            return horizontalMasks;
        }

        // Generates a mask for a vertical line from startPosition to endPosition
        private int _GenerateVerticalMask(short startPosition, short endPosition) {
            int mask = 0;
            for (short i = startPosition; i <= endPosition; i += _boardSize)
                mask |= (1 << i);  // Set the bit for each position in the vertical line
            return mask;
        }

        // Generates all vertical line masks based on the board size
        private List<int> _GenerateVerticalMasks() {
            List<int> verticalMasks = new List<int>();
            int mask;
            for (short i = 0; i < _boardSize; i++) {
                mask = _GenerateVerticalMask(i, (short)(_totalPositionsCount - 1));  // Generate mask for each column
                verticalMasks.Add(mask);
            }
            return verticalMasks;
        }

        // Generates the masks for both diagonals
        private List<int> _GenerateDiagonalMasks() {
            List<int> diagonalMasks = new List<int>();
            int leftDiagonalMask, rightDiagonalMask;
            leftDiagonalMask = rightDiagonalMask = 0;

            byte leftDiagonalStep = (byte)(_boardSize + 1);  // Step for left diagonal (top-left to bottom-right)
            byte rightDiagonalStep = (byte)(_boardSize - 1);  // Step for right diagonal (top-right to bottom-left)

            // Generate mask for the left diagonal
            for (byte i = 0; i < _totalPositionsCount; i += leftDiagonalStep)
                leftDiagonalMask |= (1 << i);

            // Generate mask for the right diagonal
            for (byte i = rightDiagonalStep; i < _totalPositionsCount - 1; i += rightDiagonalStep)
                rightDiagonalMask |= (1 << i);

            diagonalMasks.Add(leftDiagonalMask);  // Add left diagonal mask
            diagonalMasks.Add(rightDiagonalMask);  // Add right diagonal mask

            return diagonalMasks;
        }

        // Combines all horizontal, vertical, and diagonal masks to find the winning positions
        private List<int> _FindWinningMasks() {
            List<int> horizontalMasks = _GenerateHorizontalMasks();
            List<int> verticalMasks = _GenerateVerticalMasks();
            List<int> diagonalMasks = _GenerateDiagonalMasks();

            List<int> winningMasks = horizontalMasks.Concat(verticalMasks).ToList();  // Concatenate horizontal and vertical masks
            winningMasks = winningMasks.Concat(diagonalMasks).ToList();  // Add diagonal masks

            return winningMasks;
        }

        // Checks if the current player has won by comparing their chosen positions with the winning masks
        private int? _GetWinningMask() {
            int chosenPositions = _players[(byte)_currentTurn].OccupiedPositions;

            foreach (int mask in _winningMasks)
                if ((mask | chosenPositions) == chosenPositions)  // Check if the player's positions match a winning mask
                    return mask;

            return null;  // Return null if no winning mask is found
        }

        // Gets the list of winning positions (if there is a winner)
        public List<byte> GetWinningPositions() {
            int? winningMask = _GetWinningMask();  // Get the winning mask
            if (winningMask == null) return null;  // No winner, return null

            List<byte> winningPositions = new List<byte>();
            for (byte i = 0; winningMask != 0; i++) {
                if ((winningMask & 1) == 1)  // Check if the current bit is set
                    winningPositions.Add(i);
                winningMask >>= 1;   // Shift the mask to the right (divide by 2)
            }
            return winningPositions;
        }

        // Checks if the game is over (either a player has won or all positions are occupied)
        public bool IsGameOver() {
            return _GetWinningMask() != null || _totalOccupiedPositions == (Math.Pow(2, _totalPositionsCount) - 1);
        }

        // Gets the name of the current player
        public string GetCurrentPlayerName() {
            return _players[(byte)_currentTurn].Name;
        }

        // Gets the name of the winner (if there is one)
        public string GetWinnerName() {
            if (_totalOccupiedPositions == (Math.Pow(2, _totalPositionsCount) - 1) && _GetWinningMask() == null)
                return null;  // No winner if the board is full and no winning mask
            return GetCurrentPlayerName();
        }

        // Resets the game to the initial state
        public void ResetGame() {
            foreach (Player player in _players)
                player.Reset();  // Reset each player's moves

            _currentTurn = enPlayerTurn.PlayerOne;  // Reset to player one
            _totalOccupiedPositions = 0;  // Reset occupied positions
        }

        // Property to get the board size
        public byte BoardSize => _boardSize;
    }
}
