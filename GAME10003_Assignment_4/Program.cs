namespace GAME10003_Assignment_4
{
    using System;
  
    using Raylib_cs;

    namespace GAME10003_Assignment_4
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int screenWidth = 300;
                const int screenHeight = 300;
                const int boardSize = 3;

                Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");

                int[,] board = new int[boardSize, boardSize];
                int currentPlayer = 1;
                bool gameOver = false;

                while (!Raylib.WindowShouldClose() && !gameOver)
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.White);

                    // Draw the board
                    for (int y = 0; y < boardSize; y++)
                    {
                        for (int x = 0; x < boardSize; x++)
                        {
                            Rectangle cell = new Rectangle(x * (screenWidth / boardSize), y * (screenHeight / boardSize),
                                                       screenWidth / boardSize, screenHeight / boardSize);

                            // Draw X or O
                            if (board[x, y] == 1)
                            {
                                Raylib.DrawText("X", (int)(cell.X + cell.Width / 2 - 10), (int)(cell.Y + cell.Height / 2 - 20), 40, Color.Black);
                            }
                            else if (board[x, y] == 2)
                            {
                                Raylib.DrawText("O", (int)(cell.X + cell.Width / 2 - 10), (int)(cell.Y + cell.Height / 2 - 20), 40, Color.Black);
                            }

                            // Draw cell borders
                            Raylib.DrawRectangleLinesEx(cell, 2, Color.Black);
                        }
                    }

                    // Check for player input
                    if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                    {
                        // Get cell clicked
                        int mouseX = Raylib.GetMouseX();
                        int mouseY = Raylib.GetMouseY();
                        int cellX = mouseX / (screenWidth / boardSize);
                        int cellY = mouseY / (screenHeight / boardSize);

                        // Check if the cell is empty and the game is not over
                        if (board[cellX, cellY] == 0)
                        {
                            board[cellX, cellY] = currentPlayer;

                            // Check for win condition
                            if (CheckWin(board, currentPlayer))
                            {
                                Console.WriteLine("Player " + currentPlayer + " wins!");
                                gameOver = true;
                            }
                            else if (IsBoardFull(board))
                            {
                                Console.WriteLine("It's a draw!");
                                gameOver = true;
                            }
                            else
                            {
                                // Switch players
                                currentPlayer = currentPlayer == 1 ? 2 : 1;
                            }
                        }
                    }

                    Raylib.EndDrawing();
                }

                Raylib.CloseWindow();
            }

            static bool CheckWin(int[,] board, int player)
            {
                // Check rows and columns
                for (int i = 0; i < 3; i++)
                {
                    if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                    {
                        return true;
                    }
                }

                // Check diagonals
                if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
                {
                    return true;
                }

                return false;
            }

            static bool IsBoardFull(int[,] board)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    for (int x = 0; x < board.GetLength(0); x++)
                    {
                        if (board[x, y] == 0)
                        {
                        return false;
                        }
                    }
                }
                return true;
            }
        }

    }
 }
