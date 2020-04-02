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
               White = 'O',
               Black = 'X',
               Empty = ' '
          }

          public enum ePlayerType
          {
               Player,
               Computer

          }

          public ePlayerType Type
          {
               get { return r_PlayerType; }
          }

          public eColor Color
          {
               get { return r_Color; }
          }

          public Player()
          {
          }

          public Player (string i_PlayerName, ePlayerType i_PlayerType, eColor i_Color)
          {
               m_PlayerName = i_PlayerName;
               r_PlayerType = i_PlayerType;
               r_Color = i_Color;
          }

          public int Score
          {
               get { return m_Score; }
               set { m_Score = value; }
          }

          public void InitScore()
          {
               m_Score = 2; 
          }
     }
}
