using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Game
     {
          private IOhandler m_IO;
          private Engine m_Engine;
          private Player m_Player1;
          private Player m_Player2;
          private Board m_Board;

          public enum eGameResult
          {
               Player1,
               Player2,
               Tie
          }

          eGameResult GetGameResult(Player i_Player1, Player i_Player2)
          {
               if (i_Player1.Score > i_Player2.Score)
               {
                    return eGameResult.Player1;
               }
               else if (i_Player1.Score < i_Player2.Score)
               {
                    return eGameResult.Player2;
               }
               else
               {
                    return eGameResult.Tie;
               }
          }

          public void Start()
          {
               eGameResult gameResult;
               bool isPressedQ;
               bool isPlayerWantAnotherRound = true;

               m_IO = new IOhandler();
               initGame();
               m_Engine = new Engine(m_Board, m_Player1, m_Player2);
               while (isPlayerWantAnotherRound)
               {
                    m_IO.ShowBoard(m_Board);
                    isPressedQ = m_Engine.Run();
                    if (isPressedQ)
                    {
                         m_IO.ShowGoodByeMessage();
                    }
                    else
                    {
                         gameResult = GetGameResult(m_Player1, m_Player2);
                         m_IO.ShowGameResultMessage(m_Player1, m_Player2, gameResult);
                         isPlayerWantAnotherRound = m_IO.GetStartNewGameSelection();
                    }
               }

               m_IO.ShowGoodByeMessage();
          }

          private void initGame()
          {
               string player1Name = m_IO.GetPlayerName();
               string player2Name;
               int sizeOfBoard;
               m_Player1 = new Player(player1Name, Player.ePlayerType.Player, Player.eColor.Black);
               UI.eModeGame oponentOption = m_IO.GetGameMode();
                           
               if (oponentOption == UI.eModeGame.PlayerVsComputer)
               {
                    player2Name = "Computer";
                    m_Player2 = new Player(player2Name, Player.ePlayerType.Computer, Player.eColor.White);
               }
               else
               {    
                    player2Name = m_IO.GetPlayerName();
                    m_Player2 = new Player(player1Name, Player.ePlayerType.Player, Player.eColor.White);
               }

               sizeOfBoard = m_IO.GetSizeOfBoard();
               m_Board = new Board(sizeOfBoard, sizeOfBoard);
               Move.s_Height = sizeOfBoard;
               Move.s_Width = sizeOfBoard;              
          }
     }
}
