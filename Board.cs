using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
    public class Board
    {
        private readonly int r_Height;
        private readonly int r_Width;
        private char[,] m_Board;

        private bool moveIsLegal(Move io_move)
        {
            //TODO->implementation
            return true;
        }
        private bool moveIsLegal(int i_Column, int i_Row)
        {
            //TODO->implementation
            return true;
        }

        private bool cellIsEmpty(int i_Height, int i_Width)
        {
            return m_Board[i_Height, i_Width] == (char)Player.eColor.Empty;
        }

        public int AmountOfColorInBoard(ref Player.eColor i_Color)
        {
            char colorToCheck = (char)i_Color;
            int counterColor = 0;

            for (int i = 0; i < r_Height; i++)
            {
                for (int j = 0; j < r_Width; j++)
                {
                    if (m_Board[i, j] == colorToCheck)
                    {
                        counterColor++;
                    }
                }
            }

            return counterColor;

        }

        public Board(int i_height, int i_width)
        {
            r_Height = i_height;
            r_Width = i_width;
            m_Board = new char[r_Height, r_Width];
            initBoard(r_Height, r_Width);

        }

        private void initBoard(int i_height, int i_width)
        {
            clearBoard(i_height, i_width);
            placeStartingPieces(i_height, i_width);

        }

        private void placeStartingPieces(int i_height, int i_width)
        {
            int columnOfUpperLeftCorner = i_width / 2;
            int rowOfUpperLeftCorner = i_height / 2;

            PlacePiece(rowOfUpperLeftCorner, columnOfUpperLeftCorner, Player.eColor.White);
            PlacePiece(rowOfUpperLeftCorner + 1, columnOfUpperLeftCorner + 1, Player.eColor.White);
            PlacePiece(rowOfUpperLeftCorner + 1, columnOfUpperLeftCorner, Player.eColor.Black);
            PlacePiece(rowOfUpperLeftCorner, columnOfUpperLeftCorner + 1, Player.eColor.Black);
        }

        private void clearBoard(int i_height, int i_width)
        {
            for (int i = 0; i < i_height; i++)
            {
                for (int j = 0; j < i_width; j++)
                {
                    m_Board[i, j] = (char)Player.eColor.Empty;
                }
            }

        }

        public List<Move> GetListOfValidMovesForPlayer(Player i_Player)
        {
            List<Move> validMoves = new List<Move>();
            Move move;
            int i, j;

            for (i = 0; i < r_Height; i++)
            {
                for (j = 0; j < r_Width; j++)
                {
                    //move = new Move(i, j);
                    if (moveIsLegal(i, j))
                    {
                        move = new Move(i, j);
                        validMoves.Add(move);
                    }
                }
            }

            return validMoves;
        }

          public char[,] Matrix
        {
            get { return m_Board; }
        }

          public int Height
        {
            get { return r_Height; }
        }

          public int Width
        {
            get { return r_Width; }
        }

        public char GetPiece(int i_Height, int i_Width)
        {
            return m_Board[i_Height, i_Width];
        }
        public void PlacePiece(int i_Height, int i_Width, Player.eColor i_Color)
        {
            m_Board[i_Height, i_Width] = (char)i_Color;
        }

        public StringBuilder ToString()
        {
            int i, j;
            StringBuilder boardToString = new StringBuilder();
            boardToString.Append("    ");
            for (i = 0; i < Height; i++)
            {

                boardToString.Append(" ");
                boardToString.Append((char)('A' + i));
                boardToString.Append("  ");
            }

            boardToString.Append(Environment.NewLine);
            addingEqualChars(boardToString, Height);
            boardToString.Append(Environment.NewLine);
            for (i = 0; i < Height; i++)
            {
                boardToString.Append(" ");
                boardToString.Append((char)('1' + i));
                boardToString.Append(" |");
                for (j = 0; j < Width; j++)
                {
                    boardToString.Append(" ");
                    boardToString.Append(Matrix[i, j]);
                    boardToString.Append(" |");
                }

                boardToString.Append(Environment.NewLine);
                addingEqualChars(boardToString, Height);
                boardToString.Append(Environment.NewLine);
            }

            return boardToString;
        }

        private void addingEqualChars(StringBuilder io_Board, int i_BoardHeight)
        {
            io_Board.Append("   ");
            for (int i = 0; i < (i_BoardHeight * 4) + 1; i++)
            {
                io_Board.Append("=");
            }
        }


    }
}
