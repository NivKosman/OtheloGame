using System;
using System.Text;
namespace Ex02_Othelo
{
    public class IOhandler
    {
          public  void ClearScreen()
          {
               UI.ClearScreen();
          }

          public StringBuilder BoardToString(Board i_Board)
          {
               int i, j;
               StringBuilder boardToString = new StringBuilder();
               boardToString.Append("    ");
               for (i = 0; i < i_Board.Height; i++)
               {

                    boardToString.Append(" ");
                    boardToString.Append((char)('A' + i));
                    boardToString.Append("  ");
               }

               boardToString.Append(Environment.NewLine);
               addingEqualChars(boardToString, i_Board.Height);
               boardToString.Append(Environment.NewLine);
               for (i = 0; i < i_Board.Height; i++)
               {
                    boardToString.Append(" ");
                    boardToString.Append((char)('1' + i));
                    boardToString.Append(" |");
                    for (j = 0; j < i_Board.Width; j++)
                    {
                         boardToString.Append(" ");
                         boardToString.Append(i_Board.Matrix[i, j]);
                         boardToString.Append(" |");
                    }

                    boardToString.Append(Environment.NewLine);
                    addingEqualChars(boardToString, i_Board.Height);
                    boardToString.Append(Environment.NewLine);
               }

               return boardToString;
          }

          private void addingEqualChars(StringBuilder io_Board, int i_BoardHeight)
          {
               io_Board.Append("   ");
               for (int i = 0; i < (i_BoardHeight * 4) + 1; i++)
               {
                    io_Board.Append("=");
               }
          }

        public IOhandler()
        {
        }
        public Move GetNextMove()
        {
            return new Move(true); 
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

        public void ShowGameResultMessage()
        { 
        }

        public void ShowGoodByeMessage()
        { 
        }
    }
}
