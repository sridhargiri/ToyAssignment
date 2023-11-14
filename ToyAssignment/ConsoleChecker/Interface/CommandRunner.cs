﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.Board.Interface;
using ToyAssignment.Toy.Interface;
using ToyAssignment.Toy;

namespace ToyAssignment.ConsoleChecker.Interface
{
    /// <summary>
    /// This class is used to simulate the behaviour of the toy.
    /// It calls the interfaces from other classes to make a behaviour object.
    /// Methods for this object include processing the string and
    /// rendering the report.
    /// </summary>
    public class CommandRunner : ICommandRunner
    {
        public IToyRobot ToyRobot { get; private set; }
        public IToyBoard SquareBoard { get; private set; }
        public IInputParser InputParser { get; private set; }

        public CommandRunner(IToyRobot toyRobot, IToyBoard squareBoard, IInputParser inputParser)
        {
            ToyRobot = toyRobot;
            SquareBoard = squareBoard;
            InputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var command = InputParser.ParseCommand(input);
            if (command != Command.Place && ToyRobot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = InputParser.ParseCommandParameter(input);
                    if (SquareBoard.IsValidPosition(placeCommandParameter.Position))
                        ToyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (SquareBoard.IsValidPosition(newPosition))
                        ToyRobot.Position = newPosition;
                    break;
                case Command.Left:
                    ToyRobot.RotateLeft();
                    break;
                case Command.Right:
                    ToyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", ToyRobot.Position.X,
                ToyRobot.Position.Y, ToyRobot.Direction.ToString().ToUpper());
        }
    }
}
