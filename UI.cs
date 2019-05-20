using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
    public class UI
    {

        public UI()
        { 
        }

        public enum eModeGame
        {
            PlayerVsPlayer,
            PlayerVsComputer,
            Invalid
        }

        public void ShowGreetingMessage()
        {
            PrintMessage(GameMessages.Greeting);
        }

        public void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        public void PrintBoard(StringBuilder i_BoardString)
        {
            Console.Write(i_BoardString);
        }

        public string GetResponseForPlayAgainMessage()
        {
            PrintMessage(GameMessages.PlayAgain);

            return GetInput();
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.WriteLine(i_MessageToPrint); 
        }

        public void PrintMessageWithParam(string i_MessageToPrint, string i_Parameter)
        {
            Console.WriteLine(i_MessageToPrint, i_Parameter);
        }

        public void PrintMessageWith2Param(string i_MessageToPrint, string i_Parameter1, string i_Parameter2)
        {
            Console.WriteLine(i_MessageToPrint, i_Parameter1, i_Parameter2);
        }

        public string GetInput()
        {
            return Console.ReadLine(); 
        }

        public string GetModeGameFromUser()
        {
            PrintMessage(GameMessages.GetEnemyOption);

            return GetInput();
        }

        public void ShowInvalidMoveMessage()
        {
            PrintMessage(GameMessages.InvalidMoveEntered);
        }

        public void ShowNoAvailableMovesMessage(string i_PlayerName)
        {
            PrintMessageWithParam(GameMessages.NoValidMovesLeftToPlayer, i_PlayerName);
        }

        public void ShowGameEnded()
        {
               PrintMessage(GameMessages.GameEnded);
               Environment.Exit(1);
        }

        public void ShowGameQuitted()
        {
            PrintMessage(GameMessages.GameQuited); 
        }

        public string GetBoardSize()
        {
            PrintMessage(GameMessages.GameBoardSize);

            return GetInput();
        }

        public string GetNextMoveString()
        {
            PrintMessage(GameMessages.GetMove);

            return GetInput();
        }

        public string GetNameFromUser()
        {
            PrintMessage(GameMessages.GetNameOfPlayer);

            return GetInput();
        }

        public void ShowWhichPlayerTurn(string i_PlayerName)
        {
            PrintMessageWithParam(GameMessages.NextPlayerToMakeMove, i_PlayerName); 
        } 

        public void ShowPlayerWonMessage(string i_PlayerName)
        {
            PrintMessageWithParam(GameMessages.WinnerPLayer, i_PlayerName);
             
        }

        public void ShowGameResultTie()
        {
            PrintMessage(GameMessages.GameResultTie); 
        }

        public void ShowPlayerScore(string i_PlayerName, int i_PlayerScore)
        {
           PrintMessageWith2Param(GameMessages.PlayerGameSummery, i_PlayerName, i_PlayerScore.ToString()); 
        }
        public void ShowGameSummeryTitle()
        {
            PrintMessage(GameMessages.GameSummery); 
        }
     }
}
