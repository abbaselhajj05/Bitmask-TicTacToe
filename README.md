# Tic Tac Toe (WinForms)

## Overview
A simple and efficient **Tic Tac Toe** game built using **C# and WinForms**. The game logic is optimized using **bitmask operations**, ensuring fast and clean move validation.

## Features
- **Bitmask-Based Logic**
  - Board state is stored using bitwise operations, allowing:
    - **Quick move validation** (bitwise checks instead of loops).
    - **Efficient win detection** (precomputed win masks for instant results).
- **Separation of UI and Logic**
  - `TicTacToeForm.cs` handles user interactions and rendering.
  - `TicTacToe.cs` manages game rules, move tracking, and win conditions.
- **Dynamic Board Handling**
  - Default 3×3 grid, but can be adjusted by modifying `_boardSize`.
- **Game Reset**
  - Restart button to clear the board and start over.

Technologies Used:
- C#
- Windows Forms
- Visual Studio

## Getting Started
1. Clone or download the project.
2. Open the `.sln` file in **Visual Studio 2019** (or newer).
3. Build and run the project to play.

## How to Play
1. Click an empty cell to place **X** or **O**.
2. The game checks for valid moves and determines a winner automatically.
3. Click **Restart** to reset the board.
