using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.Toy;

namespace ToyAssignment.Board.Interface
{
    public interface IToyBoard
    {
        // this interface enables access to a boolean method that returns
        // true or false if the position of the robot is within the board
        bool IsValidPosition(Position position);
        int Rows { get; set; }
        int Columns { get; set; }
    }
}
