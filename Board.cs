using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
    public class Board
    {
        private readonly int r_Height;
        private readonly int r_Width;
        private char[,] m_Board;

        public class Cell
        {
            int m_Row;
            int m_Col;
            public Cell(int i_Row, int i_Col)
            {
                m_Row = i_Row;
                m_Col = i_Col;
            } 
            public int Row 
            {
                get { return m_Row; } 
                set { m_Row = value; }
            }
            public int Col
            {
                get { return m_Col; }
                set { m_Col = value; } 
            }
            public void MoveToDirection(Directions i_Direction)
            {
                Row += i_Direction.m_DirRow;
                Col += i_Direction.m_DirCol; 
            }
            public bool AtSameLocationLikeCell(Cell i_Cell)
            {
                return m_Row == i_Cell.Row && m_Col == i_Cell.Col;
            }
        }

        Player.eColor GetOponentColor(Player.eColor i_Color)
        {
            return i_Color == Player.eColor.White? Player.eColor.Black : Player.eColor.White;
        }

        bool CellOutOfBoundary(Cell i_CellToCheck)
        {
            int row = i_CellToCheck.Row;
            int col = i_CellToCheck.Col;
            return row < 0 || row >= r_Height || col < 0 || col >= r_Width;
        }

        bool CellContainsColor(Cell i_CellToCheck, Player.eColor i_Color)
        {
            char cellValueInBoard = GetPiece(i_CellToCheck.Row, i_CellToCheck.Col);
            return cellValueInBoard == (char)i_Color;


        }
        public void UpdateBoardCauseLegalMove(Move i_Move, Player.eColor i_Color)
        {
            List<Directions> MoveValidDirections = i_Move.ValidDirections;
            List<Cell> MoveValidEndCells = i_Move.ValidEndCells;

            Cell startCell;

            for (int i = 0; i < MoveValidDirections.Count; i++)
            {
                startCell = new Cell(i_Move.Row, i_Move.Col);
                Directions validDirection = MoveValidDirections[i];
                Cell finalCellInDirection = MoveValidEndCells[i];
                fillsCells(startCell, validDirection, finalCellInDirection, i_Color);
            }
        }
        private bool checkDirection(Cell i_StartCell, Player.eColor i_CurrentPlayerColor, 
                                    Directions i_Direction, out Cell o_EndCell)
        {
            Player.eColor oponentColor = GetOponentColor(i_CurrentPlayerColor);
            i_StartCell.MoveToDirection(i_Direction);
            bool cellContainsCurrentPlayerColor = false;
            bool cellContainsOponentColor = false;
            bool cellOutOfBoundary = CellOutOfBoundary(i_StartCell);
            if (!cellOutOfBoundary)
            {
                cellContainsOponentColor = CellContainsColor(i_StartCell, oponentColor);
            }

            while (!cellOutOfBoundary && cellContainsOponentColor)
            {
                i_StartCell.MoveToDirection(i_Direction);
                cellOutOfBoundary = CellOutOfBoundary(i_StartCell);
                if (!cellOutOfBoundary)
                {
                    cellContainsOponentColor = CellContainsColor(i_StartCell, oponentColor);
                    cellContainsCurrentPlayerColor = CellContainsColor(i_StartCell, i_CurrentPlayerColor);
                }
            }
            o_EndCell = new Cell(i_StartCell.Row, i_StartCell.Col);

            return !cellOutOfBoundary && cellContainsCurrentPlayerColor;
        }
        
        public bool MoveIsLegal(int i_Row, int i_Column, Player.eColor i_PlayerColor, out Move o_Move)
        {
            o_Move = null;
            bool v_MoveIsLegal = false;
            Cell cellToCheck = new Cell(i_Row, i_Column);
            Directions[] allDirections = AllDirections.GetAllDirections();
          
            if (cellIsEmpty(cellToCheck))
            {
                o_Move = new Move(i_Row, i_Column);
                foreach(Directions direction in allDirections)
                {
                    Cell startCell = new Cell(i_Row, i_Column);
                    Cell endCell;
                    if (checkDirection(startCell, i_PlayerColor, direction, out endCell))
                    {
                        o_Move.AddValidDirection(direction, endCell);
                    }
                }

                v_MoveIsLegal = o_Move.HasValidMove();
            }

            return v_MoveIsLegal;
        }



        private void fillsCells(Cell i_FromCell, Directions i_Direction, Cell i_ToCell, Player.eColor i_Color)
        {
            while (!i_FromCell.AtSameLocationLikeCell(i_ToCell))
            {
                PlacePiece(i_FromCell.Row, i_FromCell.Col, i_Color);
                i_FromCell.MoveToDirection(i_Direction); 
            }
         }

        private bool cellIsEmpty(Cell i_CellToCheck)
        {
            return GetValueAtCell(i_CellToCheck) == (char)Player.eColor.Empty;
        }

        public char GetValueAtCell(Cell i_CellToGet)
        {
            int row = i_CellToGet.Row;
            int col = i_CellToGet.Col;

            return m_Board[row, col];
        }

        public int AmountOfColorInBoard(Player.eColor i_Color)
        {
            char colorToCheck = (char)i_Color;
            int counterColor = 0;

            for (int i = 0; i < r_Height; i++)
            {
                for (int j = 0; j < r_Width; j++)
                {
                    if (m_Board[i, j] == colorToCheck)
                    {
                        counterColor++;
                    }
                }
            }

            return counterColor;
        }

        public Board(int i_height, int i_width)
        {
            r_Height = i_height;
            r_Width = i_width;
            m_Board = new char[r_Height, r_Width];
            initBoard(r_Height, r_Width);

        }

        private void initBoard(int i_height, int i_width)
        {
            clearBoard(i_height, i_width);
            placeStartingPieces(i_height, i_width);

        }

        private void placeStartingPieces(int i_height, int i_width)
        {
            int columnOfUpperLeftCorner = (i_width / 2)-1;
            int rowOfUpperLeftCorner = (i_height / 2)-1;

            PlacePiece(rowOfUpperLeftCorner, columnOfUpperLeftCorner, Player.eColor.White);
            PlacePiece(rowOfUpperLeftCorner + 1, columnOfUpperLeftCorner + 1, Player.eColor.White);
            PlacePiece(rowOfUpperLeftCorner + 1, columnOfUpperLeftCorner, Player.eColor.Black);
            PlacePiece(rowOfUpperLeftCorner, columnOfUpperLeftCorner + 1, Player.eColor.Black);
        }

        private void clearBoard(int i_height, int i_width)
        {
            for (int i = 0; i < i_height; i++)
            {
                for (int j = 0; j < i_width; j++)
                {
                    m_Board[i, j] = (char)Player.eColor.Empty;
                }
            }

        }
       
        public List<Move> GetListOfValidMovesForPlayer(Player i_Player)
        {
            List<Move> validMoves = new List<Move>();

            int i, j;

            for (i = 0; i < r_Height; i++)
            {
                for (j = 0; j < r_Width; j++)
                {
                    Move move;
                    if (MoveIsLegal(i, j, i_Player.Color, out move))
                    {
                        validMoves.Add(move);
                    }
                }
            }

            return validMoves;
        }

        public char[,] Matrix
        {
            get { return m_Board; }
        }

        public int Height
        {
            get { return r_Height; }
        }

        public int Width
        {
            get { return r_Width; }
        }

        public char GetPiece(int i_Height, int i_Width)
        {
            return m_Board[i_Height, i_Width];
        }
        public void PlacePiece(int i_Height, int i_Width, Player.eColor i_Color)
        {
            m_Board[i_Height, i_Width] = (char)i_Color;
        }

        public StringBuilder BoardToString()
        {
            int i, j;
            StringBuilder boardToString = new StringBuilder();
            boardToString.Append("    ");
            for (i = 0; i < Height; i++)
            {

                boardToString.Append(" ");
                boardToString.Append((char)('A' + i));
                boardToString.Append("  ");
            }

            boardToString.Append(Environment.NewLine);
            addingEqualChars(boardToString, Height);
            boardToString.Append(Environment.NewLine);
            for (i = 0; i < Height; i++)
            {
                boardToString.Append(" ");
                boardToString.Append((char)('1' + i));
                boardToString.Append(" |");
                for (j = 0; j < Width; j++)
                {
                    boardToString.Append(" ");
                    boardToString.Append(Matrix[i, j]);
                    boardToString.Append(" |");
                }

                boardToString.Append(Environment.NewLine);
                addingEqualChars(boardToString, Height);
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


    }
}