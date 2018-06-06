using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Piece
    {
        private int m_type;
        private Position positionOfPiece;
        private bool isAlive;

        public int Type { get => this.m_type; set => this.m_type = value; }

        public bool IsAlive { get => this.isAlive; set => this.isAlive = value; }

        internal Position PositionOfPiece { get => this.positionOfPiece; set => this.positionOfPiece = value; }
    }

    internal struct Position
    {
        public Position(int rowPosition, int columnPosition)
        {
            this.m_columnPosition = columnPosition;
            this.m_rowPosition = rowPosition;
        }

        private int m_rowPosition;
        private int m_columnPosition;

        public int RowPosition { get => this.m_rowPosition; set => this.m_rowPosition = value; }

        public int ColumnPosition { get => this.m_columnPosition; set => this.m_columnPosition = value; }
    }
}
