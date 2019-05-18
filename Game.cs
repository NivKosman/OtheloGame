using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Game
     {
          private IOhandler m_IO=new IOhandler();
          private Engine m_Engine;
          private Player m_Player1;
          private Player m_Player2;
          private Board m_Board;

          public void Start()
          {
               bool isPressedQ;
               bool isPlayerWantAnotherRound = true;

               while (isPlayerWantAnotherRound)
               {
                    this.initNewRun();
                    isPressedQ = m_Engine.Run();
                    if (isPressedQ)
                    {
                         m_IO.ShowGoodByeMessage();
                    }
                    else
                    {
                         m_IO.ShowGameResultMessage();
                         isPlayerWantAnotherRound = true;//i dont have the methood to ask player
                    }
               }

               m_IO.ShowGoodByeMessage();
          }

          private void initNewRun()
          {
               m_Player1 = new Player();//Need To Change
               m_Player2 = new Player();//Need To Change
               m_Board = new Board(m_IO.GetSizeBoard(), m_IO.GetSizeBoard());
               m_Engine = new Engine(m_Board, m_Player1, m_Player2);
          }
     }
}
