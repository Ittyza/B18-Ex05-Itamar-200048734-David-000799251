using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Move 
    {
        private Position m_startPosition;
        private Position m_EndPosition;

        internal Position StartPosition { get => this.m_startPosition; set => this.m_startPosition = value; }

        internal Position EndPosition { get => this.m_EndPosition; set => this.m_EndPosition = value; }

        public Move(Position startPosition, Position oldPosition)
        {
            this.StartPosition = startPosition;
            this.EndPosition = oldPosition;
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += ((CreateGame.eCapitalLetterDictionary)this.StartPosition.ColumnPosition).ToString();
            result += ((CreateGame.eCapitalLetterDictionary)this.StartPosition.RowPosition).ToString().ToLower();
            result += ">";
            result += ((CreateGame.eCapitalLetterDictionary)this.EndPosition.ColumnPosition).ToString();
            result += ((CreateGame.eCapitalLetterDictionary)this.EndPosition.RowPosition).ToString().ToLower();

            return result;
        }
    } 
}
