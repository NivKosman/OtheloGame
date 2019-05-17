using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class UI
     {
          public enum eModeGame
          {
               PlayerVsPlayer,
               PlayerVsComputer,
               Invalid
          }

          public static void ClearScreen()
          {
               Ex02.ConsoleUtils.Screen.Clear();
          }

          public static void ShowBoardString(StringBuilder i_BoardString)
          {
               Console.Write(i_BoardString);
          }

          public static string AskingUserPlayingAgainOrEnding()
          {
               string userChoise;

               Console.WriteLine("if you would like to play again please press 1");
               Console.WriteLine("but if you want to end press 2");
               userChoise = Console.ReadLine();

               return userChoise;
          }

          public static string GetModeGameFromUser()
          {
               string userChoise;

               Console.WriteLine("if you want to play against other player please press 0");
               Console.WriteLine("but if you want to play against the computer please press 1");
               userChoise = Console.ReadLine();

               return userChoise;
          }

          public static void ShowInvalidMoveMessage()
          {
               Console.WriteLine("Please choose valid cell");
          }

          public static void ShowNoAvailableMovesMessage()
          {
               Console.WriteLine("Sorry but you dont have valid moves,therefore we turn to the opponent");
          }

          public static void ShowGameEnded()
          {
               Console.WriteLine("thank you for playing our game");
               Environment.Exit(1);
          }

          public static string GetBoardSize()
          {
               string sizeString;

               Console.WriteLine("Please Choose the Size of the Matrix (6 OR 8) and then press enter");
               sizeString = Console.ReadLine();

               return sizeString;
          }

          public static string GetNextMoveString()
          {
               Console.WriteLine("Please enter a Move");
               string move = Console.ReadLine();

               return move;
          }

          public static string GetNameFromUser()
          {
               Console.WriteLine("Hello to Othelo game,please enter your name(and press enter)");
               string name = Console.ReadLine();

               return name;
          }


          public static void ShowGameWinMessage(Player i_Player1, Player i_Player2)
          {
               Console.WriteLine("{0} score:{1}",i_Player1.PlayerName, i_Player1.Score);
               Console.WriteLine("{0} score:{1}", i_Player2.PlayerName, i_Player1.Score);
               if (i_Player1.Score > i_Player2.Score)
               {
                    Console.WriteLine("Congratulations to {0} for winning the game", i_Player1.PlayerName);
               }
               else if (i_Player1.Score < i_Player2.Score)
               {
                    Console.WriteLine("Congratulations to {0} for winning the game", i_Player2.PlayerName);
               }
               else
               {
                    Console.WriteLine("We Have a Tie");
               }
          }
     }
}
