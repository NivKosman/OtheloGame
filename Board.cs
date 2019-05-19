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



          struct Directions
          {
             public int m_DirRow;
             public int m_DirCol;
          }
       
        private bool checkDirection(int i_Row, int i_Column, Player.eColor i_Color, Directions i_Direction
             ,out int i_RowToFill,out int i_ColToFill)
          {
               i_RowToFill = -1;
               i_ColToFill = -1;
               bool isDirLegal = true;
               Player.eColor colorToCheck;

               if (i_Color == Player.eColor.White)
               {
                    colorToCheck = Player.eColor.Black;
               }
               else
               {
                    colorToCheck = Player.eColor.White;
               }

               i_Row += i_Direction.m_DirRow;
               i_Column += i_Direction.m_DirCol;
               if (i_Row < 0 || i_Row >= r_Height || i_Column < 0 || i_Column >= r_Width)
               {
                    isDirLegal = false;
               }
               else
               {
                    if (m_Board[i_Row, i_Column] == (char)i_Color || m_Board[i_Row, i_Column] == ' ')
                    {
                         isDirLegal = false;
                    }
                    else
                    { 
                         while (i_Row >= 0 && i_Row < r_Height && i_Column >= 0 && i_Column < r_Width)
                         {            
                              if (m_Board[i_Row, i_Column] == ' ')
                              {
                                   isDirLegal = false;

                                   return isDirLegal;
                              }
                              else if (m_Board[i_Row, i_Column] == (char)colorToCheck)
                              {
                                   i_Row += i_Direction.m_DirRow;
                                   i_Column += i_Direction.m_DirCol;
                              }
                              else
                              {
                                   i_RowToFill = i_Row;
                                   i_ColToFill = i_Column;
                                   return isDirLegal;
                              }
                         }

                         isDirLegal = false;
                    }                        
               }

               return isDirLegal;
          }    

        private void initDirection(Directions [] i_Direstions)
          {
               i_Direstions[0].m_DirRow = -1;
               i_Direstions[0].m_DirCol = 0;
               i_Direstions[1].m_DirRow = 1;
               i_Direstions[1].m_DirCol = 0;
               i_Direstions[2].m_DirRow = 0;
               i_Direstions[2].m_DirCol = 1;
               i_Direstions[3].m_DirRow = 0;
               i_Direstions[3].m_DirCol = -1;
               i_Direstions[4].m_DirRow = -1;
               i_Direstions[4].m_DirCol = -1;
               i_Direstions[5].m_DirRow = -1;
               i_Direstions[5].m_DirCol = 1;
               i_Direstions[6].m_DirRow = 1;
               i_Direstions[6].m_DirCol = -1;
               i_Direstions[7].m_DirRow = 1;
               i_Direstions[7].m_DirCol = 1;
          }
         
        public void UpdateBoardCauseLegalMove(int i_Row, int i_Col, Player.eColor i_Color)
          {
               Directions[] allDirections = new Directions[8];
               initDirection(allDirections);
               int rowToFill;
               int colToFill;

               for(int i=0 ; i<8 ; i++)
               {
                    if (checkDirection(i_Row, i_Col, i_Color, allDirections[i], out rowToFill, out colToFill))
                    {
                         fillsCells(i_Row, i_Col, allDirections[i], i_Color, rowToFill, colToFill);
                    }
               }

          }

        public bool MoveIsLegal(int i_Row, int i_Column,Player.eColor i_Color )
        {
               int rowToFill;
               int colToFill;
               bool v_MoveIsLegal = true;
               bool atLeastOneDirIsLegal = false;
               Directions[] allDirections = new Directions[8];

               initDirection(allDirections);
               if (m_Board[i_Row, i_Column] != ' ')
               {
                    v_MoveIsLegal = false;
               }
               else
               {
                    for(int i=0 ; i<=8 ; i++)
                    {
                         if(checkDirection(i_Row, i_Column, i_Color, allDirections[i],out rowToFill,out colToFill))
                         {
                              atLeastOneDirIsLegal = true;
                         }
                    }
               }

            return v_MoveIsLegal && atLeastOneDirIsLegal;
        }

        private void fillsCells(int i_FromRowToFill,int i_FromColToFill,Directions i_Direction, Player.eColor i_Color,
             int i_ToRowToFill,int i_ToColToFill)
        {
               int row = i_FromRowToFill;
               int col = i_FromColToFill;

               while((row != i_ToRowToFill) && (col != i_ToColToFill))
               {
                    m_Board[row, col] = (char)i_Color;
                    row += i_Direction.m_DirRow;
                    col += i_Direction.m_DirCol;
               }
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
                    move = new Move(i, j);
                    if (MoveIsLegal(i, j,i_Player.Color))
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
