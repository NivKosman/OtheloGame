using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Engine
     {
          readonly IOhandler m_IO;
          readonly Board m_Board;
          readonly Player m_Player1;
          readonly Player m_Player2;

          public Engine(Player i_Player1, Player i_Player2)
          {
               m_IO = new IOhandler();
               m_Player1 = i_Player1;
               m_Player2 = i_Player2;
               m_Board=new Board(m_IO.SizeBoard, m_IO.SizeBoard);
          }
          private void updateBoardCauseLegalMove(int i_Row, int i_Col, Player.eColor i_Color)
          {
               m_Board.PlacePiece(i_Row, i_Col, i_Color);
               for(int i=0  ; i<8 ; i++)
               {
                    if((m_Board.ArrayDirections[i].m_FinalRow!= -1) &&(m_Board.ArrayDirections[i].m_FinalCol!=-1))
                    {
                         m_Board.fillsCells(i_Row, i_Col, m_Board.ArrayDirections[i], i_Color);
                    }
               }

               m_Board.ResetArrayDirections();
          }

          public bool Run()
          {
               Player[] Players = new Player[2];
               Players[0] = m_Player1;
               Players[1] = m_Player2;

               bool currPlayerHasMoves = true;
               bool nextPlayerHasMoves = true;
               Move nextMove = m_IO.GetNextMove(Players[0]);
               bool nextMoveIsQuit = nextMove.IsQuitMove();

               m_Board.initDirection();

               while (!nextMoveIsQuit && (currPlayerHasMoves || nextPlayerHasMoves))
               {
                    bool nextMoveIsLegal = CheckIfMoveIsLegal(nextMove, Players[0]);

                    if (nextMoveIsLegal)
                    {
                         updateBoardCauseLegalMove(nextMove.Row, nextMove.Col,Players[0].Color);
                         m_IO.ClearScreen();
                         m_IO.ShowBoard(m_Board);
                         currPlayerHasMoves = PlayerHasAnyValidMoves(Players[0]);
                         nextPlayerHasMoves = PlayerHasAnyValidMoves(Players[1]);
                         if (nextPlayerHasMoves)
                         {
                              swapPlayers(Players);
                         }
                         else
                         {
                              m_IO.ShowNoAvailbleMovesForPlayer(Players[1].PlayerName);
                         }
                    }
                    else
                    {
                         m_IO.ShowIllegalMoveMessage();
                    }

                    nextMove = m_IO.GetNextMove(Players[0]);
                    nextMoveIsQuit = nextMove.IsQuitMove();
               }

               return nextMoveIsQuit;
          }

          private bool CheckIfMoveIsLegal(Move i_NextMove, Player i_Player)
          {
               List<Move> validMoves = new List<Move>();
               validMoves = m_Board.GetListOfValidMovesForPlayer(i_Player);

               return validMoves.Contains(i_NextMove);
          }
          
          private bool PlayerHasAnyValidMoves(Player i_Player)
          {
               List<Move> validMoves = new List<Move>();
               validMoves = m_Board.GetListOfValidMovesForPlayer(i_Player);

               return validMoves.Count > 0;
          }

          private void swapPlayers(Player[] io_Players)
          {
               Player temp = new Player();
               temp = io_Players[0];

               io_Players[0] = io_Players[1];
               io_Players[1] = temp;
          }

     }
}
