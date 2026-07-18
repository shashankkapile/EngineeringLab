using System.Drawing;
using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Board
    {
        private Cell[,] grid;
        public Board(int size)  
        {
            grid = new Cell[size, size];

            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    grid[i, j] = new Cell();
                }
            }
        }

        public bool IsFull()
        {
            for(int i = 0; i<grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i,j].IsEmpty()) return false;
                }
            }
            return true;
        }

        public void PlaceSymbol(int row, int col, Symbol symbol)
        {
            if(!IsCellEmpty(row, col))
            {
                throw new InvalidOperationException("Cell is already occupied.");
            }
            
            grid[row, col].Symbol = symbol;
        }

        void PrintBoard()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    Console.Write(grid[i, j]+" ");
                }
                Console.WriteLine();
            }
        }

        private bool IsCellEmpty(int row, int col)
        {
            return grid[row, col].IsEmpty();
        }
    }
}
