using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class UI
     {
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

          public static void GetBoardSizeString()
          {
               Console.WriteLine("Please Choose the Size of the Matrix (6 OR 8) and then press enter");
               string sizeString = Console.ReadLine();
               int SizeNum;
               Int32.TryParse(sizeString, out SizeNum);
               //TODO->intialing SizeNum to board
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
