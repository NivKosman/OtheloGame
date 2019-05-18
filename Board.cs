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
          private char[,] i_Board;
          
          private bool moveIsLegal(Move io_move)
          {
               //TODO->implementation
               return true;
          }
          private bool moveIsLegal(int i_Column, int i_Row)
          {
               //TODO->implementation
               return true;
            
          public int AmountOfColorInBoard(ref Player.eColor i_Color)
          {
               char colorToCheck;
               int counterColor = 0;

               if (i_Color == Player.eColor.White)
               {
                    colorToCheck = 'O';
               }
               else
               {
                    colorToCheck = 'X';
               }

               for (int i = 0; i < r_Height; i++)
               {
                    for (int j = 0; j < r_Width; j++)
                    {
                         if (this.i_Board[i, j] == colorToCheck)
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
               this.i_Board = new char[r_Height, r_Width];
               for (int i = 0; i < r_Height; i++)
               {
                    for (int j = 0; j < r_Width; j++)
                    {
                         this.i_Board[i, j] = ' ';
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

          public int AmountOfColorInBoard(ref Player.eColor i_Color)
          {
               char colorToCheck;
               int counterColor = 0;

               if (i_Color == Player.eColor.White)
               {
                    colorToCheck = 'O';
               }
               else
               {
                    colorToCheck = 'X';
               }

               for (int i = 0; i < r_Height; i++)
               {
                    for (int j = 0; j < r_Width; j++)
                    {
                         if (this.i_Board[i, j] == colorToCheck)
                         {
                              counterColor++;
                         }
                    }
               }

               return counterColor;
          }

          public char[,] Matrix
          {
               get { return i_Board; }
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
               return this.i_Board[i_Height, i_Width];
          }
          public void PlacePiece(int i_Height, int i_Width, Player.eColor i_Color)
          {
               if (i_Color == Player.eColor.White)
               {
                    this.i_Board[i_Height, i_Width] = 'O';
               }
               else
               {
                    this.i_Board[i_Height, i_Width] = 'X';
               }
          }
          
          private bool cellIsEmpty(int i_Height, int i_Width)
          {
               return i_Board[i_Height, i_Width] == ' ';
          }


     }
}
