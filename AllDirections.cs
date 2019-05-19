using System;
namespace Ex02_Othelo
{
    public class AllDirections
    {

        private const int c_UpRow = -1;
        private const int c_UpCol = 0;

        private const int c_DownRow = 1;
        private const int c_DownCol = 0;

        private const int c_RightRow = 0;
        private const int c_RightCol = 1;

        private const int c_LeftRow = 0;
        private const int c_LeftCol = -1;

        private const int c_LeftUpRow = -1;
        private const int c_LeftUpCol = -1;

        private const int c_RightUpRow = -1;
        private const int c_RightUpCol = 1;

        private const int c_LeftDownRow = 1;
        private const int c_LeftDownCol = -1;

        private const int c_RightDownRow = 1;
        private const int c_RightDownCol = 1;

        private static Directions[] s_Directions;

        public AllDirections()
        {
        }

        private static Directions getLeftDirection()
        {
            return new Directions(c_LeftRow, c_LeftCol);
        }
        private static Directions getRightDirection()
        {
            return new Directions(c_RightRow, c_RightCol);
        }
        private static Directions getUpDirection()
        {
            return new Directions(c_UpRow, c_UpCol);
        }
        private static Directions getDowntDirection()
        {
            return new Directions(c_DownRow, c_DownCol);
        }
        private static Directions getRightUpDirection()
        {
            return new Directions(c_RightUpRow, c_RightUpCol);
        }
        private static Directions getRightDownDirection()
        {
            return new Directions(c_RightDownRow, c_RightDownCol);
        }
        private static Directions getLeftUpDirection()
        {
            return new Directions(c_LeftUpRow, c_LeftUpCol);
        }
        private static Directions getLeftDownDirection()
        {
            return new Directions(c_LeftDownRow, c_LeftDownCol);
        }
        public static Directions[] GetAllDirections()
        {
            if (s_Directions.Length == 0)
            {
                initAllDirections(); 
            }
            return s_Directions;
        }

        private static void initAllDirections()
        {
            Directions dirLeft = getLeftDirection();//new Directions(c_LeftRow, c_LeftCol);
            Directions dirRight = getRightDirection();
            Directions dirUp = getUpDirection();
            Directions dirDown = getDowntDirection();
            Directions dirLeftUp = getLeftUpDirection();
            Directions dirLeftDown = getLeftDownDirection();
            Directions dirRightUp = getRightUpDirection();
            Directions dirRightDown = getRightDownDirection();

            s_Directions = new[] { dirLeft, dirRight, dirUp, dirDown,
                                   dirLeftUp, dirLeftDown,
                                   dirRightUp, dirRightDown};
        }
    }
}
