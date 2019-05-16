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

          public enum eColor
          {
               White,
               Black,
          }

          private readonly eColor r_Color;

          public Player(ref bool i_IsComputer, ref eColor i_Color)
          {
               v_IsComputer = i_IsComputer;
               r_Color = i_Color;
               if(v_IsComputer)
               {
                    m_PlayerName = "Computer";
               }
          }

          public int Score
          {
               get { return m_Score; }
               set { m_Score = value; }
          }



     }
}
