using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
     public class Player
     {
          
          private bool v_IsComputer;
          public enum eSymbol
          {
               White,
               Black,
               Empty,
          }

          private eSymbol m_Symbol;

          public Player(ref bool i_IsComputer,ref eSymbol i_eSymbol)
          {
               v_IsComputer = i_IsComputer;
               m_Symbol = i_eSymbol;
          }


     }
}
