using System;
namespace Ex02_Othelo
{
    public class Directions
    {
        public int m_DirRow;
        public int m_DirCol;

        public Directions(int i_Row, int i_Col)
        {
            m_DirRow = i_Row;
            m_DirCol = i_Col;
        }

        public int Row
        {
            get { return m_DirRow; } 
        }

        public int Col
        {
            get { return m_DirCol;  } 
        }
    }
}
