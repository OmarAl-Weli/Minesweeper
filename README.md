# Minesweeper

## Description
This is a simple implementation of the classic Minesweeper game in C#. The game allows users to uncover cells in a grid, trying to avoid hidden bombs. The goal is to uncover all cells that do not contain bombs.

## Features
- Uncover cells in a grid
- Automatically uncover adjacent cells if they are safe
- Display the number of adjacent bombs for each cell
- Win by uncovering all non-bomb cells
- Lose by uncovering a bomb

## How to Run
1. Ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
2. Build the project by running:
   ```sh
   dotnet build
   ```
3. Run the project
    ```sh
    dotnet run
    ```