using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Engine
     {
          private IOhandler m_IO;
          private Board m_Board;
          private Player m_Player1;
          private Player m_Player2;

          public Engine(Board io_Board, Player i_Player1, Player i_Player2)
          {
               m_IO = new IOhandler();
               m_Board = io_Board;
               m_Player1 = i_Player1;
               m_Player2 = i_Player2;
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
//m_Board.CreateValidMovesToPlayer(Players[0]).Count > 0
               while (!nextMoveIsQuit && (currPlayerHasMoves || nextPlayerHasMoves))
               {
                    bool nextMoveIsLegal = CheckIfMoveIsLegal(nextMove, Players[0]);

                    if (nextMoveIsLegal)
                    {
                         m_Board.PlacePiece(nextMove.Row, nextMove.Col, Players[0].Color);
                         currPlayerHasMoves = PlayerHasAnyValidMoves(Players[0]);
                         nextPlayerHasMoves = PlayerHasAnyValidMoves(Players[1]);
                         if (nextPlayerHasMoves)
                         {
                              swapPlayers(Players);
                         }
                         else
                         {
                              m_IO.ShowNoAvailbleMovesForPlayer();
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
