using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Player
     {
          List<Move> m_ValidMoves;
          private int m_Score = 0;
          private bool v_IsComputer;
          private string m_PlayerName;

          public string PlayerName
          {
               get { return m_PlayerName; }
               set { m_PlayerName = value; }
          }

          public enum eSymbol
          {
               White,
               Black,
               Empty,
          }

          private eSymbol m_Symbol;

          public Player(ref bool i_IsComputer, ref eSymbol i_eSymbol)
          {
               v_IsComputer = i_IsComputer;
               m_Symbol = i_eSymbol;
               if(v_IsComputer)
               {
                    m_PlayerName = "Computer";
               }
          }

          public int Score
          {
               get { return m_Score; }
               set { m_Score++; }
          }



     }
}
