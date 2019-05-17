using System;
namespace Ex02_Othelo
{
    public class IOhandler
    {
        public IOhandler()
        {
        }
        public Move GetNextMove(Player i_Player)
        {
            return new Move(1,1); //Not really 
        }

        public string GetPlayerName()
        {
            return "Moshe"; 
        }

        public UI.eModeGame GetGameMode()
        {
            return UI.eModeGame.PlayerVsComputer; 
        }

        public bool GetStartNewGameSelection()
        {
            return true; 
        }

        public void ShowBoard(Board io_Board)
        { 
        }

        public void ShowNoAvailbleMovesForPlayer()
         {
         }

          public void ShowGameResultMessage()
        { 
        }

          public void ShowIllegalMoveMessage()
          {
          }

          public void ShowGoodByeMessage()
        { 
        }
    }
}
