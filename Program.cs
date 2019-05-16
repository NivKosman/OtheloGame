using System;
namespace Ex02_Othelo
{
     public class Program
     {
          public static void Main()
          {
               //Move.s_Height = 8;
               //Move.s_Width = 8;
               Console.WriteLine("Hollla!!!");
               Console.WriteLine("Good Luckk to us... :)!!");
               Console.WriteLine("Andrey Change and now again niv!!");
               //Ex02.ConsoleUtils.Screen.Clear();
               Console.WriteLine("Another one");
               Console.WriteLine("Another two..");
               Console.WriteLine("#Ethalnu..\n");

               Move move_test;
               Console.ReadLine();
               //String input = Console.ReadLine(); TODO: figure out why unable to get input from user
               String input = "B1";
               Move.TryParse(input, out move_test);
               Console.WriteLine("Move is Quit: {0}", move_test.IsQuitMove());
               Console.WriteLine(move_test.Col);
               Console.WriteLine(move_test.Row);      

          
          }          
     }
}