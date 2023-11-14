using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.Board.Interface;
using ToyAssignment.ConsoleChecker;
using ToyAssignment.ConsoleChecker.Interface;
using ToyAssignment.Toy;
using ToyAssignment.Toy.Interface;

namespace ToyAssignmentTests
{
    public class TestConsoleChecker
    {
        private Mock<IInputParser> _inputParser;
        private Mock<IToyBoard> _toyBoard;
        private Mock<IToyRobot> _toyRobot;

        [SetUp]
        public void TestInitialize()
        {
            this._toyRobot = new Mock<IToyRobot>();
            this._toyBoard = new Mock<IToyBoard>();
            this._inputParser = new Mock<IInputParser>();
            _toyBoard.Object.Rows = 5;
            _toyBoard.Object.Columns = 5;

        }
        /// <summary>
        /// Test valid place command
        /// </summary>
        [Test]
        public void TestValidPlaceCommand()
        {
            // arrange
            string[] rawInput = "PLACE".Split(' ');
            _inputParser.Setup(x => x.ParseCommand(rawInput)).Returns(Command.Place);
            // act
            var command = _inputParser.Object.ParseCommand(rawInput);

            // assert
            Assert.That(command, Is.EqualTo(Command.Place));
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { _inputParser.Object.ParseCommand(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT"));
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [Test]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            Position pos = new Position(4, 3);

            PlaceCommandParameter cmd = new PlaceCommandParameter(pos,Direction.West);
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            _inputParser.Setup(x => x.ParseCommandParameter(rawInput)).Returns(cmd);
            var placeCommandParameter = _inputParser.Object.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.Position.X);
            Assert.AreEqual(3, placeCommandParameter.Position.Y);
            Assert.AreEqual(Direction.West, placeCommandParameter.Direction);
        }
    }
}
