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

               bool nextMoveIsLegal;
               bool currPlayerHasMoves = true;
               bool nextPlayerHasMoves = true;
               Move nextMove = m_IO.GetNextMove(Players[0]);
               bool nextMoveIsQuit = nextMove.IsQuitMove();

               while (!nextMoveIsQuit && (currPlayerHasMoves || nextPlayerHasMoves))
               {
                    if (Players[0].Type == Player.ePlayerType.Player)
                    {    
                         nextMoveIsLegal = CheckIfMoveIsLegal(nextMove, Players[0]);
                    }
                    else
                    {
                         nextMove = acheiveOneLegalMoveOfComputer(Players[0]);
                         nextMoveIsLegal = true;
                    }
                    if (nextMoveIsLegal)
                    {
                         m_Board.UpdateBoardCauseLegalMove(nextMove.Row, nextMove.Col, Players[0].Color);
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

                    if (Players[0].Type == Player.ePlayerType.Player)
                    { 
                         nextMove = m_IO.GetNextMove(Players[0]);
                    }

                    nextMoveIsQuit = nextMove.IsQuitMove();
               }

               m_Player1.Score = m_Board.AmountOfColorInBoard(m_Player1.Color);
               m_Player2.Score = m_Board.AmountOfColorInBoard(m_Player2.Color);

               return nextMoveIsQuit;
          }

          private Move acheiveOneLegalMoveOfComputer(Player i_Player)
          {
               int randomIndex;
               List<Move> validMoves = new List<Move>();
               Random randomNumber = new Random();

               validMoves = m_Board.GetListOfValidMovesForPlayer(i_Player);
               randomIndex = randomNumber.Next(validMoves.Count);

               return validMoves[randomIndex];            
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
