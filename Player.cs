using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Player
     {
          private int m_Score = 0;
          private readonly ePlayerType r_PlayerType;
          private readonly eColor r_Color;
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

          public enum ePlayerType
          {
               Player,
               Computer

          }

          public eColor Color
          {
               get { return r_Color; }
          }

          public Player()
          {

          }
          public Player(ref ePlayerType i_PlayerType, ref eColor i_Color)
          {
               r_PlayerType = i_PlayerType;

               r_Color = i_Color;
               if(r_PlayerType == ePlayerType.Computer)
               {
                    m_PlayerName = "Computer";
               }
          }

          public int Score
          {
               get { return m_Score; }
               set { m_Score = value; }
          }

          public void InitScore()
          {
               m_Score = 0; 
          }
     }
}
