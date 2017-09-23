using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    public class Piece
    {
        public virtual void Move(MovementType move, int newX, int newY);
    }
}
